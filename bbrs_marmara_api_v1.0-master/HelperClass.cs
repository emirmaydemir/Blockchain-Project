using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Text;

namespace bbrs_marmara_api_v1._0
{
    public class HelperClass
    {
        public string createSalt()// salt oluşturur.
        { 
            Random rnd = new Random();
            string salt = rnd.Next(1000000,9999999).ToString();
            return salt;
        }
        public string getHash(string passwd,string salt)//user'a ait password'ü salt ile birlikte hashler
        {
            SHA1 sHA1 = new SHA1CryptoServiceProvider();
            string sifrelenecek_veri = passwd + salt;
            string hash = Convert.ToBase64String(sHA1.ComputeHash(Encoding.UTF8.GetBytes(sifrelenecek_veri)));
            return hash;
        }
        public string createWallet()// user'a ait wallet adresini oluşturur.
        {
            Random rnd = new Random();
            string wallet_id = rnd.Next(100000, 999999).ToString();
            string wallet = "0x"+wallet_id;
            return wallet;
        }
        

    }
}