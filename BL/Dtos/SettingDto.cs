using System;
using System.Collections.Generic;
using System.Text;
using BL.Dtos.Base;

namespace BL.Dtos
{
    public class SettingDto : BaseDto
    {
        public double? KiloMeterRate { get; set; }
        public double? KilooGramRate { get; set; }
    }
}
