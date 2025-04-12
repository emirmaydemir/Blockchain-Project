using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
//using System.Net.WebSockets;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using WebSocketSharp;

namespace bbrs_system_user
{
    public class P2PClient
    {
        IDictionary<string, WebSocket> wsDict = new Dictionary<string, WebSocket>();

        public void connect(string url)
        {
            if(!wsDict.ContainsKey(url)) 
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
                        var newChain = JsonConvert.DeserializeObject<Blockchain>(e.Data);
                        if (!newChain.IsValid() || newChain.Chain.Count <= Program.MarmaraCoin.Chain.Count) 
                        {
                            return;
                        }
                        else
                        {
                            Program.MarmaraCoin = newChain;
                        }

                    }
                };
                ws.Connect();
                ws.Send("Hi Server");
                ws.Send(JsonConvert.SerializeObject(Program.MarmaraCoin));
                wsDict.Add(url, ws);
            }
        }
        public void Send(string url, string data)
        {
            foreach(var item in wsDict) 
            { 
                item.Value.Send(data);
            }
        }
        public IList<string> GetServers() 
        {
            IList<string> servers = new List<string>();
            foreach(var item in wsDict)
            {
                servers.Add(item.Key);
            }
            return servers;
        }

        public void Close()
        {
            foreach(var item in wsDict)
            {
                item.Value.Close();
            }
        }
    }
}
