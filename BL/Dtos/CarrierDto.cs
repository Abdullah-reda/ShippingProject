using AppResources;
using BL.Dtos.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BL.Dtos
{
    public class CarrierDto : BaseDto
    {
        [Required]
        [StringLength(100, MinimumLength = 5, ErrorMessageResourceName = "NameLenght", ErrorMessageResourceType = typeof(Messages))]
        public string? CarrierName { get; set; }
    }
}
