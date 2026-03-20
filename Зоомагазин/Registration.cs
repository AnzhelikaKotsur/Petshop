using Npgsql;
using Зоомагазин.Database;

namespace Зоомагазин
{
    public partial class Registration : Form
    {
        public Registration()
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.None;

            int radius = 50;
            if (panel2 != null)
            {
                using (var path = new System.Drawing.Drawing2D.GraphicsPath())
                {
                    path.AddArc(0, 0, radius, radius, 180, 90);
                    path.AddArc(panel2.Width - radius, 0, radius, radius, 270, 90);
                    path.AddArc(panel2.Width - radius, panel2.Height - radius, radius, radius, 0, 90);
                    path.AddArc(0, panel2.Height - radius, radius, radius, 90, 90);
                    path.CloseFigure();
                    panel2.Region = new Region(path);
                }

                panel2.Paint += panel2_Paint;
            }


            if (panel3 != null)
            {
                using (var path = new System.Drawing.Drawing2D.GraphicsPath())
                {
                    path.AddArc(0, 0, 50, 50, 180, 90);
                    path.AddArc(panel3.Width - 50, 0, 50, 50, 270, 90);
                    path.AddArc(panel3.Width - 50, panel3.Height - 50, 50, 50, 0, 90);
                    path.AddArc(0, panel3.Height - 50, 50, 50, 90, 90);
                    path.CloseFigure();
                    panel3.Region = new Region(path);
                }
            }

            if (panel4 != null)
            {
                using (var path = new System.Drawing.Drawing2D.GraphicsPath())
                {
                    path.AddArc(0, 0, 50, 50, 180, 90);
                    path.AddArc(panel4.Width - 50, 0, 50, 50, 270, 90);
                    path.AddArc(panel4.Width - 50, panel4.Height - 50, 50, 50, 0, 90);
                    path.AddArc(0, panel4.Height - 50, 50, 50, 90, 90);
                    path.CloseFigure();
                    panel4.Region = new Region(path);
                }
            }

            if (panel5 != null)
            {
                using (var path = new System.Drawing.Drawing2D.GraphicsPath())
                {
                    path.AddArc(0, 0, 50, 50, 180, 90);
                    path.AddArc(panel5.Width - 50, 0, 50, 50, 270, 90);
                    path.AddArc(panel5.Width - 50, panel5.Height - 50, 50, 50, 0, 90);
                    path.AddArc(0, panel5.Height - 50, 50, 50, 90, 90);
                    path.CloseFigure();
                    panel5.Region = new Region(path);
                }
            }

            if (panel6 != null)
            {
                using (var path = new System.Drawing.Drawing2D.GraphicsPath())
                {
                    path.AddArc(0, 0, 50, 50, 180, 90);
                    path.AddArc(panel6.Width - 50, 0, 50, 50, 270, 90);
                    path.AddArc(panel6.Width - 50, panel6.Height - 50, 50, 50, 0, 90);
                    path.AddArc(0, panel6.Height - 50, 50, 50, 90, 90);
                    path.CloseFigure();
                    panel6.Region = new Region(path);
                }
            }

            if (panel7 != null)
            {
                using (var path = new System.Drawing.Drawing2D.GraphicsPath())
                {
                    path.AddArc(0, 0, 50, 50, 180, 90);
                    path.AddArc(panel7.Width - 50, 0, 50, 50, 270, 90);
                    path.AddArc(panel7.Width - 50, panel7.Height - 50, 50, 50, 0, 90);
                    path.AddArc(0, panel7.Height - 50, 50, 50, 90, 90);
                    path.CloseFigure();
                    panel7.Region = new Region(path);
                }
            }

