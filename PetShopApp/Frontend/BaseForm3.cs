using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;
using PetShopApp.Properties;

namespace PetShopApp.Frontend
{
    public partial class BaseForm3 : Form
    {
        protected Panel Card;
        protected Label TitleLabel;
        protected Button CancelButton;
        protected Button ActionButton;

        protected readonly List<TextBox> InputBoxes = new List<TextBox>();
        protected readonly List<Panel> InputPanels = new List<Panel>();

        protected virtual string TitleText => string.Empty;
        protected virtual string CancelText => Resources.ResourceManager.GetString("Common_Cancel") ?? "Отмена";
        protected virtual string ActionText => string.Empty;
        protected virtual string[] InputPlaceholders => new string[0];

        // Под макеты: card прямоугольная, без скругления.
        protected virtual Size CardSize => new Size(860, 860);
        protected virtual int CardRadius => 0;
        protected virtual int BorderThickness => 2;
        protected virtual int TitleTop => 95;
        protected virtual int TitleHeight => 72;
        protected virtual int TitleSideMargin => 70;
        protected virtual int InputWidth => 430;
        protected virtual int InputHeight => 52;
        protected virtual int FirstInputY => 305;
        protected virtual int InputStepY => 85;
        protected virtual int InputTextLeft => 18;
        protected virtual int InputTextTop => 16;
        protected virtual int InputTextHeight => 22;
        protected virtual int ButtonWidth => 170;
        protected virtual int ButtonHeight => 64;
        protected virtual int ButtonHorizontalMargin => 130;
        protected virtual int ButtonsTopOffsetFromLastInput => 65;
        protected virtual int ButtonsDefaultY => 470;

        private const float TitleFontSize = 27F;
        private const float InputFontSize = 14F;
        private const float ButtonFontSize = 14F;

        public BaseForm3()
        {
            InitializeComponent();

            DoubleBuffered = true;
            AutoScaleMode = AutoScaleMode.None;
            FormBorderStyle = FormBorderStyle.None;
            StartPosition = FormStartPosition.CenterScreen;

            BuildUi();

            Shown += (s, e) => LayoutAndRound();
            Resize += (s, e) => LayoutAndRound();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            using (var brush = new LinearGradientBrush(
                ClientRectangle,
                AppColors.MainGradientTop,
                AppColors.MainGradientBottom,
                LinearGradientMode.Vertical))
            {
                e.Graphics.FillRectangle(brush, ClientRectangle);
            }
        }

        protected virtual void BuildUi()
        {
            Card = new Panel
            {
                BackColor = Color.Transparent,
                Size = CardSize
            };
            Card.Paint += Card_Paint;
            Controls.Add(Card);

            TitleLabel = new Label
            {
                AutoSize = false,
                BackColor = Color.Transparent,
                ForeColor = AppColors.Text,
                Font = new Font("Century", TitleFontSize, FontStyle.Regular, GraphicsUnit.Point, 204),
                TextAlign = ContentAlignment.MiddleCenter,
                Text = TitleText
            };
            Card.Controls.Add(TitleLabel);

            BuildInputs();
            BuildButtons();
        }

        private void BuildInputs()
        {
            foreach (var placeholder in InputPlaceholders)
            {
                var panel = new Panel
                {
                    BackColor = Color.FromArgb(137, 101, 129)
                };

                var box = new TextBox
                {
                    BorderStyle = BorderStyle.None,
                    BackColor = Color.FromArgb(137, 101, 129),
                    ForeColor = AppColors.Placeholder,
                    Font = new Font("Century", InputFontSize, FontStyle.Regular, GraphicsUnit.Point, 204),
                    Text = placeholder
                };
                box.Enter += Input_Enter;
                box.Leave += Input_Leave;

                panel.Controls.Add(box);
                Card.Controls.Add(panel);
                InputPanels.Add(panel);
                InputBoxes.Add(box);
            }
        }

        private void BuildButtons()
        {
            CancelButton = CreateActionButton(CancelText);
            CancelButton.Click += (s, e) => Close();

            ActionButton = CreateActionButton(ActionText);
            ActionButton.Click += (s, e) => OnActionClicked();
        }

        private Button CreateActionButton(string text)
        {
            var button = new Button
            {
                Text = text,
                FlatStyle = FlatStyle.Flat,
                ForeColor = AppColors.Text,
                Font = new Font("Century", ButtonFontSize, FontStyle.Regular, GraphicsUnit.Point, 204),
                BackColor = Color.FromArgb(137, 101, 129)
            };
            button.FlatAppearance.BorderSize = 0;
            Card.Controls.Add(button);
            return button;
        }

