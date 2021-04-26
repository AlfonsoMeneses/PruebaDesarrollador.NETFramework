using PruebaDesarrolladorNet.Business.Models;
using PruebaDesarrolladorNet.Business.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PruebaDesarrolladorNet.App.Controllers
{
    public class AuthController
    {
        public AuthModel Login(string userName, string password)
        {
            return AuthService.Login(userName, password);
        }

        public bool SessionValidate(AuthModel auth)
        {
            return AuthService.SessionValidate(auth);
        }
    }
}