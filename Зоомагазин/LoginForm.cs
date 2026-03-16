using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Зоомагазин.Database;
using Зоомагазин.Models;
using System.Drawing.Drawing2D;

namespace Зоомагазин
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();

            int radius = 100;
            if (panel1 != null)
            {
                using (var path = new System.Drawing.Drawing2D.GraphicsPath())
                {
                    path.AddArc(0, 0, radius, radius, 180, 90);
                    path.AddArc(panel1.Width - radius, 0, radius, radius, 270, 90);
                    path.AddArc(panel1.Width - radius, panel1.Height - radius, radius, radius, 0, 90);
                    path.AddArc(0, panel1.Height - radius, radius, radius, 90, 90);
                    path.CloseFigure();
                    panel1.Region = new Region(path);
                }

                panel1.Paint += Panel1_Paint;
            }


            if (pnlLogin != null)
            {
                using (var path = new System.Drawing.Drawing2D.GraphicsPath())
                {
                    path.AddArc(0, 0, 50, 50, 180, 90);
                    path.AddArc(pnlLogin.Width - 50, 0, 50, 50, 270, 90);
                    path.AddArc(pnlLogin.Width - 50, pnlLogin.Height - 50, 50, 50, 0, 90);
                    path.AddArc(0, pnlLogin.Height - 50, 50, 50, 90, 90);
                    path.CloseFigure();
                    pnlLogin.Region = new Region(path);
                }
            }

            if (pnlPassword != null)
            {
                using (var path = new System.Drawing.Drawing2D.GraphicsPath())
                {
                    path.AddArc(0, 0, 50, 50, 180, 90);
                    path.AddArc(pnlPassword.Width - 50, 0, 50, 50, 270, 90);
                    path.AddArc(pnlPassword.Width - 50, pnlPassword.Height - 50, 50, 50, 0, 90);
                    path.AddArc(0, pnlPassword.Height - 50, 50, 50, 90, 90);
                    path.CloseFigure();
                    pnlPassword.Region = new Region(path);
                }
            }

            if (btnLogin != null)
            {
                using (var path = new System.Drawing.Drawing2D.GraphicsPath())
                {
                    path.AddArc(0, 0, 95, 95, 180, 90);
                    path.AddArc(btnLogin.Width - 95, 0, 95, 95, 270, 90);
                    path.AddArc(btnLogin.Width - 95, btnLogin.Height - 95, 95, 95, 0, 90);
                    path.AddArc(0, btnLogin.Height - 95, 95, 95, 90, 90);
                    path.CloseFigure();
                    btnLogin.Region = new Region(path);
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

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {
            Panel pnl = sender as Panel;
            if (pnl == null) return;

            using (var brush = new System.Drawing.Drawing2D.LinearGradientBrush(
                pnl.ClientRectangle,
                Color.FromArgb(0x5D, 0x25, 0x50),
                Color.FromArgb(0x5C, 0x24, 0x4F),
                System.Drawing.Drawing2D.LinearGradientMode.Vertical))
            {
                e.Graphics.FillRectangle(brush, pnl.ClientRectangle);
            }
        }

        private void CloseB_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string login = txtLogin.Text;
            string password = txtPassword.Text;

            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Введите логин и пароль");
                return;
            }

            try
            {
                using (var conn = Connection.GetConnection())
                {
                    conn.Open();

                    string query = "SELECT * FROM public.\"Users\" WHERE \"Username\" = '" + login + "' AND \"PasswordHash\" = '" + password + "'";

                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                CurrentUser.Id = Convert.ToInt32(reader["Id"]);
                                CurrentUser.Username = reader["Username"].ToString();
                                CurrentUser.Role = reader["Role"].ToString();
                                MessageBox.Show($"Здравствуйте, {CurrentUser.Username}!");
                                this.Hide();
                            }
                            else
                            {
                                MessageBox.Show("Неверный логин или пароль");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка базы данных: " + ex.Message);
            }
        }

        private void lblLogin_Click(object sender, EventArgs e)
        {

        }

        private void Title_Click(object sender, EventArgs e)
        {

        }

        private void Register_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }
    }


}
