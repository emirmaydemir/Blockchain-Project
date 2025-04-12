using Microsoft.VisualBasic.ApplicationServices;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bbrsMarmara
{
    public partial class Form2 : Form
    {
        public string user_mail;
        public string user_pw;
        public int u_id;
        public Form2(string mail,string pw)
        {
            this.user_mail = mail;
            this.user_pw = pw;
            InitializeComponent();
            getUserID();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'bbrs_marmara_dbDataSet.Tasks' table. You can move, or remove it, as needed.
            //this.tasksTableAdapter.Fill(this.bbrs_marmara_dbDataSet.Tasks);
            
            grid_load();
            getUserID();
        }
        /*public void getUserID()
        {
            var client = new RestClient("https://localhost:44384/");
        
            var request = new RestRequest("api/Login/GetUserID", Method.Get);
            request.RequestFormat = DataFormat.Json;
            request.AddBody(new login_user_model2 { mail = user_mail });

            var response = client.Execute<long>(request);
            long a= response.Data;
            
            u_id = Convert.ToInt32(a);
        }*/
        public void getUserID()
        {
            var client = new RestClient("https://localhost:44384/");
        
            var request = new RestRequest("api/Login/GetUserID", Method.Get);
            request.AddQueryParameter("mail", user_mail);
            request.AddQueryParameter("password", user_pw);

            var response = client.Execute<int>(request);
            int a = response.Data;
            u_id = a;
        }
        public void grid_load()
        {
            var client = new RestClient("https://localhost:44384/");
            var request = new RestRequest("api/Task/Get", Method.Get);
            request.RequestFormat = DataFormat.Json;

            var response = client.Execute<List<TaskModel>>(request);
            List<TaskModel> tasks = response.Data;

            dataGridView1.DataSource = tasks;

            AddButtonColumn();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void AddButtonColumn()
        {
            DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
            buttonColumn.HeaderText = "Tamamlandı";
            buttonColumn.Text = "Tamamlandı";
            buttonColumn.UseColumnTextForButtonValue = true;
            buttonColumn.Name = "Tamamlandı"; // Sütun adını belirle

            dataGridView1.Columns.Add(buttonColumn);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.RowIndex >= 0) && e.ColumnIndex == 3 || e.ColumnIndex == 4 || e.ColumnIndex == 2) // Sütun indexini kontrol et
            {
                int taskId = (int)dataGridView1.Rows[e.RowIndex].Cells["id"].Value;
                string taskName = (string)dataGridView1.Rows[e.RowIndex].Cells["task"].Value;
                var client = new RestClient("https://localhost:44384/");
                var request = new RestRequest("api/Manager/Post", Method.Post);
                request.RequestFormat = DataFormat.Json;
                request.AddBody(new manager_model { user_id = u_id, task_id = taskId });
                var response = client.Execute(request);
                string result = response.StatusCode.ToString();
                if(result == "OK")
                {
                    string message = $"Görev Tamamlandı: {taskName} (ID: {taskId})";
                    MessageBox.Show(message);
                }
                else
                {
                    MessageBox.Show("Bir hata oluştu sonra deneyiniz");
                }

                
            }
        }


        public class TaskModel
        {
            public int id { get; set; }
            public string task { get; set; }
        }
        public class login_user_model
        {
            public string mail { get; set; }
            public string password { get; set; }
        }
        public class login_user_model2
        {
            public string mail { get; set; }
        }
        public class manager_model 
        {
            public int user_id { get; set; }
            public int task_id { get;set; }
  
        }

    }
}
