using System;
using System.Collections.Generic;
using System.Text;
using BL.Dtos.Base;

namespace BL.Dtos
{
    public class PaymentMethodDto : BaseDto
    {
        public string? MethdAname { get; set; }

        public string? MethodEname { get; set; }
    }
}
