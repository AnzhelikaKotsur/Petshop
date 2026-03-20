using Microsoft.Win32;

namespace Зоомагазин
{
    partial class Registration
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblLog = new Label();
            lblSurname = new Label();
            lblPass = new Label();
            lblName = new Label();
            lblRepeatPass = new Label();
            Reg = new Button();
            lblFirstname = new Label();
            linkAuth = new LinkLabel();
            lblReg = new Label();
            panel7 = new Panel();
            textBox6 = new TextBox();
            lblAuth = new Label();
            panel6 = new Panel();
            textBox1 = new TextBox();
            panel5 = new Panel();
            textBox2 = new TextBox();
            panel4 = new Panel();
            textBox3 = new TextBox();
            panel2 = new Panel();
            textBox5 = new TextBox();
            panel3 = new Panel();
            textBox4 = new TextBox();
            panel1 = new Panel();
            CloseB = new Button();
            panel7.SuspendLayout();
            panel6.SuspendLayout();
            panel5.SuspendLayout();
            panel4.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // lblLog
            // 
            lblLog.AutoSize = true;
            lblLog.BackColor = Color.Transparent;
            lblLog.Font = new Font("Century", 10.2F);
            lblLog.ForeColor = Color.White;
            lblLog.Location = new Point(95, 357);
            lblLog.Name = "lblLog";
            lblLog.Size = new Size(63, 21);
            lblLog.TabIndex = 4;
            lblLog.Text = "Логин";
            // 
            // lblSurname
            // 
            lblSurname.AutoSize = true;
            lblSurname.BackColor = Color.Transparent;
            lblSurname.Font = new Font("Century", 10.2F);
            lblSurname.ForeColor = Color.White;
            lblSurname.Location = new Point(95, 277);
            lblSurname.Name = "lblSurname";
            lblSurname.Size = new Size(84, 21);
            lblSurname.TabIndex = 3;
            lblSurname.Text = "Отчество";
            // 
            // lblPass
            // 
            lblPass.AutoSize = true;
            lblPass.BackColor = Color.Transparent;
            lblPass.Font = new Font("Century", 10.2F);
            lblPass.ForeColor = Color.White;
            lblPass.Location = new Point(95, 441);
            lblPass.Name = "lblPass";
            lblPass.Size = new Size(71, 21);
            lblPass.TabIndex = 5;
            lblPass.Text = "Пароль";
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.BackColor = Color.Transparent;
            lblName.Font = new Font("Century", 10.2F);
            lblName.ForeColor = Color.White;
            lblName.Location = new Point(94, 196);
            lblName.Name = "lblName";
            lblName.Size = new Size(46, 21);
            lblName.TabIndex = 2;
            lblName.Text = "Имя";
            // 
            // lblRepeatPass
            // 
            lblRepeatPass.AutoSize = true;
            lblRepeatPass.BackColor = Color.Transparent;
            lblRepeatPass.Font = new Font("Century", 10.2F);
            lblRepeatPass.ForeColor = Color.White;
            lblRepeatPass.Location = new Point(95, 525);
            lblRepeatPass.Name = "lblRepeatPass";
            lblRepeatPass.Size = new Size(206, 21);
            lblRepeatPass.TabIndex = 12;
            lblRepeatPass.Text = "Подтверждение пароля";
            // 
            // Reg
            // 
            Reg.BackColor = Color.FromArgb(137, 101, 129);
            Reg.FlatStyle = FlatStyle.Flat;
            Reg.Font = new Font("Century", 15F);
            Reg.ForeColor = Color.White;
            Reg.Location = new Point(153, 623);
            Reg.Name = "Reg";
            Reg.Size = new Size(300, 101);
            Reg.TabIndex = 0;
            Reg.Text = "Зарегистрироваться";
            Reg.UseVisualStyleBackColor = false;
            Reg.Click += Reg_Click;
            // 
            // lblFirstname
            // 
            lblFirstname.AutoSize = true;
            lblFirstname.BackColor = Color.Transparent;
            lblFirstname.Font = new Font("Century", 10.2F);
            lblFirstname.ForeColor = Color.White;
            lblFirstname.Location = new Point(95, 118);
            lblFirstname.Name = "lblFirstname";
            lblFirstname.Size = new Size(88, 21);
            lblFirstname.TabIndex = 1;
            lblFirstname.Text = "Фамилия";
            // 
            // linkAuth
            // 
            linkAuth.ActiveLinkColor = Color.FromArgb(167, 143, 163);
            linkAuth.AutoSize = true;
            linkAuth.Font = new Font("Century", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            linkAuth.LinkBehavior = LinkBehavior.NeverUnderline;
            linkAuth.LinkColor = Color.White;
            linkAuth.Location = new Point(348, 727);
            linkAuth.Name = "linkAuth";
            linkAuth.Size = new Size(52, 18);
            linkAuth.TabIndex = 6;
            linkAuth.TabStop = true;
            linkAuth.Text = "Войти";
            linkAuth.TextAlign = ContentAlignment.MiddleCenter;
            linkAuth.LinkClicked += linkAuth_LinkClicked;
            // 
            // lblReg
            // 
            lblReg.AutoSize = true;
            lblReg.BackColor = Color.Transparent;
            lblReg.Font = new Font("Century", 31.8000011F, FontStyle.Bold);
            lblReg.ForeColor = Color.White;
            lblReg.Location = new Point(121, 39);
            lblReg.Name = "lblReg";
            lblReg.Size = new Size(368, 64);
            lblReg.TabIndex = 15;
            lblReg.Text = "Регистрация";
            lblReg.Click += lblReg_Click;
            // 
            // panel7
            // 
            panel7.BackColor = Color.FromArgb(137, 101, 129);
            panel7.Controls.Add(textBox6);
            panel7.Location = new Point(93, 548);
            panel7.Name = "panel7";
            panel7.Size = new Size(422, 47);
            panel7.TabIndex = 17;
            // 
            // textBox6
            // 
            textBox6.BackColor = Color.FromArgb(137, 101, 129);
            textBox6.BorderStyle = BorderStyle.None;
            textBox6.Location = new Point(21, 15);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(383, 20);
            textBox6.TabIndex = 13;
            textBox6.TextChanged += textBox6_TextChanged;
            // 
            // lblAuth
            // 
            lblAuth.AutoSize = true;
            lblAuth.BackColor = Color.Transparent;
            lblAuth.Font = new Font("Century", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblAuth.ForeColor = Color.FromArgb(167, 143, 163);
            lblAuth.Location = new Point(204, 727);
            lblAuth.Name = "lblAuth";
            lblAuth.Size = new Size(142, 18);
            lblAuth.TabIndex = 14;
            lblAuth.Text = "Уже есть аккаунт?";
            lblAuth.Click += lblAuth_Click;
            // 
            // panel6
            // 
            panel6.BackColor = Color.FromArgb(137, 101, 129);
            panel6.Controls.Add(textBox1);
            panel6.Location = new Point(91, 464);
            panel6.Name = "panel6";
            panel6.Size = new Size(422, 47);
            panel6.TabIndex = 17;
            panel6.Paint += panel6_Paint;
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.FromArgb(137, 101, 129);
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Location = new Point(20, 13);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(383, 20);
            textBox1.TabIndex = 14;
            // 
            // panel5
            // 
            panel5.BackColor = Color.FromArgb(137, 101, 129);
            panel5.Controls.Add(textBox2);
            panel5.Location = new Point(91, 380);
            panel5.Name = "panel5";
            panel5.Size = new Size(422, 47);
            panel5.TabIndex = 17;
            // 
            // textBox2
            // 
            textBox2.BackColor = Color.FromArgb(137, 101, 129);
            textBox2.BorderStyle = BorderStyle.None;
            textBox2.Location = new Point(20, 13);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(383, 20);
            textBox2.TabIndex = 14;
            // 
            // panel4
            // 
            panel4.BackColor = Color.FromArgb(137, 101, 129);
            panel4.Controls.Add(textBox3);
            panel4.Location = new Point(91, 300);
            panel4.Name = "panel4";
            panel4.Size = new Size(422, 47);
            panel4.TabIndex = 17;
            // 
            // textBox3
            // 
            textBox3.BackColor = Color.FromArgb(137, 101, 129);
            textBox3.BorderStyle = BorderStyle.None;
            textBox3.Location = new Point(20, 13);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(383, 20);
            textBox3.TabIndex = 14;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(137, 101, 129);
            panel2.Controls.Add(textBox5);
            panel2.Location = new Point(92, 141);
            panel2.Name = "panel2";
            panel2.Size = new Size(422, 47);
            panel2.TabIndex = 16;
            panel2.Paint += panel2_Paint;
            // 
            // textBox5
            // 
            textBox5.BackColor = Color.FromArgb(137, 101, 129);
            textBox5.BorderStyle = BorderStyle.None;
            textBox5.Location = new Point(20, 14);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(383, 20);
            textBox5.TabIndex = 14;
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(137, 101, 129);
            panel3.Controls.Add(textBox4);
            panel3.Location = new Point(91, 219);
            panel3.Name = "panel3";
            panel3.Size = new Size(422, 47);
            panel3.TabIndex = 17;
            // 
            // textBox4
            // 
            textBox4.BackColor = Color.FromArgb(137, 101, 129);
            textBox4.BorderStyle = BorderStyle.None;
            textBox4.Location = new Point(21, 14);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(383, 20);
            textBox4.TabIndex = 14;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Transparent;
            panel1.Controls.Add(lblAuth);
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(panel4);
            panel1.Controls.Add(panel5);
            panel1.Controls.Add(panel6);
            panel1.Controls.Add(panel7);
            panel1.Controls.Add(lblReg);
            panel1.Controls.Add(linkAuth);
            panel1.Controls.Add(lblFirstname);
            panel1.Controls.Add(Reg);
            panel1.Controls.Add(lblRepeatPass);
            panel1.Controls.Add(lblName);
            panel1.Controls.Add(lblPass);
            panel1.Controls.Add(lblSurname);
            panel1.Controls.Add(lblLog);
            panel1.Location = new Point(510, 126);
            panel1.Name = "panel1";
            panel1.Size = new Size(610, 820);
            panel1.TabIndex = 16;
            panel1.Paint += panel1_Paint;
            // 
            // CloseB
            // 
            CloseB.Location = new Point(1534, 12);
            CloseB.Name = "CloseB";
            CloseB.Size = new Size(36, 31);
            CloseB.TabIndex = 17;
            CloseB.Text = "X";
            CloseB.UseVisualStyleBackColor = true;
            CloseB.Click += CloseB_Click;
            // 
            // Registration
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1582, 1055);
            Controls.Add(CloseB);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Registration";
            Text = "Registration";
            Load += Registration_Load;
            panel7.ResumeLayout(false);
            panel7.PerformLayout();
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label lblLog;
        private Label lblSurname;
        private Label lblPass;
        private Label lblName;
        private Label lblRepeatPass;
        private Button Reg;
        private Label lblFirstname;
        private LinkLabel linkAuth;
        private Label lblReg;
        private Panel panel7;
        private TextBox textBox6;
        private Label lblAuth;
        private Panel panel6;
        private TextBox textBox1;
        private Panel panel5;
        private TextBox textBox2;
        private Panel panel4;
        private TextBox textBox3;
        private Panel panel2;
        private TextBox textBox5;
        private Panel panel3;
        private TextBox textBox4;
        private Panel panel1;
        private Button CloseB;
    }
}