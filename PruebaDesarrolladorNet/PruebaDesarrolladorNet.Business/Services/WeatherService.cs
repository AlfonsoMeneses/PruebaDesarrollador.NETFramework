using PruebaDesarrolladorNet.Business.Dto;
using PruebaDesarrolladorNet.Business.Exceptions;
using PruebaDesarrolladorNet.Business.Mapper;
using PruebaDesarrolladorNet.Business.Models;
using PruebaDesarrolladorNet.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PruebaDesarrolladorNet.Business.Services
{
    public class WeatherService
    {
        public static IEnumerable<WeatherDto> GetReports()
        {
            List<WeatherDto> reports = new List<WeatherDto>();

            using (WeatherEntities db = new WeatherEntities())
            {
                var lst = db.WeatherReports.Include("Towns").Where(w => w.active == 1).ToList();

                foreach (var report in lst)
                {
                    reports.Add(WeatherMapper.GetDto(report));
                }

                return reports;
            }
        }

        public static WeatherDto Create(WeatherDto weather, AuthModel auth)
        {
            using (WeatherEntities db = new WeatherEntities())
            {
                if (!AuthService.SessionValidate(auth))
                {
                    throw new AuthException();
                }

                Towns town = db.Towns.Where(t => t.town_id == weather.Town.Id && t.active==1).FirstOrDefault();

                if (town == null)
                {
                    throw new BusinessException("La ciudad no existe en el sistema");
                }

                Users user = db.Users.Where(u => u.user_id == auth.Id && u.active == 1).FirstOrDefault();

                if (user == null)
                {
                    throw new AuthException();
                }

                WeatherReports reports = new WeatherReports
                {
                    Users = user,
                    conditions = weather.Conditions,
                    active = 1,
                    created_at = DateTime.Now,
                    humidity = weather.Humidity,
                    precipitation = weather.Precipitation,
                    report_date = weather.ReportDate,
                    temperature = weather.Temperature,
                    Towns = town,
                    updated_at = DateTime.Now
                };

               
                db.AddToWeatherReports(reports);

                db.SaveChanges();

                weather.Id = reports.reports_id;

                return weather;
            }
        }

        public static WeatherDto Update(int idReport, WeatherDto weather, AuthModel auth)
        {
            using (WeatherEntities db = new WeatherEntities())
            {
                if (!AuthService.SessionValidate(auth))
                {
                    throw new AuthException();
                }

                var report = db.WeatherReports.Where(r => r.reports_id == idReport)
                                              .FirstOrDefault();

                if (report == null)
                {
                    throw new BusinessException("No existe el reporte enviado");
                }

                report.conditions = weather.Conditions;
                report.humidity = weather.Humidity;
                report.precipitation = weather.Precipitation;
                report.report_date = weather.ReportDate;
                report.temperature = weather.Temperature;
                report.Towns.town_id = weather.Town.Id;
                report.updated_at = DateTime.Now;

                db.SaveChanges();

                return weather;
            }
        }

        public static bool Delete(int idReport, AuthModel auth)
        {
            using (WeatherEntities db = new WeatherEntities())
            {
                if (!AuthService.SessionValidate(auth))
                {
                    throw new AuthException();
                }

                var report = db.WeatherReports.Where(r => r.reports_id == idReport && r.active == 1)
                                              .FirstOrDefault();

                if (report == null)
                {
                    throw new BusinessException("No existe el reporte enviado");
                }

                report.active = 0;

                db.SaveChanges();

                return true;
            }
        }
        
    }
}
