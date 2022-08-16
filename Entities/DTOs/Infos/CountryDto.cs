using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs.Infos
{
    public class CountryDto : IDto
    {
        public int Id { get; set; }

        public string CountryName { get; set; }

        public string CountryCode { get; set; }
    }
}
