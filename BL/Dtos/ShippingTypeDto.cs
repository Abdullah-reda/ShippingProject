using System;
using System.Collections.Generic;
using System.Text;
using BL.Dtos.Base;

namespace BL.Dtos
{
    public class ShippingTypeDto : BaseDto
    {
        public string? ShippingTypeAname { get; set; }
        public string? ShippingTypeEname { get; set; }
        public double ShippingFactor { get; set; }
    }
}
