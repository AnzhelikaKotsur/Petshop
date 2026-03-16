namespace Зоомагазин
{
    partial class LoginForm
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
            Title.Font = new Font("Gabriela", 32F, FontStyle.Bold);
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
            lblLogin.Font = new Font("Gabriela", 10F);
            lblLogin.ForeColor = Color.White;
            lblLogin.Location = new Point(105, 215);
            lblLogin.Name = "lblLogin";
            lblLogin.Size = new Size(100, 20);
            lblLogin.TabIndex = 1;
            lblLogin.Text = "Логин";
            lblLogin.Click += lblLogin_Click;
            // 
            // txtLogin
            // 
            txtLogin.BackColor = Color.FromArgb(137, 101, 129);
            txtLogin.ForeColor = Color.FromArgb(164, 139, 160);
            txtLogin.Location = new Point(181, 238);
            txtLogin.Name = "txtLogin";
            txtLogin.Size = new Size(100, 29);
            txtLogin.TabIndex = 2;
            txtLogin.Text = "Введите логин";
            // 
            // lblPass
            // 
            lblPass.Font = new Font("Gabriela", 10F);
            lblPass.ForeColor = Color.White;
            lblPass.Location = new Point(105, 343);
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
            btnLogin.Font = new Font("Gabriela", 20F);
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
            Register.ActiveLinkColor = Color.Maroon;
            Register.LinkBehavior = LinkBehavior.NeverUnderline;
            Register.LinkColor = Color.White;
            Register.Location = new Point(290, 575);
            Register.Name = "Register";
            Register.Size = new Size(197, 20);
            Register.TabIndex = 6;
            Register.TabStop = true;
            Register.Text = "Зарегистрироваться?";
            Register.LinkClicked += Register_LinkClicked;
            // 
            // CloseB
            // 
            CloseB.Location = new Point(1534, 12);
            CloseB.Name = "CloseB";
            CloseB.Size = new Size(36, 31);
            CloseB.TabIndex = 7;
            CloseB.Text = "X";
            CloseB.UseVisualStyleBackColor = true;
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
            panel1.Font = new Font("Gabriela", 10F);
            panel1.Location = new Point(494, 126);
            panel1.Name = "panel1";
            panel1.Size = new Size(610, 820);
            panel1.TabIndex = 8;
            panel1.Paint += Panel1_Paint;
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
            lblNoAccount.Font = new Font("Gabriela", 10F);
            lblNoAccount.Location = new Point(159, 573);
            lblNoAccount.Name = "lblNoAccount";
            lblNoAccount.Size = new Size(136, 26);
            lblNoAccount.TabIndex = 9;
            lblNoAccount.Text = "Нет аккаунта?";
            lblNoAccount.ForeColor = Color.FromArgb(0xA7, 0x8F, 0xA3);
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
            txtPassword.Font = new Font("Gabriela", 16F);
            txtPassword.ForeColor = Color.FromArgb(164, 139, 160);
            txtPassword.Location = new Point(181, 298);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(100, 42);
            txtPassword.TabIndex = 4;
            txtPassword.Text = "Введите пароль";
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