using PruebaDesarrolladorNet.Business.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PruebaDesarrolladorNet.Business.Dto
{
    public class WeatherDto
    {
        public int Id { get; set; }

        public string Temperature { get; set; }

        public short Precipitation { get; set; }

        public string PrecipitationString
        {
            get
            {
                return string.Format("{0}%", Precipitation);
            }
        }

        public short Humidity { get; set; }

        public string HumidityString
        {
            get
            {
                return string.Format("{0}%", Humidity);
            }
        }

        public string Conditions { get; set; }

        public TownDto Town { get; set; }

        public DateTime ReportDate { get; set; }

        public string ReportDateString
        {
            get
            {
                return ReportDate.ToString("dddd, dd MMMM yyyy");
            }
        }

        public bool ValidateData
        {
            get
            {
                if (this.Conditions == null ||
                    this.ReportDate == null ||
                    this.Temperature == null ||
                    this.Town == null
                    )
                {
                    return false;
                }

                if (this.Conditions.Trim().Equals(string.Empty) ||
                    this.Temperature.Trim().Equals(string.Empty) ||
                    this.Town.Id < 1
                  )
                {
                    return false;
                }

                return true;
            }
        }
    }
}
