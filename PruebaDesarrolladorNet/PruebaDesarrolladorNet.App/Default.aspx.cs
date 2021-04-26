using PruebaDesarrolladorNet.App.Controllers;
using PruebaDesarrolladorNet.Business.Exceptions;
using PruebaDesarrolladorNet.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PruebaDesarrolladorNet.App
{
    public partial class Default : System.Web.UI.Page
    {
        private AuthController authController;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.authController = new AuthController();

            this.errorMessage.Visible = false;

            this.SessionValidate();
        }

        private void SessionValidate()
        {
            AuthModel auth = (AuthModel)Session["uslog"];

            if (auth!=null)
            {
                if (authController.SessionValidate(auth))
                {
                    Response.Redirect("/weather/");
                }
            }
        
        }

        protected void Login_Click(object sender, EventArgs e)
        {
            string userName = this.txtUserName.Text;
            string password = this.txtPassword.Text;

            try
            {
                var login = this.authController.Login(userName, password);

                Session["uslog"] = login;

                this.errorMessage.Visible = false;

                Response.Redirect("weather/");
            }
            catch (LoginException lex)
            {
                this.errorMessage.Text = lex.Message;
                this.errorMessage.Visible = true;
            }
            catch (Exception)
            {
                this.errorMessage.Text = "Error interno, intenta mas tarde";
                this.errorMessage.Visible = true;
            }
            


        }
    }
}