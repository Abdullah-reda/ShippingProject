using System;
using System.Collections.Generic;
using System.Text;
using BL.Dtos.Base;

namespace BL.Dtos
{
    public class CountryDto : BaseDto
    {
        public string? CountryAname { get; set; }
        public string? CountryEname { get; set; }

    }
}
