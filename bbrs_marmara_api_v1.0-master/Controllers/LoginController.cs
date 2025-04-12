using bbrs_marmara_api_v1._0.Data;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Runtime.Caching;
using System.Security.Cryptography.X509Certificates;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using static bbrs_marmara_api_v1._0.Controllers.TaskController;

namespace bbrs_marmara_api_v1._0.Controllers
{
    public class LoginController : ApiController
    {
        private userDal ud = new userDal();
        Dictionary<string, string> verificationCodes = new Dictionary<string, string>();
        public string verificationCode;
        MemoryCache cache = MemoryCache.Default;

        [HttpPost]
        [Route("api/Login/Post")]
        public IHttpActionResult Post([FromBody] login_user_model user)
        {
            string mail = user.mail;
            string password = user.password;

            if(ud.login_user(mail, password))
            {
                cache.Remove("key");
                // Doğrulama kodunu oluşturun
                verificationCode = GenerateVerificationCode();
                cache.Add("key",verificationCode,DateTimeOffset.Now.AddMinutes(30));
                

                // Doğrulama kodunu kullanıcıya gönderin (örneğin e-posta ile)
                SendVerificationCode(mail, verificationCode);

                // Doğrulama kodunu ve kullanıcı bilgilerini geçici bir veritabanına kaydedin
                SaveVerificationCode(mail, verificationCode);

                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("api/Login/Verify")]
        public IHttpActionResult Verify()
        {
            // Kaydedilmiş doğrulama kodunu ve kullanıcı bilgilerini al
            string cachedVerificationCode = cache.Get("key") as string;

            if (cachedVerificationCode != null)
            {
                return Ok(cachedVerificationCode);
            }
            else
            {
                return NotFound();
            }
        }
        /*
        [HttpGet]
        [Route("api/Login/GetUserID")]
        public long GetUserID(login_user_model2 usr)
        {
            using (var dbEntities = new bbrs_marmara_dbEntities1())
            {
                var query = from x in dbEntities.User where x.mail == usr.mail select x.id;
                long user = dbEntities.User.Where(u => u.mail == usr.mail).Select(u => u.id).FirstOrDefault();
                if (user != 0)
                {
                    return user;
                }
                else { return -1; }
            }

             // Kullanıcı bulunamadıysa varsayılan değer olarak -1 döndürülür
        }*/
        [HttpGet]
        [Route("api/Login/GetUserID")]
        public int GetUserID(string mail, string password)
        {
            using (var dbEntities = new bbrs_marmara_dbEntities1())
            {
                var user = dbEntities.User.FirstOrDefault(u => u.mail == mail && u.password == password);
                if (user != null)
                {
                    return Convert.ToInt32(user.id);
                }
            }

            return -1; // Kullanıcı bulunamadıysa varsayılan değer olarak -1 döndürülür
        }

        [HttpGet]
        [Route("api/Login/GetAmount")]
        public int GetAmount(long id)
        {
            using (var dbEntities = new bbrs_marmara_dbEntities1())
            {
                var user = dbEntities.User.FirstOrDefault(u => u.id == id);
                if (user != null)
                {
                    return Convert.ToInt32(user.amount);
                }
            }

            return -1; // Kullanıcı bulunamadıysa varsayılan değer olarak -1 döndürülür
        }

        [HttpGet]
        [Route("api/Login/GetWalletAddr")]
        public string GetWalletAddr(long id)
        {
            using(var dbEntities = new bbrs_marmara_dbEntities1()) 
            {
                var user = dbEntities.User.FirstOrDefault(u => u.id == id);
                if (user != null) 
                {
                    return user.wallet_id;
                }
            }
            return "Hata";
        }

        /*public int GetUserID([FromBody] login_user_model user2)
        {
            using (var dbEntities = new bbrs_marmara_dbEntities1())
            {
                var u_id = dbEntities.User.Select(u => u.mail == user2.mail && u.password == user2.password);
                return Convert.ToInt32(u_id);
            }
        }*/


        private string GenerateVerificationCode()
        {
            // Rastgele doğrulama kodu oluşturmak için gerekli işlemleri yapın
            // Örnek olarak, 6 haneli bir sayı oluşturabilirsiniz
            Random random = new Random();
            int code = random.Next(100000, 999999);
            return code.ToString();
        }
        private void SendVerificationCode(string mail, string verificationCode)
        {
            // Doğrulama kodunu kullanıcıya göndermek için gereken işlemleri yapın
            // Örnek olarak, e-posta göndermek için bir SMTP istemcisi kullanabilirsiniz
            // Burada kendi gereksinimlerinize uygun bir e-posta gönderme yöntemini uygulamalısınız
            // Örneğin:
            string subject = "Doğrulama Kodu";
            string body = $"Giriş yapmak için doğrulama kodunuz: {verificationCode}";

            // E-posta gönderimi için gerekli ayarları yapılandırın
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");
            smtpClient.Port = 587;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new NetworkCredential("mehmedbilgin7@gmail.com", "srjgjfspgtamvjvh");
            smtpClient.EnableSsl = true;

            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress("mehmedbilgin7@gmail.com");
            mailMessage.To.Add(mail);
            mailMessage.Subject = subject;
            mailMessage.Body = body;

            // E-postayı gönderin
            smtpClient.Send(mailMessage);
        }

        private void SaveVerificationCode(string mail, string verificationCode)
        {
            // Kullanıcının doğrulama kodunu ve diğer bilgilerini geçici bir veritabanına kaydetmek için gereken işlemleri yapın
            // Burada geçici bir veritabanı yerine tercih ettiğiniz bir yöntemi kullanabilirsiniz
            // Örneğin, bir bellek listesi veya veritabanı gibi

            // Örnek olarak, bir sözlük (Dictionary) kullanarak kaydedebilirsiniz
            
            verificationCodes.Add(mail, verificationCode);
            // Daha sonra bu sözlüğü kullanarak doğrulama kodunu kontrol edebilirsiniz
        }

        private string GetSavedVerificationCode(string mail)
        {
            // Geçici veritabanından (örneğin sözlük) kaydedilmiş doğrulama kodunu alın
            // Bu örnekte, önceden kaydedilen doğrulama kodlarını içeren bir sözlüğü varsayıyoruz
            
            // Örnek olarak, veritabanından doğrulama kodunu alalım
            string savedVerificationCode = verificationCodes.ContainsKey(mail) ? verificationCodes[mail] : null;
            return savedVerificationCode;
        }

        private string GetSavedPassword(string mail)
        {
            // Geçici bir veritabanından (örneğin veritabanı veya bellek listesi) kullanıcı şifresini alın
            // Bu örnekte, kullanıcı şifrelerini içeren bir sözlüğü varsayıyoruz
            Dictionary<string, string> userPasswords = new Dictionary<string, string>();
            // Örnek olarak, veritabanından kullanıcı şifresini alalım
            string savedPassword = userPasswords.ContainsKey(mail) ? userPasswords[mail] : null;
            return savedPassword;
        }


        public class login_user_model
        {
            public string mail { get; set; }
            public string password { get; set; }
        }
        public class login_user_model2
        {
            public string mail { get; set; }
        }
    }
}
