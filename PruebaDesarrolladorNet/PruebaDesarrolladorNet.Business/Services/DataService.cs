using PruebaDesarrolladorNet.Business.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



using PruebaDesarrolladorNet.DataAccess;
using PruebaDesarrolladorNet.Business.Mapper;
using PruebaDesarrolladorNet.Business.Models.Dto;

namespace PruebaDesarrolladorNet.Business.Services
{
    public class DataService
    {
        public static IEnumerable<CountryDto> GetCountries
        {
            get
            {
                List<CountryDto> countries = new List<CountryDto>();

                using (WeatherEntities db = new WeatherEntities())
                {
                    var lst = db.Countries.Where(c => c.active == 1).ToList();

                    foreach (var country in lst)
                    {
                        //  countries.Add(AutoMapper.Mapper.Map<Countries, CountryDto>(country));
                        countries.Add(CountryMapper.GetDto(country));
                    }
                    
                    return countries;
                }
            }
        }

        public static IEnumerable<StateDto> GetStatesByCountry(int countryId)
        {

            WeatherEntities entities = new WeatherEntities();
            var lst = entities.States
                              .Where(s => s.active == 1 && s.Countries.country_id == countryId)
                           .ToList();

            // var lst = from s in entities.States;

            return StateMapper.GetDto(lst);
        }

        public static IEnumerable<TownDto> GetTownsByState(int stateId)
        {
            using (WeatherEntities db = new WeatherEntities())
            {
                List<TownDto> townDtos = new List<TownDto>();

                var lst = db.Towns.Where(t => t.active == 1 && t.States.state_id == stateId)
                                  .ToList();

                foreach (var town in lst)
                {
                    townDtos.Add(new TownDto
                    {
                        Id = town.town_id,
                        Code = town.code,
                        Name = town.name
                    });
                }

                return townDtos;
            }
        }

        public static bool DeleteState(int stateId)
        {
            using (WeatherEntities entities = new WeatherEntities())
            {
                var state = entities.States.Where(s => s.active == 1 && s.state_id == stateId)
                                           .FirstOrDefault();

                if (state != null)
                {
                    state.active = 0;
                    entities.SaveChanges();

                    return true;
                }
                else
                {
                    return false;
                }                
            }
        }
    }
}
