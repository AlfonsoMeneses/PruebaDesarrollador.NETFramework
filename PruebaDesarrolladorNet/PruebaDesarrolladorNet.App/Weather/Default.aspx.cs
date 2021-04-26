
using PruebaDesarrolladorNet.App.Controllers;
using PruebaDesarrolladorNet.Business.Exceptions;
using PruebaDesarrolladorNet.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PruebaDesarrolladorNet.App.Weather
{
    public partial class Default : System.Web.UI.Page
    {
        private WeatherController _weatherController;

        protected void Page_Load(object sender, EventArgs e)
        {
            _weatherController = new WeatherController();
            LoadData();
        }

        private void LoadData()
        {
            this.grdWeatherList.DataSource = _weatherController.GetReports();
            this.grdWeatherList.DataBind();
        }

        protected void grdWeatherList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
           

            if (e.CommandName.Equals("onUpdate"))
            {
                string response = "<script> alert('{0}') </script>";

                Response.Write(string.Format(response, "Por problemas internos no se pudo realizar, mis disculpas"));
            }
            else
            {
                try
                {
                    AuthModel auth = (AuthModel)Session["uslog"];

                    int id = 0;
                    Int32.TryParse(e.CommandArgument.ToString(), out id);

                    _weatherController.DeleteReport(id, auth);

                    this.LoadData();
                }
                catch (AuthException)
                {
                    Response.Redirect("/");
                }

            }


        }

        protected void btnNewReport_Click(object sender, EventArgs e)
        {
            Response.Redirect("./newreport.aspx");
        }
    }
}