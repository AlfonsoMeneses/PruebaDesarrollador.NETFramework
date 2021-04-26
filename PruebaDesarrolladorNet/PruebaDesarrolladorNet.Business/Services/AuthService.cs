using PruebaDesarrolladorNet.Business.Exceptions;
using PruebaDesarrolladorNet.Business.Models;
using PruebaDesarrolladorNet.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PruebaDesarrolladorNet.Business.Services
{
    public class AuthService
    {
        public static AuthModel Login(string userName, string password)
        {
            using (WeatherEntities db = new WeatherEntities())
            {
                string psw = Helpers.Encrypt.GetSHA256(password);

                var user = db.Users.Where(u => u.user_name.Equals(userName) &&
                                             u.password.Equals(psw) &&
                                             u.active == 1)
                                    .FirstOrDefault();

                if (user == null)
                {
                    throw new LoginException("Nombre de usuario o contraseña invalida");
                }

                var token = GenerateToken(user.user_id);

                user.token = token;
                user.last_login_date = DateTime.Now;

                db.SaveChanges();

                string user_name = string.Format("{0} {1}", user.name, user.last_name);

                return new AuthModel { Id = user.user_id, Name= user_name, Token = token };
            }
        }

        private static string GenerateToken(int userId)
        {
            string token = "";

            token = string.Format("{0}-{0}-token", userId, DateTime.Now);

            token = Helpers.Encrypt.GetSHA256(token);

            return token;
        }

        public static bool SessionValidate(AuthModel auth)
        {
            using (WeatherEntities db = new WeatherEntities())
            {
                if (auth == null)
                {
                    throw new AuthException();
                }
                var user = db.Users.Where(u =>  u.user_id == auth.Id  && 
                                                u.active == 1 &&
                                                u.token == auth.Token)
                                   .FirstOrDefault();

                if (user == null)
                {	
                    return false;
                }

                var time =DateTime.Now - user.last_login_date;

                if (time.Value.TotalMinutes > 60)
                {
                    return false;
                }

                return true;
            }
        }
    }
}