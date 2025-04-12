using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bbrsMarmara
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void register_button_Click(object sender, EventArgs e)
        {
            //kullanıcı var mı kontrolü olmalı -- isExist fonksiyonu API'ye istek atması lazım.
            var client = new RestClient("https://localhost:44384/");
            var request = new RestRequest("api/Register/Post", Method.Post);
            request.RequestFormat = DataFormat.Json;
            request.AddBody(new UserRegModel { username = reg_username.Text, mail = reg_mail.Text, password = reg_passwd.Text});
            var response = client.Execute(request);
            string result = response.StatusCode.ToString();
            if (result == "OK")
            {
                MessageBox.Show("Kayıt Başarılı");
                this.Close();
            }
            else
            {
                MessageBox.Show("Başarısız kayıt olma denemesi, tekrar deneyiniz");
            }
        }
    }
    
}
