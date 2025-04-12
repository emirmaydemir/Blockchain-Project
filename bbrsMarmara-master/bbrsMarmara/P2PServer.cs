using bbrsMarmara.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSocketSharp;
using WebSocketSharp.Server;

namespace bbrsMarmara
{
    public class P2PServer:WebSocketBehavior
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
            if (e.Data == "Hi Server")
            {
                Console.WriteLine(e.Data);
                Send("Hi Client");
            }
            else
            {
                BlockchainModel newChain = JsonConvert.DeserializeObject<BlockchainModel>(e.Data);
                if (newChain.IsValid() && newChain.Chain.Count > MainForm.MarmaraCoin.Chain.Count)
                {
                    MainForm.MarmaraCoin = newChain;
                }
                if (!_chainSynched)
                {
                    Send(JsonConvert.SerializeObject(MainForm.MarmaraCoin));
                    _chainSynched = true;
                }
            }
        }
    }
}
