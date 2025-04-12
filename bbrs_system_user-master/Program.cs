using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;

namespace bbrs_system_user
{
    public class Program
    {
        public static int Port;
        private static P2PServer _server;
        private static readonly P2PClient Client = new P2PClient();
        public static Blockchain MarmaraCoin = new Blockchain();
        private static string path = "C:\\Users\\90531\\Desktop\\bbrs_system\\blockchain.txt";
        private static ApiRequests api = new ApiRequests();
        static void Main()
        {
            FileOps fileOps = new FileOps();
            string[] taskCompStatus = {"Mert","Emir","Fatih","Kadir","Batı"};
            if(fileOps.IsFileEmpty(path)==true) 
            {
                MarmaraCoin.InitializeChain();
            }
            else
            {
                MarmaraCoin = fileOps.Read(path);
            }
            Port = 2323;
            int comp_id;
            string wallet_addr;
            if(Port > 0)
            {
                _server = new P2PServer();
                _server.Start();
            }
            
            while(true) 
            {
                comp_id = api.getComplete();
                if (comp_id != -1)
                {
                    wallet_addr = api.getWalletAddr(comp_id);
                    api.giveReward(comp_id);
                    //api.changeStatus(comp_id);
                    Transaction transaction = new Transaction("system", wallet_addr, 1);
                    Block block = new Block(DateTime.Now, transaction, "prev");
                    MarmaraCoin.AddBlock(block);
                    fileOps.Write(path, JsonConvert.SerializeObject(MarmaraCoin));

                }
                System.Threading.Thread.Sleep(5000);
            }
            
            /*while (true)
            {
                for(int i = 0; i < taskCompStatus.Length; i++)
                {
                    if (taskCompStatus[i] != "")
                    {
                        Transaction transaction = new Transaction("system", taskCompStatus[i], 1);
                        Block block = new Block(DateTime.Now,transaction,"prev");
                        MarmaraCoin.AddBlock(block);
                        //json = JsonConvert.SerializeObject(MarmaraCoin);
                        fileOps.Write(path, JsonConvert.SerializeObject(MarmaraCoin));
                        
                    }

                    System.Threading.Thread.Sleep(2000);
                }
                System.Threading.Thread.Sleep(5000);
            }*/
            //string server_url = "127.0.0.1:2323/Blockchain";
            //Client.connect(server_url);
            /*
            Console.WriteLine("BBRS Sistemi başlatılıyor..");
            //kurulacak sürekli döngü mekanizması ile görev tamamlama kontrol işlemi döngü içerisinde buraya yazılacak
            Transaction trans = new Transaction("fatih","emir",5);
            Block block = new Block(DateTime.Now,trans,"prevHash");
            Blockchain blockchain = new Blockchain();
            blockchain.AddBlock(block);
            string json = JsonConvert.SerializeObject(blockchain);
            Console.WriteLine(json);*/
            


        }
        
    }
}
