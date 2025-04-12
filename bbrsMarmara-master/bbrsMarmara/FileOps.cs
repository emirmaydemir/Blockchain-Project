using bbrsMarmara.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bbrsMarmara
{
    public class FileOps
    {
        
        public void Write(string path, string json)
        {
            FileStream file = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter writer = new StreamWriter(file);
            
            writer.Write(json);
            writer.Flush();
            writer.Close();
            file.Close();
        }
        public BlockchainModel Read(string path)
        {
            FileStream file = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader reader = new StreamReader(file);
            BlockchainModel blockchain = JsonConvert.DeserializeObject<BlockchainModel>(reader.ReadToEnd());
            reader.Close();
            file.Close();
            return blockchain;
        }
    }
}
