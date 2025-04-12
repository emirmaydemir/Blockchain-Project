using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bbrs_system_user
{
    public class FileOps
    {
        //blockchain'in dosyaya yazılması ve okunması işlemleri
        public void Write(string path, string json)
        {
            FileStream file = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter writer = new StreamWriter(file);
            
            writer.Write(json);
            writer.Flush();
            writer.Close();
            file.Close(); 
        }
        public Blockchain Read(string path)
        {
            FileStream file = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader reader = new StreamReader(file);
            Blockchain blockchain = JsonConvert.DeserializeObject<Blockchain>(reader.ReadToEnd());
            file.Close();
            return blockchain;
        }
        public Boolean IsFileEmpty(string path) 
        {
            if (File.Exists(path))
            {
                FileInfo fileInfo = new FileInfo(path);
                long a = fileInfo.Length;
                if (a > 0)
                {
                    return false;
                }else { return true; }
            }
            return true;
        }
    }
}
