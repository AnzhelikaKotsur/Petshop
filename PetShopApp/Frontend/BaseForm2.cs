using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using PetShopApp.Properties;

namespace PetShopApp.Frontend
{
    public partial class BaseForm2 : Form
    {
        protected Panel Card;
        protected Label TitleLabel;
        protected Label SubtitleLabel;
        protected Button ExitButton;

        protected virtual string TitleText => Resources.ResourceManager.GetString("Common_ErrorTitle") ?? "Ошибка";
        protected virtual string SubtitleText => "";
        protected virtual string ExitText => Resources.ResourceManager.GetString("Common_Exit") ?? "Выход";

        protected virtual Size CardSize => new Size(1258, 838);
        protected virtual int CardRadius => 0;
        protected virtual int BorderThickness => 2;

        private const float TitleFontSize = 27F;
        private const float SubtitleFontSize = 13.5F;
        private const float ExitButtonFontSize = 15.2F;

        protected BaseForm2()
        {
            InitializeComponent();

            DoubleBuffered = true;
            AutoScaleMode = AutoScaleMode.None;
            FormBorderStyle = FormBorderStyle.None;
            StartPosition = FormStartPosition.CenterScreen;

            BuildBaseErrorUi();

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

        protected virtual void BuildBaseErrorUi()
        {
            Card = new Panel();
            Card.BackColor = Color.Transparent;
            Card.Size = CardSize;
            Card.Paint += Card_Paint;
            Controls.Add(Card);

            int marginX = (int)(Card.Width * (40f / 700f));
            int titleY = (int)(Card.Height * (150f / 520f));
            int subtitleY = (int)(Card.Height * (235f / 520f));
            int exitY = (int)(Card.Height * (330f / 520f));

            int titleH = (int)(Card.Height * (70f / 520f));
            int subtitleH = (int)(Card.Height * (30f / 520f));

            int exitW = (int)(190f * (Card.Width / 700f));
            int exitH = (int)(56f * (Card.Height / 520f));

            TitleLabel = new Label();
            TitleLabel.AutoSize = false;
            TitleLabel.BackColor = Color.Transparent;
            TitleLabel.Font = new Font("Century", TitleFontSize, FontStyle.Regular, GraphicsUnit.Point, 204);
            TitleLabel.ForeColor = AppColors.Text;
            TitleLabel.TextAlign = ContentAlignment.MiddleCenter;
            TitleLabel.Text = TitleText;
            TitleLabel.Location = new Point(marginX, titleY);
            TitleLabel.Size = new Size(Card.Width - marginX * 2, titleH);

            SubtitleLabel = new Label();
            SubtitleLabel.AutoSize = false;
            SubtitleLabel.BackColor = Color.Transparent;
            SubtitleLabel.Font = new Font("Century", SubtitleFontSize, FontStyle.Regular, GraphicsUnit.Point, 204);
            SubtitleLabel.ForeColor = AppColors.Placeholder;
            SubtitleLabel.TextAlign = ContentAlignment.MiddleCenter;
            SubtitleLabel.Text = SubtitleText;
            SubtitleLabel.Location = new Point(marginX, subtitleY);
            SubtitleLabel.Size = new Size(Card.Width - marginX * 2, subtitleH);

            ExitButton = new Button();
            ExitButton.Text = ExitText;
            ExitButton.FlatStyle = FlatStyle.Flat;
            ExitButton.FlatAppearance.BorderSize = 0;
            ExitButton.Font = new Font("Century", ExitButtonFontSize, FontStyle.Regular, GraphicsUnit.Point, 204);
            ExitButton.ForeColor = AppColors.Text;
            ExitButton.BackColor = Color.FromArgb(137, 101, 129);
            ExitButton.Size = new Size(exitW, exitH);
            ExitButton.Location = new Point((Card.Width - exitW) / 2, exitY);
            ExitButton.Cursor = Cursors.Hand;
            ExitButton.Click += (s, e) => Close();

            Card.Controls.Add(TitleLabel);
            Card.Controls.Add(SubtitleLabel);
            Card.Controls.Add(ExitButton);
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
                if (CardRadius > 0)
                {
                    using (var path = new GraphicsPath())
                    {
                        AddRoundedPath(path, pnl, CardRadius);
                        e.Graphics.DrawPath(pen, path);
                    }
                }
                else
                {
                    e.Graphics.DrawRectangle(pen, 1, 1, pnl.Width - 2, pnl.Height - 2);
                }
            }
        }

        protected virtual void LayoutAndRound()
        {
            if (Card == null) return;

            Card.Location = new Point(
                (ClientSize.Width - Card.Width) / 2,
                (ClientSize.Height - Card.Height) / 2
            );

            RoundControl(Card, CardRadius);
            if (ExitButton != null) RoundControl(ExitButton, ExitButton.Height);

            Card.Invalidate();
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
    }
}