            if (Reg != null)
            {
                using (var path = new System.Drawing.Drawing2D.GraphicsPath())
                {
                    path.AddArc(0, 0, 95, 95, 180, 90);
                    path.AddArc(Reg.Width - 95, 0, 95, 95, 270, 90);
                    path.AddArc(Reg.Width - 95, Reg.Height - 95, 95, 95, 0, 90);
                    path.AddArc(0, Reg.Height - 95, 95, 95, 90, 90);
                    path.CloseFigure();
                    Reg.Region = new Region(path);
                }
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            using (var path = new System.Drawing.Drawing2D.GraphicsPath())
            {
                int radius = 50;
                path.AddArc(0, 0, radius, radius, 180, 90);
                path.AddArc(this.Width - radius, 0, radius, radius, 270, 90);
                path.AddArc(this.Width - radius, this.Height - radius, radius, radius, 0, 90);
                path.AddArc(0, this.Height - radius, radius, radius, 90, 90);
                path.CloseFigure();
                this.Region = new Region(path);
            }
        }


        protected override void OnPaint(PaintEventArgs E)
        {
            base.OnPaint(E);
            using (var brush = new System.Drawing.Drawing2D.LinearGradientBrush(
                this.ClientRectangle,
                Color.FromArgb(0x9C, 0x3B, 0x78),
                Color.FromArgb(0x20, 0x10, 0x29),
                System.Drawing.Drawing2D.LinearGradientMode.Vertical))
            {
                E.Graphics.FillRectangle(brush, this.ClientRectangle);
            }
        }

        private void Reg_Click(object sender, EventArgs e)
        {
            string FirstName = textBox5.Text.Trim();
            string Name = textBox4.Text.Trim();
            string SurName = textBox3.Text.Trim();
            string login = textBox2.Text.Trim();
            string password = textBox1.Text;
            string confirm = textBox6.Text;

            if (string.IsNullOrEmpty(FirstName) || string.IsNullOrEmpty(Name) ||
                string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Заполните все обязательные поля (Фамилия, Имя, Логин, Пароль)");
                return;
            }

            if (password != confirm)
            {
                MessageBox.Show("Пароли не совпадают");
                return;
            }

            try
            {
                using (var conn = Connection.GetConnection())
                {
                    conn.Open();

                    string checkQuery = "SELECT COUNT(*) FROM public.\"Users\" WHERE \"Username\" = @login";
                    using (var checkCmd = new NpgsqlCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@login", login);
                        long count = (long)checkCmd.ExecuteScalar();
                        if (count > 0)
                        {
                            MessageBox.Show("Пользователь с таким логином уже существует");
                            return;
                        }
                    }

                    string fullName = $"{FirstName} {Name} {SurName}".Trim();

                    string insertQuery = "INSERT INTO public.\"Users\" (\"Username\", \"PasswordHash\", \"Role\", \"FullName\") VALUES (@login, @password, 'Storekeeper', @fullName)";
                    using (var insertCmd = new NpgsqlCommand(insertQuery, conn))
                    {
                        insertCmd.Parameters.AddWithValue("@login", login);
                        insertCmd.Parameters.AddWithValue("@password", password);
                        insertCmd.Parameters.AddWithValue("@fullName", fullName);
                        insertCmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Регистрация успешна! Теперь войдите в систему.");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка базы данных" + ex.Message);
            }
        }

        private void lblAuth_Click(object sender, EventArgs e)
        {

        }

        private void txtFirstname_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblReg_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Registration_Load(object sender, EventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtSurname_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void linkAuth_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var auth = new LoginForm();
            auth.Show();
            this.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            var pnl = sender as Panel;
            if (pnl == null) return;

            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            using (var path = new System.Drawing.Drawing2D.GraphicsPath())
            {
                int radius = 100;

                path.AddArc(0, 0, radius, radius, 180, 90);
                path.AddArc(pnl.Width - radius, 0, radius, radius, 270, 90);
                path.AddArc(pnl.Width - radius, pnl.Height - radius, radius, radius, 0, 90);
                path.AddArc(0, pnl.Height - radius, radius, radius, 90, 90);
                path.CloseFigure();

                using (var brush = new System.Drawing.Drawing2D.LinearGradientBrush(
                    pnl.ClientRectangle,
                    Color.FromArgb(0x5D, 0x25, 0x50),
                    Color.FromArgb(0x5C, 0x24, 0x4F),
                    System.Drawing.Drawing2D.LinearGradientMode.Vertical))
                {
                    e.Graphics.FillPath(brush, path);
                }
            }
        }

        private void CloseB_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
