namespace PetShopApp.ProductWindow
{
    partial class AddProduct
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
            this.Card.SuspendLayout();
            this.SuspendLayout();
            // 
            // Card
            // 
            this.Card.Location = new System.Drawing.Point(-30, -205);
            // 
            // TitleLabel
            // 
            this.TitleLabel.Location = new System.Drawing.Point(70, 95);
            this.TitleLabel.Size = new System.Drawing.Size(720, 72);
            // 
            // CancelButton
            // 
            this.CancelButton.FlatAppearance.BorderSize = 0;
            this.CancelButton.Location = new System.Drawing.Point(130, 470);
            this.CancelButton.Size = new System.Drawing.Size(170, 64);
            // 
            // ActionButton
            // 
            this.ActionButton.FlatAppearance.BorderSize = 0;
            this.ActionButton.Location = new System.Drawing.Point(560, 470);
            this.ActionButton.Size = new System.Drawing.Size(170, 64);
            // 
            // AddProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Name = "AddProduct";
            this.Text = "AddProduct";
            this.Card.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
    }
}