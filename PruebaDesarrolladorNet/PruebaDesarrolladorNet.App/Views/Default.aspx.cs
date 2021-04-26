using PruebaDesarrolladorNet.Business.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PruebaDesarrolladorNet.App
{
    public partial class Index : System.Web.UI.Page
    {
        /*
        private DateService _dataService;

        public Index()
        {
            this._dataService = new DateService();
        }
        */

        protected void Page_Load(object sender, EventArgs e)
        {

          //  Response.Redirect("Views/CreateReport.aspx");

            this.LoadData(); 

        }

        private void LoadData()
        {
            this.grdWeatherList.DataSource = DataService.GetStatesByCountry(3);
            this.grdWeatherList.DataBind();
        }

        private void Delete(int id)
        {
            DataService.DeleteState(id);

            
            this.LoadData();
        }

        protected void grdWeatherList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "onDeleted")
            {
                // var id = e.CommandArgument;

                int id = 0;

                Int32.TryParse(e.CommandArgument.ToString(),out id);

                this.Delete(id);

            }
            else if (e.CommandName.Equals("selectproduct"))
            {
                Console.WriteLine("no se ...");
            }
        }
    }
}
