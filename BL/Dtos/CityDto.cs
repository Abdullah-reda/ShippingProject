using System;
using System.Collections.Generic;
using System.Text;
using BL.Dtos.Base;

namespace BL.Dtos
{
    public class CityDto : BaseDto
    {
        public string? CityAname { get; set; }
        public string? CityEname { get; set; }
        public Guid CountryId { get; set; }
    }
}
