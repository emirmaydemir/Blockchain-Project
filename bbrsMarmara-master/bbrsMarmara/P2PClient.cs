using bbrsMarmara.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebSocketSharp;

namespace bbrsMarmara
{
    public class P2PClient
    {
        public BlockchainModel newBlockchain;
        IDictionary<string, WebSocket> wsDict = new Dictionary<string, WebSocket>();
        public string _path = "C:\\Users\\90531\\Desktop\\bbrs_user\\blockchain.txt";
        public void connect(string url)
        {
            if (url!=null)
            {
                WebSocket ws = new WebSocket(url);
                ws.OnMessage += (sender, e) =>
                {
                    if (e.Data == "Hi Client")
                    {
                        Console.WriteLine(e.Data);
                    }
                    else
                    {
                        newBlockchain = JsonConvert.DeserializeObject<BlockchainModel>(e.Data);
                        BlockModel block = newBlockchain.GetLatestBlock();
                        BlockModel block2 = MainForm.MarmaraCoin.GetLatestBlock();
                        //MessageBox.Show(newBlockchain.Chain.Count.ToString());
                        if (block.id <= block2.id) 
                        {
                            return;
                        }
                        else
                        {
                            
                             MainForm.MarmaraCoin = newBlockchain;
                             FileOps fileOps = new FileOps();
                             fileOps.Write(_path, JsonConvert.SerializeObject(MainForm.MarmaraCoin));
                            
                        }
                        
                       // if (!newBlockchain.IsValid() || newBlockchain.Chain.Count <= MainForm.MarmaraCoin.Chain.Count) 
                       // { 
                         //   return;
                        //}
                        //else
                        //{
                            //MainForm.MarmaraCoin = newBlockchain;
                            //FileOps fileOps = new FileOps();
                            //fileOps.Write(_path, JsonConvert.SerializeObject(MainForm.MarmaraCoin));
                        //}

                    }
                };
                ws.Connect();
                ws.Send("Hi Server");
                ws.Send(JsonConvert.SerializeObject(MainForm.MarmaraCoin));
                //wsDict.Add(url, ws);
            }
        }
        public void Send(string url, string data)
        {
            foreach (var item in wsDict)
            {
                item.Value.Send(data);
            }
        }
        public IList<string> GetServers()
        {
            IList<string> servers = new List<string>();
            foreach (var item in wsDict)
            {
                servers.Add(item.Key);
            }
            return servers;
        }

        public void Close()
        {
            foreach (var item in wsDict)
            {
                item.Value.Close();
            }
        }
    }
}
