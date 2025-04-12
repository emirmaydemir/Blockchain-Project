using bbrs_marmara_api_v1._0.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

namespace bbrs_marmara_api_v1._0
{
    public class userDal
    {
        HelperClass helperClass;
        public Boolean login_user(string mail, string passwd)
        {
            using (bbrs_marmara_dbEntities1 db = new bbrs_marmara_dbEntities1())
            {
                var query = from x in db.User where x.mail == mail && x.password == passwd select x;
                if (query.Any())
                {
                    return true;
                }
                else { return false; }
            }
        }


        public void addManager(int b, int c)
        {
            using (bbrs_marmara_dbEntities1 db = new bbrs_marmara_dbEntities1())
            {
                Manager m = new Manager();
                m.user_id = b;
                m.task_id = c;
                m.reward_status = false;
                db.Manager.Add(m);
                db.SaveChanges();
            }
        }
        public void addUser(string b, string c,string d)
        {
            string pw;
            string salt = helperClass.createSalt();
            pw = helperClass.getHash(d,salt);
            using (bbrs_marmara_dbEntities1 db = new bbrs_marmara_dbEntities1())
            {
                User u = new User();
                u.mail = c;
                u.password = pw;
                u.username = b;
                u.salt = salt;
                u.wallet_id = helperClass.createWallet();
                db.User.Add(u);
                db.SaveChanges();
            }
        }
        public Boolean isExist(string mail)
        {
            using (bbrs_marmara_dbEntities1 db = new bbrs_marmara_dbEntities1())
            {
                var query = from x in db.User where x.mail == mail  select x;
                if (query.Any())
                {
                    return true;
                }
                else { return false; }
            }

        }
        public void giveReward(long id)
        {
            using (bbrs_marmara_dbEntities1 db = new bbrs_marmara_dbEntities1()) 
            {
                User user = db.User.FirstOrDefault(x => x.id == id);
                int temp = Convert.ToInt32(user.amount);
                temp = temp + 1;
                user.amount = temp;
                db.User.AddOrUpdate(user);
                db.SaveChanges();
            }
        }

        public void changeStatus(long id)
        {
            using (bbrs_marmara_dbEntities1 db = new bbrs_marmara_dbEntities1())
            {
                Manager manager = db.Manager.FirstOrDefault(x => x.user_id == id && x.reward_status == false);
                if(manager != null)
                {
                    manager.reward_status = true;
                    db.Manager.AddOrUpdate(manager);
                    db.SaveChanges();

                }
                
            }
        }

        public string getWallet(long id)
        {
            using (bbrs_marmara_dbEntities1 db = new bbrs_marmara_dbEntities1())
            {
                User user = db.User.FirstOrDefault(x => x.id == id);
                string addrs = user.wallet_id.ToString();
                return addrs;
            }
        }
    }
}