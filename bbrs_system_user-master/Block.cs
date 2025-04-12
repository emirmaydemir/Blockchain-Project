using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace bbrs_system_user
{
    public class Block
    {
        public int id;
        public DateTime _timeStamp;
        public string PreviousHash { get; set; }
        public Transaction Transaction_ { get; set; }

        public string Hash_ { get; set; }

        public Block(DateTime timeStamp,Transaction _transaction,string prevHash) {
            id = 0;
            _timeStamp = timeStamp;
            Transaction_ = _transaction;
            PreviousHash = prevHash;
            //Hash_ = CreateHash();

        }
        

        public string CreateHash()
        {
            var sha256 = SHA256.Create();

            var inputBytes = Encoding.ASCII.GetBytes($"{_timeStamp}-{PreviousHash ?? ""}-{Transaction_}");
            var outputBytes = sha256.ComputeHash(inputBytes);

            return Convert.ToBase64String(outputBytes);
        }
        
    }

}
