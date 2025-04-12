using bbrs_marmara_api_v1._0.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace bbrs_marmara_api_v1._0.Controllers
{
    public class HomeController : ApiController
    {
        bbrs_marmara_dbEntities1 _dbEntities1 = new bbrs_marmara_dbEntities1(); 

        // GET: api/Home
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Home/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Home
        public Boolean Post([FromBody]string mail,string password)
        {   
            var query = from x in _dbEntities1.User where x.mail == mail && x.password == password select x;
            if(query.Any())
            {
                return true;
            }
            else { return false; }
        }

        // PUT: api/Home/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Home/5
        public void Delete(int id)
        {
        }
    }
}
