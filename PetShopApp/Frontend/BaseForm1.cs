using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace PetShopApp
{
    /// <summary>
    /// шаблон макета для форм авторизации
    /// </summary>
    public partial class BaseForm1 : Form
    {
        protected override void OnPaint(PaintEventArgs E)
        {
            base.OnPaint(E);
            Gradient(this, AppColors.MainGradientTop, AppColors.MainGradientBottom, E);
        }

        public void panel1_Paint(object sender, PaintEventArgs e)
        {
            Panel pnl = sender as Panel;
            if (pnl == null) return;

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            Gradient(pnl, AppColors.PanelTop, AppColors.PanelBottom, e);

            using (var pen = new Pen(AppColors.Stroke, 2))
            {
                e.Graphics.DrawRectangle(pen, 1, 1, pnl.Width - 2, pnl.Height - 2);
            }
        }
        public void CloseB_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void Arcs(GraphicsPath path, Control panel, int radius)
        {
            path.Reset();
            path.AddArc(0, 0, radius, radius, 180, 90);
            path.AddArc(panel.Width - radius, 0, radius, radius, 270, 90);
            path.AddArc(panel.Width - radius, panel.Height - radius, radius, radius, 0, 90);
            path.AddArc(0, panel.Height - radius, radius, radius, 90, 90);
            path.CloseFigure();
            panel.Region = new Region(path);
        }

        public void Gradient(Control panel, Color Top, Color Bottom, PaintEventArgs e)
        {
            using (var brush = new LinearGradientBrush(
                panel.ClientRectangle,
                Top,
                Bottom,
                LinearGradientMode.Vertical))
            {
                e.Graphics.FillRectangle(brush, panel.ClientRectangle);
            }
        }
    }
}