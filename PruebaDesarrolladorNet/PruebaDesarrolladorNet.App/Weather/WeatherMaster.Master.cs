using PruebaDesarrolladorNet.App.Controllers;
using PruebaDesarrolladorNet.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PruebaDesarrolladorNet.App.Weather
{
    public partial class WeatherMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            AuthController authController = new AuthController();

            AuthModel auth = (AuthModel)Session["uslog"];

            if (auth == null)
            {
                Session["uslog"] = null;
                Response.Redirect("../");
                
            }

            if (!authController.SessionValidate(auth))
            {
                Session["uslog"] = null;
                Response.Redirect("../");
            }

            lblUserName.Text = auth.Name;

        }

        protected void btnCloseSession_Click(object sender, EventArgs e)
        {
            Session["uslog"] = null;
            Response.Redirect("../");
        }
    }
}