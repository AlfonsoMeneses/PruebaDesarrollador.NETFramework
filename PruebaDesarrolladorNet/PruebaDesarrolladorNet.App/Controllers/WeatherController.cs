using PruebaDesarrolladorNet.Business.Dto;
using PruebaDesarrolladorNet.Business.Models;
using PruebaDesarrolladorNet.Business.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PruebaDesarrolladorNet.App.Controllers
{
    public class WeatherController
    {
        public IEnumerable<WeatherDto> GetReports()
        {
            return WeatherService.GetReports();
        }

        public WeatherDto CreateReport(WeatherDto weatherDto, AuthModel auth)
        {
            return WeatherService.Create(weatherDto, auth);
        }

        public WeatherDto UpdateReport(int id,WeatherDto weatherDto, AuthModel auth)
        {
            return WeatherService.Update(id,weatherDto, auth);
        }

        public bool DeleteReport(int id, AuthModel auth)
        {
            return WeatherService.Delete(id, auth);
        }
    }
}