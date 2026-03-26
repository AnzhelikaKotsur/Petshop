using PetShopApp.Database;
using PetShopApp.MainForms;
using PetShopApp.Models;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace PetShopApp
{
    public partial class Login : BaseForm1
    {
        public Login()
        {
            InitializeComponent();

            txtLogin.Text = "Введите логин";
            txtLogin.ForeColor = Color.FromArgb(164, 139, 160);

            txtPassword.Text = "Введите пароль";
            txtPassword.ForeColor = Color.FromArgb(164, 139, 160);
            txtPassword.PasswordChar = '\0';

            txtLogin.Enter += txtLogin_Enter;
            txtLogin.Leave += txtLogin_Leave;

            txtPassword.Enter += txtPassword_Enter;
            txtPassword.Leave += txtPassword_Leave;

            var path = new GraphicsPath();
            Arcs(path, pnlLogin, 50);

            Arcs(path, pnlPassword, 50);

            Arcs(path, btnLogin, 95);

        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            var login = NormalizeInput(txtLogin.Text, "Введите логин");
            var password = NormalizeInput(txtPassword.Text, "Введите пароль");

            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Введите логин и пароль");
                return;
            }

            try
            {
                using (var db = new PetShopContext())
                {
                    var user = db.Users.FirstOrDefault(u => u.Username == login && u.PasswordHash == password);

                    if (user != null)
                    {
                        CurrentUser.Id = user.Id;
                        CurrentUser.Username = user.Username;
                        CurrentUser.Role = password.StartsWith("admin", StringComparison.OrdinalIgnoreCase)
                            ? "Admin"
                            : "Storekeeper";
                        MessageBox.Show($"Здравствуйте, {CurrentUser.Username}!");

                        Form main = CurrentUser.Role == "Admin"
                            ? (Form)new AdminMainForm()
                            : new StorekeeperMainForm();

                        Hide();
                        main.ShowDialog();
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("Неверный логин или пароль");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка базы данных: " + ex.Message);
            }
        }

        private void txtLogin_Enter(object sender, EventArgs e)
        {
            if (txtLogin.Text == "Введите логин")
            {
                txtLogin.Text = "";
                txtLogin.ForeColor = Color.White;
            }
        }

        private void txtLogin_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtLogin.Text))
            {
                txtLogin.Text = "Введите логин";
                txtLogin.ForeColor = Color.FromArgb(164, 139, 160);
            }
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            if (txtPassword.Text == "Введите пароль")
            {
                txtPassword.Text = "";
                txtPassword.ForeColor = Color.White;
                txtPassword.PasswordChar = '*';
            }
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                txtPassword.PasswordChar = '\0';
                txtPassword.Text = "Введите пароль";
                txtPassword.ForeColor = Color.FromArgb(164, 139, 160);
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
            var reg = new Registration();
            reg.Show();
            this.Hide();
        }

        private static string NormalizeInput(string value, string placeholder)
        {
            if (string.IsNullOrWhiteSpace(value))
                return string.Empty;

            var trimmed = value.Trim();
            return string.Equals(trimmed, placeholder, StringComparison.OrdinalIgnoreCase)
                ? string.Empty
                : trimmed;
        }
    }
}
