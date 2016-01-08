namespace Cryptography_RSA
{
    partial class MainForm
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
            this.tbxPlainText = new System.Windows.Forms.TextBox();
            this.tbxPublicKey = new System.Windows.Forms.TextBox();
            this.tbxPrivateKey = new System.Windows.Forms.TextBox();
            this.lblPlainText = new System.Windows.Forms.Label();
            this.lblPublicKey = new System.Windows.Forms.Label();
            this.lblCipherText = new System.Windows.Forms.Label();
            this.tbxCipherText = new System.Windows.Forms.TextBox();
            this.btnGenerateKeysPair = new System.Windows.Forms.Button();
            this.btnEncrypt = new System.Windows.Forms.Button();
            this.btnDecrypt = new System.Windows.Forms.Button();
            this.lblPrivateKey = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tbxPlainText
            // 
            this.tbxPlainText.Location = new System.Drawing.Point(95, 20);
            this.tbxPlainText.Name = "tbxPlainText";
            this.tbxPlainText.Size = new System.Drawing.Size(488, 23);
            this.tbxPlainText.TabIndex = 0;
            // 
            // tbxPublicKey
            // 
            this.tbxPublicKey.Location = new System.Drawing.Point(95, 49);
            this.tbxPublicKey.Multiline = true;
            this.tbxPublicKey.Name = "tbxPublicKey";
            this.tbxPublicKey.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbxPublicKey.Size = new System.Drawing.Size(488, 101);
            this.tbxPublicKey.TabIndex = 1;
            // 
            // tbxPrivateKey
            // 
            this.tbxPrivateKey.Location = new System.Drawing.Point(95, 156);
            this.tbxPrivateKey.Multiline = true;
            this.tbxPrivateKey.Name = "tbxPrivateKey";
            this.tbxPrivateKey.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbxPrivateKey.Size = new System.Drawing.Size(488, 101);
            this.tbxPrivateKey.TabIndex = 2;
            // 
            // lblPlainText
            // 
            this.lblPlainText.AutoSize = true;
            this.lblPlainText.Location = new System.Drawing.Point(27, 23);
            this.lblPlainText.Name = "lblPlainText";
            this.lblPlainText.Size = new System.Drawing.Size(62, 15);
            this.lblPlainText.TabIndex = 3;
            this.lblPlainText.Text = "Plain text:";
            // 
            // lblPublicKey
            // 
            this.lblPublicKey.AutoSize = true;
            this.lblPublicKey.Location = new System.Drawing.Point(23, 52);
            this.lblPublicKey.Name = "lblPublicKey";
            this.lblPublicKey.Size = new System.Drawing.Size(66, 15);
            this.lblPublicKey.TabIndex = 4;
            this.lblPublicKey.Text = "Public key:";
            // 
            // lblCipherText
            // 
            this.lblCipherText.AutoSize = true;
            this.lblCipherText.Location = new System.Drawing.Point(20, 266);
            this.lblCipherText.Name = "lblCipherText";
            this.lblCipherText.Size = new System.Drawing.Size(69, 15);
            this.lblCipherText.TabIndex = 7;
            this.lblCipherText.Text = "Cipher text:";
            // 
            // tbxCipherText
            // 
            this.tbxCipherText.Location = new System.Drawing.Point(95, 263);
            this.tbxCipherText.Name = "tbxCipherText";
            this.tbxCipherText.Size = new System.Drawing.Size(488, 23);
            this.tbxCipherText.TabIndex = 6;
            // 
            // btnGenerateKeysPair
            // 
            this.btnGenerateKeysPair.Location = new System.Drawing.Point(598, 82);
            this.btnGenerateKeysPair.Name = "btnGenerateKeysPair";
            this.btnGenerateKeysPair.Size = new System.Drawing.Size(124, 41);
            this.btnGenerateKeysPair.TabIndex = 8;
            this.btnGenerateKeysPair.Text = "Generate keys pair";
            this.btnGenerateKeysPair.UseVisualStyleBackColor = true;
            this.btnGenerateKeysPair.Click += new System.EventHandler(this.btnGenerateKeysPair_Click);
            // 
            // btnEncrypt
            // 
            this.btnEncrypt.Location = new System.Drawing.Point(598, 129);
            this.btnEncrypt.Name = "btnEncrypt";
            this.btnEncrypt.Size = new System.Drawing.Size(124, 41);
            this.btnEncrypt.TabIndex = 9;
            this.btnEncrypt.Text = "Encrypt";
            this.btnEncrypt.UseVisualStyleBackColor = true;
            this.btnEncrypt.Click += new System.EventHandler(this.btnEncrypt_Click);
            // 
            // btnDecrypt
            // 
            this.btnDecrypt.Location = new System.Drawing.Point(598, 176);
            this.btnDecrypt.Name = "btnDecrypt";
            this.btnDecrypt.Size = new System.Drawing.Size(124, 41);
            this.btnDecrypt.TabIndex = 10;
            this.btnDecrypt.Text = "Decrypt";
            this.btnDecrypt.UseVisualStyleBackColor = true;
            this.btnDecrypt.Click += new System.EventHandler(this.btnDecrypt_Click);
            // 
            // lblPrivateKey
            // 
            this.lblPrivateKey.AutoSize = true;
            this.lblPrivateKey.Location = new System.Drawing.Point(19, 159);
            this.lblPrivateKey.Name = "lblPrivateKey";
            this.lblPrivateKey.Size = new System.Drawing.Size(70, 15);
            this.lblPrivateKey.TabIndex = 5;
            this.lblPrivateKey.Text = "Private key:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 311);
            this.Controls.Add(this.btnDecrypt);
            this.Controls.Add(this.btnEncrypt);
            this.Controls.Add(this.btnGenerateKeysPair);
            this.Controls.Add(this.lblCipherText);
            this.Controls.Add(this.tbxCipherText);
            this.Controls.Add(this.lblPrivateKey);
            this.Controls.Add(this.lblPublicKey);
            this.Controls.Add(this.lblPlainText);
            this.Controls.Add(this.tbxPrivateKey);
            this.Controls.Add(this.tbxPublicKey);
            this.Controls.Add(this.tbxPlainText);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(750, 350);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(750, 350);
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cryptography - RSA";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbxPlainText;
        private System.Windows.Forms.TextBox tbxPublicKey;
        private System.Windows.Forms.TextBox tbxPrivateKey;
        private System.Windows.Forms.Label lblPlainText;
        private System.Windows.Forms.Label lblPublicKey;
        private System.Windows.Forms.Label lblCipherText;
        private System.Windows.Forms.TextBox tbxCipherText;
        private System.Windows.Forms.Button btnEncrypt;
        private System.Windows.Forms.Button btnDecrypt;
        private System.Windows.Forms.Button btnGenerateKeysPair;
        private System.Windows.Forms.Label lblPrivateKey;
    }
}

