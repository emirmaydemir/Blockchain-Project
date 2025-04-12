using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json.Nodes;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using RestSharp;

namespace bbrsMarmara
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void login_btn_Click(object sender, EventArgs e)
        {
            var client = new RestClient("https://localhost:44384/");
            var request = new RestRequest("api/Login/Post", Method.Post);
            request.RequestFormat = DataFormat.Json;
            request.AddBody(new login_user_model { mail = login_mail.Text, password = login_paswd.Text });

            var response = client.Execute(request);
            string result = response.StatusCode.ToString();
            if (result == "OK")
            {
                // Doğrulama kodunu kullanıcıdan al
                string verificationCode = Interaction.InputBox("Doğrulama Kodunu Girin", "Doğrulama Kodu");

                // Doğrulama kodunu API'ye gönder
                var verificationRequest = new RestRequest("api/Login/Verify", Method.Get);
                //verificationRequest.AddParameter("mail", login_mail.Text);
                //verificationRequest.AddParameter("verificationCode", verificationCode);

                verificationCode = '\"' + verificationCode + '\"';
                var verificationResponse = client.Execute(verificationRequest);
                string verificationResult = verificationResponse.Content.ToString();


                if (verificationResult.Equals(verificationCode))
                {
                    MessageBox.Show("Giriş Başarılı");
                    MainForm main = new MainForm(login_mail.Text, login_paswd.Text);
                    main.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Doğrulama Kodu Hatalı, tekrar deneyiniz");
                }
            }
            else
            {
                MessageBox.Show("Başarısız giriş denemesi, tekrar deneyiniz");
            }
        }

        private void register_page_click_Click(object sender, EventArgs e)
        {
            RegisterForm frm = new RegisterForm();
            frm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Giriş Başarılı");
            MainForm main = new MainForm("emirmaydemir@gmail.com", "12345");
            main.Show();
            this.Hide();
        }
    }

    public class UserRegModel
    {
        public string username { get; set; }
        public string password { get; set; }
        public string mail { get; set; }
    }
    public class login_user_model
    {
        public string mail { get; set; }
        public string password { get; set; }
    }
}
