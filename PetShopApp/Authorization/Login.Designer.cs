using System.Drawing;
using System.Windows.Forms;

namespace PetShopApp
{
    partial class Login
    {
        private Label Title;
        private Label lblLogin;
        private TextBox txtLogin;
        private Label lblPass;
        private Button btnLogin;
        private LinkLabel Register;
        private Panel Auth;
        private Button CloseB;
        private Panel panel1;

        private void InitializeComponent()
        {
            Title = new Label();
            lblLogin = new Label();
            txtLogin = new TextBox();
            lblPass = new Label();
            btnLogin = new Button();
            Register = new LinkLabel();
            CloseB = new Button();
            panel1 = new Panel();
            pnlLogin = new Panel();
            lblNoAccount = new Label();
            pnlPassword = new Panel();
            txtPassword = new TextBox();
            panel1.SuspendLayout();
            pnlLogin.SuspendLayout();
            pnlPassword.SuspendLayout();
            SuspendLayout();
            // 
            // Title
            // 
            Title.Font = new Font("Century", 31.8000011F, FontStyle.Bold, GraphicsUnit.Point, 204);
            Title.ForeColor = Color.White;
            Title.Location = new Point(105, 75);
            Title.Name = "Title";
            Title.Size = new Size(407, 96);
            Title.TabIndex = 0;
            Title.Text = "Авторизация";
            Title.TextAlign = ContentAlignment.MiddleCenter;
            Title.Click += Title_Click;
            // 
            // lblLogin
            // 
            lblLogin.Font = new Font("Century", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblLogin.ForeColor = Color.White;
            lblLogin.Location = new Point(124, 215);
            lblLogin.Name = "lblLogin";
            lblLogin.Size = new Size(66, 20);
            lblLogin.TabIndex = 1;
            lblLogin.Text = "Логин";
            lblLogin.Click += lblLogin_Click;
            // 
            // txtLogin
            // 
            txtLogin.BackColor = Color.FromArgb(137, 101, 129);
            txtLogin.BorderStyle = BorderStyle.None;
            txtLogin.Font = new Font("Century", 14F);
            txtLogin.ForeColor = Color.FromArgb(164, 139, 160);
            txtLogin.Location = new Point(15, 8);
            txtLogin.Name = "txtLogin";
            txtLogin.Size = new Size(390, 30);
            txtLogin.TabIndex = 2;
            // 
            // lblPass
            // 
            lblPass.Font = new Font("Century", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblPass.ForeColor = Color.White;
            lblPass.Location = new Point(124, 340);
            lblPass.Name = "lblPass";
            lblPass.Size = new Size(100, 20);
            lblPass.TabIndex = 3;
            lblPass.Text = "Пароль";
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.FromArgb(137, 101, 129);
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Century", 20F);
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(159, 476);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(300, 95);
            btnLogin.TabIndex = 5;
            btnLogin.Text = "Войти";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // Register
            // 
            Register.ActiveLinkColor = Color.FromArgb(192, 0, 192);
            Register.Font = new Font("Century", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            Register.LinkBehavior = LinkBehavior.NeverUnderline;
            Register.LinkColor = Color.White;
            Register.Location = new Point(290, 575);
            Register.Name = "Register";
            Register.Size = new Size(215, 20);
            Register.TabIndex = 6;
            Register.TabStop = true;
            Register.Text = "Зарегистрироваться";
            Register.LinkClicked += Register_LinkClicked;
            // 
            // CloseB
            // 
            CloseB.BackColor = Color.FromArgb(167, 143, 163);
            CloseB.FlatStyle = FlatStyle.Flat;
            CloseB.Font = new Font("Century", 18F, FontStyle.Regular, GraphicsUnit.Point, 204);
            CloseB.ForeColor = Color.White;
            CloseB.Location = new Point(1052, 126);
            CloseB.Name = "CloseB";
            CloseB.Size = new Size(52, 52);
            CloseB.TabIndex = 7;
            CloseB.Text = "X";
            CloseB.UseVisualStyleBackColor = false;
            CloseB.Click += CloseB_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Transparent;
            panel1.Controls.Add(pnlLogin);
            panel1.Controls.Add(Register);
            panel1.Controls.Add(lblNoAccount);
            panel1.Controls.Add(pnlPassword);
            panel1.Controls.Add(Title);
            panel1.Controls.Add(btnLogin);
            panel1.Controls.Add(lblLogin);
            panel1.Controls.Add(lblPass);
            panel1.Font = new Font("Century", 10F);
            panel1.Location = new Point(494, 126);
            panel1.Name = "panel1";
            panel1.Size = new Size(610, 820);
            panel1.TabIndex = 8;
            panel1.Paint += panel1_Paint;
            // 
            // pnlLogin
            // 
            pnlLogin.BackColor = Color.FromArgb(137, 101, 129);
            pnlLogin.Controls.Add(txtLogin);
            pnlLogin.Location = new Point(100, 238);
            pnlLogin.Name = "pnlLogin";
            pnlLogin.Size = new Size(422, 47);
            pnlLogin.TabIndex = 0;
            // 
            // lblNoAccount
            // 
            lblNoAccount.Font = new Font("Century", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblNoAccount.ForeColor = Color.FromArgb(167, 143, 163);
            lblNoAccount.Location = new Point(159, 573);
            lblNoAccount.Name = "lblNoAccount";
            lblNoAccount.Size = new Size(136, 26);
            lblNoAccount.TabIndex = 9;
            lblNoAccount.Text = "Нет аккаунта?";
            lblNoAccount.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlPassword
            // 
            pnlPassword.BackColor = Color.FromArgb(137, 101, 129);
            pnlPassword.Controls.Add(txtPassword);
            pnlPassword.Location = new Point(100, 363);
            pnlPassword.Name = "pnlPassword";
            pnlPassword.Size = new Size(422, 47);
            pnlPassword.TabIndex = 1;
            // 
            // txtPassword
            // 
            txtPassword.BackColor = Color.FromArgb(137, 101, 129);
            txtPassword.BorderStyle = BorderStyle.None;
            txtPassword.Font = new Font("Century", 14F);
            txtPassword.ForeColor = Color.FromArgb(164, 139, 160);
            txtPassword.Location = new Point(15, 8);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(390, 30);
            txtPassword.TabIndex = 4;
            // 
            // LoginForm
            // 
            ClientSize = new Size(1600, 1102);
            Controls.Add(panel1);
            Controls.Add(CloseB);
            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Вход";
            panel1.ResumeLayout(false);
            pnlLogin.ResumeLayout(false);
            pnlLogin.PerformLayout();
            pnlPassword.ResumeLayout(false);
            pnlPassword.PerformLayout();
            ResumeLayout(false);
        }
        private Panel pnlLogin;
        private Panel pnlPassword;
        private TextBox txtPassword;
        private Label lblNoAccount;
    }
}