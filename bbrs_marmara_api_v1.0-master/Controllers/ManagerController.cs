using bbrs_marmara_api_v1._0.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace bbrs_marmara_api_v1._0.Controllers
{
    public class ManagerController : ApiController
    {


        // POST api/<controller>
        userDal user_dal = new userDal();
        [HttpPost]
        public IHttpActionResult Post([FromBody] manager_model m)
        {
            user_dal.addManager(m.user_id, m.task_id);
            return Ok();
        }

        [HttpGet]
        public int Get()
        {
            using(var dbEntities = new bbrs_marmara_dbEntities1()) 
            {
                var manager = dbEntities.Manager.FirstOrDefault(m => m.reward_status == false);
                if(manager != null)
                {
                    int temp = Convert.ToInt32(manager.user_id);
                    user_dal.changeStatus(temp);
                    return temp;
                }
                else { return -1; }
            }
            
        }

        [HttpGet]
        public void Get(int id)
        {
            user_dal.changeStatus(id); 
        }
        public class Manager
        {
            public string username { get; set; }
            public string password { get; set; }
            public string mail { get; set; }
        }
        public class manager_model
        {
            public int user_id { get; set; }
            public int task_id { get; set; }

        }


    }
}