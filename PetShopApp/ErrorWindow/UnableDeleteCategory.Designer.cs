namespace PetShopApp.ErrorWindow
{
    partial class UnableDeleteCategory
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel card;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Button btnExit;

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
            this.components = new System.ComponentModel.Container();
            this.card = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();

            this.card.SuspendLayout();
            this.SuspendLayout();

            // card
            this.card.BackColor = System.Drawing.Color.Transparent;
            this.card.Location = new System.Drawing.Point(130, 100);
            this.card.Name = "card";
            this.card.Size = new System.Drawing.Size(700, 520);
            this.card.TabIndex = 0;
            this.card.Paint += new System.Windows.Forms.PaintEventHandler(this.card_Paint);

            // lblTitle
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Century", 28F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblTitle.ForeColor = PetShopApp.AppColors.Text;
            this.lblTitle.Location = new System.Drawing.Point(40, 150);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(620, 70);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // lblSubtitle
            this.lblSubtitle.BackColor = System.Drawing.Color.Transparent;
            this.lblSubtitle.Font = new System.Drawing.Font("Century", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblSubtitle.ForeColor = PetShopApp.AppColors.Placeholder;
            this.lblSubtitle.Location = new System.Drawing.Point(40, 235);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(620, 30);
            this.lblSubtitle.TabIndex = 2;
            this.lblSubtitle.Text = "";
            this.lblSubtitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // btnExit
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(101)))), ((int)(((byte)(129)))));
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Century", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnExit.ForeColor = PetShopApp.AppColors.Text;
            this.btnExit.Location = new System.Drawing.Point(255, 330);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(190, 56);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);

            // card children
            this.card.Controls.Add(this.lblTitle);
            this.card.Controls.Add(this.lblSubtitle);
            this.card.Controls.Add(this.btnExit);

            // UnableDeleteCategory (form)
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(960, 720);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Controls.Add(this.card);
            this.Name = "UnableDeleteCategory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UnableDeleteCategory";

            this.card.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion
    }
}