using System;
using System.Collections.Generic;
using System.Text;
using BL.Dtos.Base; 

namespace BL.Dtos
{
    public class LogDto : BaseDto
    {
        public string? Message { get; set; }

        public string? MessageTemplate { get; set; }

        public string? Level { get; set; }

        public DateTime? TimeStamp { get; set; }

        public string? Exception { get; set; }

        public string? Properties { get; set; }
    }
}
