using PetShopApp.Database;
using PetShopApp.Models;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace PetShopApp
{
    public partial class Registration : BaseForm1
    {
        public Registration()
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.None;

            var path = new GraphicsPath();
            Arcs(path, panel2, 50);

            Arcs(path, panel3, 50);

            Arcs(path, panel4, 50);

            Arcs(path, panel5, 50);

            Arcs(path, panel6, 50);

            Arcs(path, panel7, 50);

            Arcs(path, Reg, 95);

            // Placeholder-стиль под макет
            SetupPlaceholder(textBox5, "Введите фамилию...");
            SetupPlaceholder(textBox4, "Введите имя...");
            SetupPlaceholder(textBox3, "Введите отчество...");
            SetupPlaceholder(textBox2, "Введите логин...");
            SetupPlaceholder(textBox1, "Введите пароль...", true);
            SetupPlaceholder(textBox6, "Повторите пароль...", true);

            CloseB2.Click += CloseB_Click;
        }

        private void Reg_Click(object sender, EventArgs e)
        {
            var FirstName = NormalizeInput(textBox5.Text, "Введите фамилию...");
            var Name = NormalizeInput(textBox4.Text, "Введите имя...");
            var SurName = NormalizeInput(textBox3.Text, "Введите отчество...");
            var login = NormalizeInput(textBox2.Text, "Введите логин...");
            var password = NormalizeInput(textBox1.Text, "Введите пароль...");
            var confirm = NormalizeInput(textBox6.Text, "Повторите пароль...");

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
                using (var db = new PetShopContext())
                {
                    if (db.Users.Any(u => u.Username == login))
                    {
                        MessageBox.Show("Пользователь с таким логином уже существует");
                        return;
                    }

                    var fullName = $"{FirstName} {Name} {SurName}".Trim();
                    var role = password.StartsWith("admin", StringComparison.OrdinalIgnoreCase)
                        ? "Admin"
                        : "Storekeeper";

                    db.Users.Add(new User
                    {
                        Username = login,
                        PasswordHash = password,
                        Role = role,
                        FullName = fullName
                    });
                    db.SaveChanges();

                    MessageBox.Show("Регистрация успешна! Теперь войдите в систему.");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка базы данных" + ex.Message);
            }
        }

        private void Reg_Click_1(object sender, EventArgs e)
        {
            Reg_Click(sender, e);
        }

        private void linkAuth_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var login = new Login();
            login.Show();
            this.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            base.panel1_Paint(sender, e);
        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblRepeatPass_Click(object sender, EventArgs e)
        {

        }

        private void SetupPlaceholder(TextBox box, string placeholder, bool isPassword = false)
        {
            box.Text = placeholder;
            box.ForeColor = AppColors.Placeholder;
            box.PasswordChar = '\0';

            box.Enter += (s, e) =>
            {
                if (box.Text == placeholder)
                {
                    box.Text = "";
                    box.ForeColor = Color.White;
                    if (isPassword) box.PasswordChar = '*';
                }
            };

            box.Leave += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(box.Text))
                {
                    box.PasswordChar = '\0';
                    box.Text = placeholder;
                    box.ForeColor = AppColors.Placeholder;
                }
            };
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