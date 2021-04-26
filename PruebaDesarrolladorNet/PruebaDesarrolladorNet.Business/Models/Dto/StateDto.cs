using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PruebaDesarrolladorNet.Business.Dto
{
    public class StateDto
    {
        public int Id { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public CountryDto Country { get; set; }
    }
}
