using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bbrs_system_user
{
    public class ApiRequests
    {
        public int getComplete()
        {
            var client = new RestClient("https://localhost:44384/");
            var request = new RestRequest("api/Manager/Get", Method.Get);
            var response = client.Execute<int>(request);
            int id = response.Data;
            return id;
        }
        public string getWalletAddr(int id)
        {
            var client = new RestClient("https://localhost:44384/");
            var request = new RestRequest("api/Complete/Get", Method.Get);
            request.AddQueryParameter("id", id);
            var response = client.Execute<string>(request);
            string wallet = response.Data;
            return wallet;
        }
        public void giveReward(int id)
        {
            var client = new RestClient("https://localhost:44384/");
            var request = new RestRequest("api/Complete/Post", Method.Post);
            request.AddQueryParameter("id", id);
            var response = client.Execute(request);
        }
        public void changeStatus(int id)
        {
            var client = new RestClient("https://localhost:44384/");
            var request = new RestRequest("api/Manager/Get", Method.Get);
            request.AddQueryParameter("id", id);
            var response = client.Execute(request);

        }
    }
}
