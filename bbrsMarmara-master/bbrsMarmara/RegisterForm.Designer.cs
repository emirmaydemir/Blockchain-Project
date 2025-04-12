namespace bbrsMarmara
{
    partial class RegisterForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.reg_username = new System.Windows.Forms.TextBox();
            this.reg_mail = new System.Windows.Forms.TextBox();
            this.reg_passwd = new System.Windows.Forms.TextBox();
            this.register_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(230, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(175, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Seçtiğiniz Username\'i Giriniz";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(230, 148);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(132, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Mail Adresinizi Giriniz";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(230, 236);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Password Giriniz";
            // 
            // reg_username
            // 
            this.reg_username.Location = new System.Drawing.Point(233, 103);
            this.reg_username.Name = "reg_username";
            this.reg_username.Size = new System.Drawing.Size(172, 22);
            this.reg_username.TabIndex = 3;
            // 
            // reg_mail
            // 
            this.reg_mail.Location = new System.Drawing.Point(233, 185);
            this.reg_mail.Name = "reg_mail";
            this.reg_mail.Size = new System.Drawing.Size(172, 22);
            this.reg_mail.TabIndex = 4;
            // 
            // reg_passwd
            // 
            this.reg_passwd.Location = new System.Drawing.Point(233, 280);
            this.reg_passwd.Name = "reg_passwd";
            this.reg_passwd.Size = new System.Drawing.Size(172, 22);
            this.reg_passwd.TabIndex = 5;
            // 
            // register_button
            // 
            this.register_button.Location = new System.Drawing.Point(233, 352);
            this.register_button.Name = "register_button";
            this.register_button.Size = new System.Drawing.Size(172, 40);
            this.register_button.TabIndex = 6;
            this.register_button.Text = "KAYIT OL";
            this.register_button.UseVisualStyleBackColor = true;
            this.register_button.Click += new System.EventHandler(this.register_button_Click);
            // 
            // RegisterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 471);
            this.Controls.Add(this.register_button);
            this.Controls.Add(this.reg_passwd);
            this.Controls.Add(this.reg_mail);
            this.Controls.Add(this.reg_username);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "RegisterForm";
            this.Text = "RegisterForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox reg_username;
        private System.Windows.Forms.TextBox reg_mail;
        private System.Windows.Forms.TextBox reg_passwd;
        private System.Windows.Forms.Button register_button;
    }
}