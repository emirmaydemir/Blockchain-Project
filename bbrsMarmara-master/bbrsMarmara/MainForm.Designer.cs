namespace bbrsMarmara
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
            this.guncelle_btn = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.header = new System.Windows.Forms.Label();
            this.amount = new System.Windows.Forms.Label();
            this.amount_text = new System.Windows.Forms.Label();
            this.wallet_text = new System.Windows.Forms.Label();
            this.wallet_addr = new System.Windows.Forms.Label();
            this.copy_btn = new System.Windows.Forms.Button();
            this.username = new System.Windows.Forms.Label();
            this.greeting = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // guncelle_btn
            // 
            this.guncelle_btn.BackColor = System.Drawing.Color.WhiteSmoke;
            this.guncelle_btn.FlatAppearance.BorderSize = 0;
            this.guncelle_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.guncelle_btn.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.guncelle_btn.Location = new System.Drawing.Point(176, 328);
            this.guncelle_btn.Name = "guncelle_btn";
            this.guncelle_btn.Size = new System.Drawing.Size(188, 55);
            this.guncelle_btn.TabIndex = 1;
            this.guncelle_btn.Text = "Chain Güncelle";
            this.guncelle_btn.UseVisualStyleBackColor = false;
            this.guncelle_btn.Click += new System.EventHandler(this.guncelle_btn_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button1.Location = new System.Drawing.Point(473, 328);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(172, 55);
            this.button1.TabIndex = 2;
            this.button1.Text = "Görevler";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // header
            // 
            this.header.AutoSize = true;
            this.header.Font = new System.Drawing.Font("Georgia", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.header.Location = new System.Drawing.Point(346, 25);
            this.header.Name = "header";
            this.header.Size = new System.Drawing.Size(118, 27);
            this.header.TabIndex = 3;
            this.header.Text = "CÜZDAN";
            // 
            // amount
            // 
            this.amount.AutoSize = true;
            this.amount.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.amount.Location = new System.Drawing.Point(390, 65);
            this.amount.Name = "amount";
            this.amount.Size = new System.Drawing.Size(33, 24);
            this.amount.TabIndex = 4;
            this.amount.Text = "12";
            // 
            // amount_text
            // 
            this.amount_text.AutoSize = true;
            this.amount_text.Font = new System.Drawing.Font("Georgia", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.amount_text.Location = new System.Drawing.Point(347, 104);
            this.amount_text.Name = "amount_text";
            this.amount_text.Size = new System.Drawing.Size(109, 20);
            this.amount_text.TabIndex = 5;
            this.amount_text.Text = "Ödül Miktarı";
            // 
            // wallet_text
            // 
            this.wallet_text.AutoSize = true;
            this.wallet_text.Font = new System.Drawing.Font("Georgia", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.wallet_text.Location = new System.Drawing.Point(330, 205);
            this.wallet_text.Name = "wallet_text";
            this.wallet_text.Size = new System.Drawing.Size(144, 20);
            this.wallet_text.TabIndex = 6;
            this.wallet_text.Text = "Cüzdan Adresiniz";
            // 
            // wallet_addr
            // 
            this.wallet_addr.AutoSize = true;
            this.wallet_addr.Font = new System.Drawing.Font("Impact", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.wallet_addr.Location = new System.Drawing.Point(361, 175);
            this.wallet_addr.Name = "wallet_addr";
            this.wallet_addr.Size = new System.Drawing.Size(77, 21);
            this.wallet_addr.TabIndex = 7;
            this.wallet_addr.Text = "0x258742";
            // 
            // copy_btn
            // 
            this.copy_btn.BackColor = System.Drawing.Color.WhiteSmoke;
            this.copy_btn.FlatAppearance.BorderSize = 0;
            this.copy_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.copy_btn.Font = new System.Drawing.Font("Georgia", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.copy_btn.Location = new System.Drawing.Point(491, 172);
            this.copy_btn.Name = "copy_btn";
            this.copy_btn.Size = new System.Drawing.Size(181, 29);
            this.copy_btn.TabIndex = 8;
            this.copy_btn.Text = "Copy to Clipboard";
            this.copy_btn.UseVisualStyleBackColor = false;
            // 
            // username
            // 
            this.username.AutoSize = true;
            this.username.Font = new System.Drawing.Font("Georgia", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.username.Location = new System.Drawing.Point(58, 69);
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(126, 20);
            this.username.TabIndex = 9;
            this.username.Text = "emirmaydemir";
            // 
            // greeting
            // 
            this.greeting.AutoSize = true;
            this.greeting.Font = new System.Drawing.Font("Georgia", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.greeting.Location = new System.Drawing.Point(67, 32);
            this.greeting.Name = "greeting";
            this.greeting.Size = new System.Drawing.Size(106, 20);
            this.greeting.TabIndex = 10;
            this.greeting.Text = "Hoş Geldiniz";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.greeting);
            this.Controls.Add(this.username);
            this.Controls.Add(this.copy_btn);
            this.Controls.Add(this.wallet_addr);
            this.Controls.Add(this.wallet_text);
            this.Controls.Add(this.amount_text);
            this.Controls.Add(this.amount);
            this.Controls.Add(this.header);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.guncelle_btn);
            this.Name = "MainForm";
            this.Text = "BBRS Marmara";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button guncelle_btn;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label header;
        private System.Windows.Forms.Label amount;
        private System.Windows.Forms.Label amount_text;
        private System.Windows.Forms.Label wallet_text;
        private System.Windows.Forms.Label wallet_addr;
        private System.Windows.Forms.Button copy_btn;
        private System.Windows.Forms.Label username;
        private System.Windows.Forms.Label greeting;
    }
}