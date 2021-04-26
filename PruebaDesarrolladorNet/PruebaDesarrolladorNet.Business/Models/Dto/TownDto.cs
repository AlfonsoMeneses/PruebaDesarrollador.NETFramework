using PruebaDesarrolladorNet.Business.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PruebaDesarrolladorNet.Business.Models.Dto
{
    public class TownDto
    {
        public int Id { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public StateDto State { get; set; }
    }
}
