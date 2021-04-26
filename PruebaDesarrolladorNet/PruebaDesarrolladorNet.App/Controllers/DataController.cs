using PruebaDesarrolladorNet.Business.Dto;
using PruebaDesarrolladorNet.Business.Models.Dto;
using PruebaDesarrolladorNet.Business.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PruebaDesarrolladorNet.App.Controllers
{
    public class DataController
    {
        public IEnumerable<CountryDto> Countries()
        {
            return DataService.GetCountries;
        }

        public IEnumerable<StateDto> States(int idCountry)
        {
            return DataService.GetStatesByCountry(idCountry);
        }

        public IEnumerable<TownDto> Towns(int idTown)
        {
            return DataService.GetTownsByState(idTown);
        }
    }
}