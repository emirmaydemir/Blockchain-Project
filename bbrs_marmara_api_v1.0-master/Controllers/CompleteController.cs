using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace bbrs_marmara_api_v1._0.Controllers
{
    public class CompleteController : ApiController
    {
        private userDal ud = new userDal();
        
        // GET api/<controller>/5
        public string Get(int id)
        {
            string wallet_adres = ud.getWallet(id);
            return wallet_adres;
        }

        // POST api/<controller>
        public void Post(int id)
        {
            ud.giveReward(id);
        }

        
    }
}