        protected virtual void LayoutAndRound()
        {
            if (Card == null) return;

            Card.Location = new Point(
                (ClientSize.Width - Card.Width) / 2,
                (ClientSize.Height - Card.Height) / 2
            );

            TitleLabel.Location = new Point(TitleSideMargin, TitleTop);
            TitleLabel.Size = new Size(Card.Width - (TitleSideMargin * 2), TitleHeight);

            int inputX = (Card.Width - InputWidth) / 2;

            for (int i = 0; i < InputPanels.Count; i++)
            {
                var panel = InputPanels[i];
                var box = InputBoxes[i];
                panel.Location = new Point(inputX, FirstInputY + i * InputStepY);
                panel.Size = new Size(InputWidth, InputHeight);

                box.Location = new Point(InputTextLeft, InputTextTop);
                box.Size = new Size(InputWidth - (InputTextLeft * 2), InputTextHeight);

                RoundControl(panel, InputHeight);
            }

            int buttonsY = InputPanels.Any() ? InputPanels.Last().Bottom + ButtonsTopOffsetFromLastInput : ButtonsDefaultY;

            CancelButton.Size = new Size(ButtonWidth, ButtonHeight);
            CancelButton.Location = new Point(ButtonHorizontalMargin, buttonsY);

            ActionButton.Size = new Size(ButtonWidth, ButtonHeight);
            ActionButton.Location = new Point(Card.Width - ButtonHorizontalMargin - ButtonWidth, buttonsY);

            RoundControl(CancelButton, ButtonHeight);
            RoundControl(ActionButton, ButtonHeight);
            // card по макету без скругления — Region не задаём.

            Card.Invalidate();
        }

        private void Card_Paint(object sender, PaintEventArgs e)
        {
            var pnl = (Panel)sender;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            using (var brush = new LinearGradientBrush(
                pnl.ClientRectangle,
                AppColors.PanelTop,
                AppColors.PanelBottom,
                LinearGradientMode.Vertical))
            {
                e.Graphics.FillRectangle(brush, pnl.ClientRectangle);
            }

            using (var pen = new Pen(AppColors.Stroke, BorderThickness))
            {
                // Прямая рамка (как на макете). Отступ 1px, чтобы не обрезалась.
                e.Graphics.DrawRectangle(pen, 1, 1, pnl.Width - 2, pnl.Height - 2);
            }
        }

        private void Input_Enter(object sender, System.EventArgs e)
        {
            var box = (TextBox)sender;
            if (InputPlaceholders.Contains(box.Text))
            {
                box.Text = string.Empty;
                box.ForeColor = AppColors.Text;
            }
        }

        private void Input_Leave(object sender, System.EventArgs e)
        {
            var box = (TextBox)sender;
            if (!string.IsNullOrWhiteSpace(box.Text)) return;

            int idx = InputBoxes.IndexOf(box);
            if (idx < 0 || idx >= InputPlaceholders.Length) return;

            box.Text = InputPlaceholders[idx];
            box.ForeColor = AppColors.Placeholder;
        }

        protected static void RoundControl(Control c, int radius)
        {
            if (c == null || radius <= 0) return;

            using (var path = new GraphicsPath())
            {
                AddRoundedPath(path, c, radius);
                c.Region = new Region(path);
            }
        }

        protected static void AddRoundedPath(GraphicsPath path, Control control, int radius)
        {
            path.AddArc(0, 0, radius, radius, 180, 90);
            path.AddArc(control.Width - radius, 0, radius, radius, 270, 90);
            path.AddArc(control.Width - radius, control.Height - radius, radius, radius, 0, 90);
            path.AddArc(0, control.Height - radius, radius, radius, 90, 90);
            path.CloseFigure();
        }

        protected string[] GetInputValues()
        {
            var values = new string[InputBoxes.Count];
            for (int i = 0; i < InputBoxes.Count; i++)
            {
                var t = (InputBoxes[i].Text ?? string.Empty).Trim();
                if (i < InputPlaceholders.Length && t == (InputPlaceholders[i] ?? string.Empty))
                    t = string.Empty;
                values[i] = t;
            }
            return values;
        }

        protected virtual void OnActionClicked()
        {
            // Переопределяется в наследниках (5 форм), чтобы кнопки делали SQL.
        }
    }
}
