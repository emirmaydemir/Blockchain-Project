using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSocketSharp;
using WebSocketSharp.Server;
namespace bbrs_system_user
{
    public class P2PServer: WebSocketBehavior
    {
        private bool _chainSynched;
        private WebSocketServer _wss;

        public void Start()
        {
            _wss = new WebSocketServer("ws://127.0.0.1:23456");
            _wss.AddWebSocketService<P2PServer>("/Blockchain");
            _wss.Start();
            Console.WriteLine("started server");

        }
        protected override void OnMessage(MessageEventArgs e)
        {
            if(e.Data == "Hi Server")
            {
                Console.WriteLine(e.Data);
                Send(JsonConvert.SerializeObject(Program.MarmaraCoin));
            }
            else
            {
                Blockchain newChain = JsonConvert.DeserializeObject<Blockchain>(e.Data);    
                if(newChain.IsValid() && newChain.Chain.Count > Program.MarmaraCoin.Chain.Count) 
                {   
                    Program.MarmaraCoin = newChain;
                }
                if(!_chainSynched)
                {
                    Send(JsonConvert.SerializeObject(Program.MarmaraCoin));
                    _chainSynched = true;
                }
            }
        }
    }
}
