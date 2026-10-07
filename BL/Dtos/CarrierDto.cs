using System;
using System.Collections.Generic;
using System.Text;
using BL.Dtos.Base;

namespace BL.Dtos
{
    public class CarrierDto : BaseDto
    {
        public string CarrierName { get; set; } = null!;
    }
}
