using System;
using System.Collections.Generic;
using System.Text;
using BL.Dtos.Base;

namespace BL.Dtos
{
    public class SubscriptionPackageDto : BaseDto
    {
        public string PackageName { get; set; } = null!;
        public int ShippimentCount { get; set; }
        public double NumberOfKiloMeters { get; set; }
        public double TotalWeight { get; set; }
    }
}
