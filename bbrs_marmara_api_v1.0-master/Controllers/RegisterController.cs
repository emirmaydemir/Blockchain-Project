using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace bbrs_marmara_api_v1._0.Controllers
{
    public class RegisterController : ApiController
    {
        userDal user_dal = new userDal();
        [HttpPost]
        public IHttpActionResult Post([FromBody]User u)
        {
            if (user_dal.isExist(u.mail) == true)
            {
                return BadRequest();
            }
            else
            {
                user_dal.addUser(u.username, u.mail, u.password);
                return Ok();
            }
        }
    }
    public class User
    {
        public string username { get; set; }
        public string password { get; set; }
        public string mail { get; set; }
    }
    

}
