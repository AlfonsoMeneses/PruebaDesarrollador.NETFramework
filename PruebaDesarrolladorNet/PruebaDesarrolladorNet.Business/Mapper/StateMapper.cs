using PruebaDesarrolladorNet.Business.Dto;
using PruebaDesarrolladorNet.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PruebaDesarrolladorNet.Business.Mapper
{
    public class StateMapper
    {
        public static StateDto GetDto(States state)
        {
            return new StateDto
            {
                Id = state.state_id,
                Code = state.code,
                Name = state.name,
                Country = new CountryDto
                {
                    Id = state.Countries.country_id,
                    Code = state.Countries.name,
                    Name = state.Countries.name
                }
            };
        }

        public static IEnumerable<StateDto> GetDto(IEnumerable<States> states)
        {
            List<StateDto> lst = new List<StateDto>();

            foreach (var state in states)
            {
                var stateDto = new StateDto
                {
                    Id = state.state_id,
                    Code = state.code,
                    Name = state.name
                };
                
                if (state.Countries != null)
                {
                    stateDto.Country = new CountryDto
                    {
                        Id = state.Countries.country_id,
                        Code = state.Countries.name,
                        Name = state.Countries.name
                    };
                }

                lst.Add(stateDto);

               
            }

            return lst;


        }
    }
}
