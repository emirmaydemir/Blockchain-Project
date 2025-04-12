using bbrsMarmara.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bbrsMarmara
{
    public partial class MainForm : Form
    {
        public static int Port;
        private static P2PServer _server;
        private static readonly P2PClient Client = new P2PClient();
        public static BlockchainModel MarmaraCoin = new BlockchainModel();
        public string server_url = "ws://127.0.0.1:23456/Blockchain";
        public string _path = "C:\\Users\\90531\\Desktop\\bbrs_user\\blockchain.txt";
        public string user_mail;
        public string user_pw;
        public int user_id;
        public int user_amount;
        public string wallet_address;

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
            int nLeft,
            int nTop,
            int nRight,
            int nBottom,
            int nWidthEllipse,
            int nHeightEllipse
        );
        public MainForm(string mail,string pw)
        {
            this.user_mail = mail;
            this.user_pw = pw;
            getUserID();
            //setWallet(user_id);
            //setAmount(user_id);
            InitializeComponent();
            setWallet(user_id);
            setAmount(user_id);
            //Port = 2323;
            FileOps fileOps = new FileOps();
            MarmaraCoin = fileOps.Read(_path);
            //MarmaraCoin.InitializeChain();
            /*if (Port > 0)
            {
                _server = new P2PServer();
                _server.Start();
            }*/
            
            
        }
        public void setWallet(long u_id)
        {
            var client = new RestClient("https://localhost:44384/");
            var request = new RestRequest("api/Login/GetWalletAddr", Method.Get);
            request.AddQueryParameter("id", u_id);
            var response = client.Execute<string>(request);
            wallet_address = response.Data;
            wallet_addr.Text = wallet_address;
        }
        public void setAmount(long u_id)
        {
            var client = new RestClient("https://localhost:44384/");
            var request = new RestRequest("api/Login/GetAmount", Method.Get);
            request.AddQueryParameter("id", u_id);
            var response = client.Execute<int>(request);
            user_amount = response.Data;
            amount.Text = user_amount.ToString();
        }
        public void getUserID()
        {
            var client = new RestClient("https://localhost:44384/");
            var request = new RestRequest("api/Login/GetUserID", Method.Get);
            request.AddQueryParameter("mail", user_mail);
            request.AddQueryParameter("password", user_pw);

            var response = client.Execute<int>(request);
            int a = response.Data;
            user_id = a;
        }

        private void guncelle_btn_Click(object sender, EventArgs e)
        {
            Client.connect(server_url);
            System.Threading.Thread.Sleep(5000);
            //Client.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(user_mail,user_pw);
            form2.Show();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            button1.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0,
            button1.Width, button1.Height, 30, 30));
            guncelle_btn.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0,
            guncelle_btn.Width, button1.Height, 30, 30));
            copy_btn.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0,
            copy_btn.Width, button1.Height, 30, 30));
        }
    }
}
