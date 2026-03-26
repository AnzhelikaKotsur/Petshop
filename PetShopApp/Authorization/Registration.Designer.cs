using System.Drawing;
using System.Windows.Forms;

namespace PetShopApp
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
            this.lblLog = new System.Windows.Forms.Label();
            this.lblSurname = new System.Windows.Forms.Label();
            this.lblPass = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblRepeatPass = new System.Windows.Forms.Label();
            this.Reg = new System.Windows.Forms.Button();
            this.lblFirstname = new System.Windows.Forms.Label();
            this.linkAuth = new System.Windows.Forms.LinkLabel();
            this.lblReg = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.lblAuth = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.CloseB2 = new System.Windows.Forms.Button();
            this.panel7.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblLog
            // 
            this.lblLog.AutoSize = true;
            this.lblLog.BackColor = System.Drawing.Color.Transparent;
            this.lblLog.Font = new System.Drawing.Font("Century", 10.2F);
            this.lblLog.ForeColor = System.Drawing.Color.White;
            this.lblLog.Location = new System.Drawing.Point(95, 286);
            this.lblLog.Name = "lblLog";
            this.lblLog.Size = new System.Drawing.Size(63, 21);
            this.lblLog.TabIndex = 4;
            this.lblLog.Text = "Логин";
            // 
            // lblSurname
            // 
            this.lblSurname.AutoSize = true;
            this.lblSurname.BackColor = System.Drawing.Color.Transparent;
            this.lblSurname.Font = new System.Drawing.Font("Century", 10.2F);
            this.lblSurname.ForeColor = System.Drawing.Color.White;
            this.lblSurname.Location = new System.Drawing.Point(95, 222);
            this.lblSurname.Name = "lblSurname";
            this.lblSurname.Size = new System.Drawing.Size(84, 21);
            this.lblSurname.TabIndex = 3;
            this.lblSurname.Text = "Отчество";
            // 
            // lblPass
            // 
            this.lblPass.AutoSize = true;
            this.lblPass.BackColor = System.Drawing.Color.Transparent;
            this.lblPass.Font = new System.Drawing.Font("Century", 10.2F);
            this.lblPass.ForeColor = System.Drawing.Color.White;
            this.lblPass.Location = new System.Drawing.Point(95, 353);
            this.lblPass.Name = "lblPass";
            this.lblPass.Size = new System.Drawing.Size(71, 21);
            this.lblPass.TabIndex = 5;
            this.lblPass.Text = "Пароль";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.BackColor = System.Drawing.Color.Transparent;
            this.lblName.Font = new System.Drawing.Font("Century", 10.2F);
            this.lblName.ForeColor = System.Drawing.Color.White;
            this.lblName.Location = new System.Drawing.Point(94, 157);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(46, 21);
            this.lblName.TabIndex = 2;
            this.lblName.Text = "Имя";
            // 
            // lblRepeatPass
            // 
            this.lblRepeatPass.AutoSize = true;
            this.lblRepeatPass.BackColor = System.Drawing.Color.Transparent;
            this.lblRepeatPass.Font = new System.Drawing.Font("Century", 10.2F);
            this.lblRepeatPass.ForeColor = System.Drawing.Color.White;
            this.lblRepeatPass.Location = new System.Drawing.Point(95, 450);
            this.lblRepeatPass.Name = "lblRepeatPass";
            this.lblRepeatPass.Size = new System.Drawing.Size(206, 21);
            this.lblRepeatPass.TabIndex = 12;
            this.lblRepeatPass.Text = "Подтверждение пароля";
            this.lblRepeatPass.Click += new System.EventHandler(this.lblRepeatPass_Click);
            // 
            // Reg
            // 
            this.Reg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(101)))), ((int)(((byte)(129)))));
            this.Reg.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Reg.Font = new System.Drawing.Font("Century", 15F);
            this.Reg.ForeColor = System.Drawing.Color.White;
            this.Reg.Location = new System.Drawing.Point(153, 593);
            this.Reg.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Reg.Name = "Reg";
            this.Reg.Size = new System.Drawing.Size(300, 81);
            this.Reg.TabIndex = 0;
            this.Reg.Text = "Зарегистрироваться";
            this.Reg.UseVisualStyleBackColor = false;
            this.Reg.Click += new System.EventHandler(this.Reg_Click_1);
            // 
            // lblFirstname
            // 
            this.lblFirstname.AutoSize = true;
            this.lblFirstname.BackColor = System.Drawing.Color.Transparent;
            this.lblFirstname.Font = new System.Drawing.Font("Century", 10.2F);
            this.lblFirstname.ForeColor = System.Drawing.Color.White;
            this.lblFirstname.Location = new System.Drawing.Point(95, 94);
            this.lblFirstname.Name = "lblFirstname";
            this.lblFirstname.Size = new System.Drawing.Size(88, 21);
            this.lblFirstname.TabIndex = 1;
            this.lblFirstname.Text = "Фамилия";
            // 
            // linkAuth
            // 
            this.linkAuth.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(143)))), ((int)(((byte)(163)))));
            this.linkAuth.AutoSize = true;
            this.linkAuth.Font = new System.Drawing.Font("Century", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.linkAuth.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.linkAuth.LinkColor = System.Drawing.Color.White;
            this.linkAuth.Location = new System.Drawing.Point(348, 677);
            this.linkAuth.Name = "linkAuth";
            this.linkAuth.Size = new System.Drawing.Size(52, 18);
            this.linkAuth.TabIndex = 6;
            this.linkAuth.TabStop = true;
            this.linkAuth.Text = "Войти";
            this.linkAuth.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.linkAuth.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkAuth_LinkClicked);
            // 
            // lblReg
            // 
            this.lblReg.AutoSize = true;
            this.lblReg.BackColor = System.Drawing.Color.Transparent;
            this.lblReg.Font = new System.Drawing.Font("Century", 31.8F, System.Drawing.FontStyle.Bold);
            this.lblReg.ForeColor = System.Drawing.Color.White;
            this.lblReg.Location = new System.Drawing.Point(121, 31);
            this.lblReg.Name = "lblReg";
            this.lblReg.Size = new System.Drawing.Size(363, 64);
            this.lblReg.TabIndex = 15;
            this.lblReg.Text = "Регистрация";
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(101)))), ((int)(((byte)(129)))));
            this.panel7.Controls.Add(this.textBox6);
            this.panel7.Location = new System.Drawing.Point(93, 468);
            this.panel7.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(422, 38);
            this.panel7.TabIndex = 17;
            this.panel7.Paint += new System.Windows.Forms.PaintEventHandler(this.panel7_Paint);
            // 
            // textBox6
            // 
            this.textBox6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(101)))), ((int)(((byte)(129)))));
            this.textBox6.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox6.Location = new System.Drawing.Point(18, 13);
            this.textBox6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(383, 15);
            this.textBox6.TabIndex = 13;
            this.textBox6.TextChanged += new System.EventHandler(this.textBox6_TextChanged);
            // 
            // lblAuth
            // 
            this.lblAuth.AutoSize = true;
            this.lblAuth.BackColor = System.Drawing.Color.Transparent;
            this.lblAuth.Font = new System.Drawing.Font("Century", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblAuth.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(143)))), ((int)(((byte)(163)))));
            this.lblAuth.Location = new System.Drawing.Point(204, 677);
            this.lblAuth.Name = "lblAuth";
            this.lblAuth.Size = new System.Drawing.Size(142, 18);
            this.lblAuth.TabIndex = 14;
            this.lblAuth.Text = "Уже есть аккаунт?";
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(101)))), ((int)(((byte)(129)))));
            this.panel6.Controls.Add(this.textBox1);
            this.panel6.Location = new System.Drawing.Point(91, 371);
            this.panel6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(422, 38);
            this.panel6.TabIndex = 17;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(101)))), ((int)(((byte)(129)))));
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Location = new System.Drawing.Point(20, 10);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(383, 15);
            this.textBox1.TabIndex = 14;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(101)))), ((int)(((byte)(129)))));
            this.panel5.Controls.Add(this.textBox2);
            this.panel5.Location = new System.Drawing.Point(91, 304);
            this.panel5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(422, 38);
            this.panel5.TabIndex = 17;
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(101)))), ((int)(((byte)(129)))));
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Location = new System.Drawing.Point(20, 10);
            this.textBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(383, 15);
            this.textBox2.TabIndex = 14;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(101)))), ((int)(((byte)(129)))));
            this.panel4.Controls.Add(this.textBox3);
            this.panel4.Location = new System.Drawing.Point(91, 240);
            this.panel4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(422, 38);
            this.panel4.TabIndex = 17;
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(101)))), ((int)(((byte)(129)))));
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox3.Location = new System.Drawing.Point(20, 10);
            this.textBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(383, 15);
            this.textBox3.TabIndex = 14;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(101)))), ((int)(((byte)(129)))));
            this.panel2.Controls.Add(this.textBox5);
            this.panel2.Location = new System.Drawing.Point(92, 113);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(422, 38);
            this.panel2.TabIndex = 16;
            // 
            // textBox5
            // 
            this.textBox5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(101)))), ((int)(((byte)(129)))));
            this.textBox5.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox5.Location = new System.Drawing.Point(20, 11);
            this.textBox5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(383, 15);
            this.textBox5.TabIndex = 14;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(101)))), ((int)(((byte)(129)))));
            this.panel3.Controls.Add(this.textBox4);
            this.panel3.Location = new System.Drawing.Point(91, 175);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(422, 38);
            this.panel3.TabIndex = 17;
            // 
            // textBox4
            // 
            this.textBox4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(101)))), ((int)(((byte)(129)))));
            this.textBox4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox4.Location = new System.Drawing.Point(21, 11);
            this.textBox4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(383, 15);
            this.textBox4.TabIndex = 14;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.lblAuth);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.panel6);
            this.panel1.Controls.Add(this.panel7);
            this.panel1.Controls.Add(this.lblReg);
            this.panel1.Controls.Add(this.linkAuth);
            this.panel1.Controls.Add(this.lblFirstname);
            this.panel1.Controls.Add(this.Reg);
            this.panel1.Controls.Add(this.lblRepeatPass);
            this.panel1.Controls.Add(this.lblName);
            this.panel1.Controls.Add(this.lblPass);
            this.panel1.Controls.Add(this.lblSurname);
            this.panel1.Controls.Add(this.lblLog);
            this.panel1.Location = new System.Drawing.Point(510, 131);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(610, 820);
            this.panel1.TabIndex = 16;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // CloseB2
            // 
            this.CloseB2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(143)))), ((int)(((byte)(163)))));
            this.CloseB2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CloseB2.Font = new System.Drawing.Font("Century", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CloseB2.ForeColor = System.Drawing.Color.White;
            this.CloseB2.Location = new System.Drawing.Point(1068, 132);
            this.CloseB2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CloseB2.Name = "CloseB2";
            this.CloseB2.Size = new System.Drawing.Size(52, 52);
            this.CloseB2.TabIndex = 17;
            this.CloseB2.Text = "X";
            this.CloseB2.UseVisualStyleBackColor = false;
            // 
            // Registration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1600, 1102);
            this.Controls.Add(this.CloseB2);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Registration";
            this.Text = "Registration";
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

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
        private Button CloseB2;
    }
}