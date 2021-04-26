

using PruebaDesarrolladorNet.App.Controllers;
using PruebaDesarrolladorNet.Business.Dto;
using PruebaDesarrolladorNet.Business.Exceptions;
using PruebaDesarrolladorNet.Business.Models;
using PruebaDesarrolladorNet.Business.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PruebaDesarrolladorNet.App.Weather
{
    public partial class NewReport : System.Web.UI.Page
    {

        private DataController _dataController = new DataController();
        private WeatherController _WeatherController = new WeatherController();

        private List<CountryDto> _countries;

        private List<StateDto> _states;

        private List<TownDto> _townDtos;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.LoadData();

            if (!Page.IsPostBack)
            {
                date.TodaysDate = DateTime.Now;
            }
        }
        private void LoadData()
        {
            _countries = new List<CountryDto>();
            _countries.Add(new CountryDto { Id = -1, Name = "" });

            _countries.AddRange(_dataController.Countries());

            if (!Page.IsPostBack)
            {
                this.ddCountries.DataSource = _countries;
                this.ddCountries.DataBind();
            }
        }

        private void LoadStates(int countryId)
        {
            var lst = _dataController.States(countryId);

            _states = new List<StateDto>();
            _states.Add(new StateDto { Id = -1, Name = "" });

            _states.AddRange(lst);


            this.ddStates.DataSource = _states;
            this.ddStates.DataBind();

        }

        private void LoadTowns(int stateId)
        {
            var lst = _dataController.Towns(stateId);

            _townDtos = new List<TownDto>();
            _townDtos.Add(new TownDto { Id = -1, Name = "" });

            _townDtos.AddRange(lst);


            this.ddTown.DataSource = _townDtos;
            this.ddTown.DataBind();
        }


        protected void ddCountries_SelectedIndexChanged(object sender, EventArgs e)
        {

            int selectedIndex = ((DropDownList)sender).SelectedIndex;

            if (selectedIndex != 0)
            {
                this.LoadStates(this._countries[selectedIndex].Id);
            }
        }

        protected void ddTown_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddStates_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = -1;

            Int32.TryParse(((DropDownList)sender).SelectedValue, out id);

            if (id != 0)
            {
                this.LoadTowns(id);
            }
        }

        protected void btnNewReport_Click(object sender, EventArgs e)
        {
            try
            {

                inValidDataError.Visible = false;

                int townid;

                bool valTownId =Int32.TryParse(ddTown.SelectedValue, out townid);

                if (townid < 1 || !valTownId)
                {
                    inValidDataError.Text = "Se debe seleccionar una ciudad";
                    inValidDataError.Visible = true;
                    return;
                }

                if (txtConditions.Text.Trim().Equals(string.Empty) ||
                  txtTemperature.Text.Trim().Equals(string.Empty))
                {
                    inValidDataError.Text = "Campos vacios ...";
                    inValidDataError.Visible = true;
                    return;
                }

                int humicity = 0;

                bool val = Int32.TryParse(txtHumicity.Text, out humicity);

                if (!val)
                {
                    inValidDataError.Text = "La humedad debe ser en numeros";
                    inValidDataError.Visible = true;
                    return;
                }

                int precipitation = 0;

                val = Int32.TryParse(txtPrecipitation.Text, out precipitation);

                if (!val)
                {
                    inValidDataError.Text = "La precipitación debe ser en numeros";
                    inValidDataError.Visible = true;
                    return;
                }



                WeatherDto weather = new WeatherDto();

                weather.Conditions = txtConditions.Text;
                weather.Humidity = (short)humicity;
                weather.ReportDate = date.SelectedDate;
                weather.Temperature = txtTemperature.Text;
                weather.Town = new TownDto { Id = townid };
                weather.Precipitation = (short)precipitation;



                AuthModel auth = (AuthModel)Session["uslog"];

                weather = _WeatherController.CreateReport(weather, auth);

                Response.Redirect("./");
            }
            catch (AuthException)
            {
                Session["uslog"] = null;
                Response.Redirect("../");
            }
            catch (Exception ex)
            {

                inValidDataError.Text = "Error interno, intenta mas tarde";
                inValidDataError.Visible = true;
                
            }

        }
    }
}