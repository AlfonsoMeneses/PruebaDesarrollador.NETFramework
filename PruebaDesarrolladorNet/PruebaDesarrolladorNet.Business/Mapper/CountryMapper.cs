using AutoMapper;
using PruebaDesarrolladorNet.Business.Dto;
using PruebaDesarrolladorNet.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PruebaDesarrolladorNet.Business.Mapper
{
    public class CountryMapper:Profile
    {
        public CountryMapper()
        {
            CreateMap<CountryDto,Countries>();
            CreateMap<Countries,CountryDto>();

            CreateMap<List<CountryDto>, List<Countries>>();
            CreateMap<List<Countries>, List<CountryDto>>();
        }

        public static CountryDto GetDto(Countries countries)
        {
            return new CountryDto
            {
                Id = countries.country_id,
                Code = countries.code,
                Name = countries.name
            };
        }
    }
}
