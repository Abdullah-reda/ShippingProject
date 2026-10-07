using System;
using System.Collections.Generic;
using System.Text;
using BL.Dtos.Base;

namespace BL.Dtos
{
    public class ShippmentStatusDto : BaseDto
    {
        public Guid? ShippmentId { get; set; }

        public string? Notes { get; set; }

        public Guid CarrierId { get; set; }
    }
}
