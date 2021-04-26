using PruebaDesarrolladorNet.Business.Dto;
using PruebaDesarrolladorNet.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PruebaDesarrolladorNet.Business.Mapper
{
    public class WeatherMapper
    {
        public static WeatherDto GetDto(WeatherReports report)
        {
            WeatherDto weatherDto = new WeatherDto
            {
                Id = report.reports_id,
                Conditions = report.conditions,
                Humidity = report.humidity,
                Precipitation = report.precipitation,
                Temperature = report.temperature,
                ReportDate = report.report_date,
                Town = new Models.Dto.TownDto()
            };

            if (report.Towns != null)
            {
                weatherDto.Town = new Models.Dto.TownDto
                {
                    Id = report.Towns.town_id,
                    Code = report.Towns.code,
                    Name = report.Towns.name
                };
            }

            return weatherDto;
        }
    }
}
