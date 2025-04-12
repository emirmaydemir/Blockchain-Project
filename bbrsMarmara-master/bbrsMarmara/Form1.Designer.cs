namespace bbrsMarmara
{
    partial class Form1
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.baslik = new System.Windows.Forms.Label();
            this.login_mail = new System.Windows.Forms.TextBox();
            this.login_paswd = new System.Windows.Forms.TextBox();
            this.mail_label = new System.Windows.Forms.Label();
            this.parola_label = new System.Windows.Forms.Label();
            this.login_btn = new System.Windows.Forms.Button();
            this.register_page_click = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // baslik
            // 
            this.baslik.AutoSize = true;
            this.baslik.Font = new System.Drawing.Font("Calibri Light", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.baslik.Location = new System.Drawing.Point(158, 48);
            this.baslik.Name = "baslik";
            this.baslik.Size = new System.Drawing.Size(479, 41);
            this.baslik.TabIndex = 0;
            this.baslik.Text = "BBRS MARMARA\'YA HOŞGELDİNİZ";
            // 
            // login_mail
            // 
            this.login_mail.Location = new System.Drawing.Point(165, 155);
            this.login_mail.Name = "login_mail";
            this.login_mail.Size = new System.Drawing.Size(202, 22);
            this.login_mail.TabIndex = 1;
            // 
            // login_paswd
            // 
            this.login_paswd.Location = new System.Drawing.Point(165, 218);
            this.login_paswd.MaxLength = 10;
            this.login_paswd.Name = "login_paswd";
            this.login_paswd.PasswordChar = '*';
            this.login_paswd.Size = new System.Drawing.Size(202, 22);
            this.login_paswd.TabIndex = 2;
            // 
            // mail_label
            // 
            this.mail_label.AutoSize = true;
            this.mail_label.Location = new System.Drawing.Point(165, 136);
            this.mail_label.Name = "mail_label";
            this.mail_label.Size = new System.Drawing.Size(90, 16);
            this.mail_label.TabIndex = 3;
            this.mail_label.Text = "Mail Adresiniz";
            // 
            // parola_label
            // 
            this.parola_label.AutoSize = true;
            this.parola_label.Location = new System.Drawing.Point(165, 199);
            this.parola_label.Name = "parola_label";
            this.parola_label.Size = new System.Drawing.Size(63, 16);
            this.parola_label.TabIndex = 4;
            this.parola_label.Text = "Parolanız";
            // 
            // login_btn
            // 
            this.login_btn.Location = new System.Drawing.Point(165, 269);
            this.login_btn.Name = "login_btn";
            this.login_btn.Size = new System.Drawing.Size(202, 41);
            this.login_btn.TabIndex = 5;
            this.login_btn.Text = "GİRİŞ YAP";
            this.login_btn.UseVisualStyleBackColor = true;
            this.login_btn.Click += new System.EventHandler(this.login_btn_Click);
            // 
            // register_page_click
            // 
            this.register_page_click.Location = new System.Drawing.Point(165, 347);
            this.register_page_click.Name = "register_page_click";
            this.register_page_click.Size = new System.Drawing.Size(202, 42);
            this.register_page_click.TabIndex = 6;
            this.register_page_click.Text = "KAYIT OL";
            this.register_page_click.UseVisualStyleBackColor = true;
            this.register_page_click.Click += new System.EventHandler(this.register_page_click_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(795, 621);
            this.Controls.Add(this.register_page_click);
            this.Controls.Add(this.login_btn);
            this.Controls.Add(this.parola_label);
            this.Controls.Add(this.mail_label);
            this.Controls.Add(this.login_paswd);
            this.Controls.Add(this.login_mail);
            this.Controls.Add(this.baslik);
            this.Name = "Form1";
            this.Text = "BBRS Marmara";
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion

        private System.Windows.Forms.Label baslik;
        private System.Windows.Forms.TextBox login_mail;
        private System.Windows.Forms.TextBox login_paswd;
        private System.Windows.Forms.Label mail_label;
        private System.Windows.Forms.Label parola_label;
        private System.Windows.Forms.Button login_btn;
        private System.Windows.Forms.Button register_page_click;
    }
}

