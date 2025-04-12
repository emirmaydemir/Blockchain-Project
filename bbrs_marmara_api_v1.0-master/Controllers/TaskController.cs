using bbrs_marmara_api_v1._0.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace bbrs_marmara_api_v1._0.Controllers
{
    public class TaskController : ApiController
    {
        // GET: api/Task
        public IEnumerable<TaskModel> Get()
        {
            using (var dbEntities = new bbrs_marmara_dbEntities1())
            {
                return dbEntities.Tasks.Select(t => new TaskModel
                {
                    id = (int)t.id,
                    task = t.task
                }).ToList();
            }
        }

        public class TaskModel
        {
            public int id { get; set; }
            public string task { get; set; }
        }


    }
}