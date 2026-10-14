using BL.Dtos.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using AppResources;
using System.Text;

namespace BL.Dtos
{
    public class ShippingTypeDto : BaseDto
    {
        [Required(ErrorMessageResourceName = "NameArRequired", ErrorMessageResourceType = typeof(Messages), AllowEmptyStrings = false)]
        [ArabicText(ErrorMessage = "Write the name using Arabic characters only")]
        [StringLength(100, MinimumLength = 5, ErrorMessageResourceName = "NameLenght", ErrorMessageResourceType = typeof(Messages))]
        public string? ShippingTypeAname { get; set; }
        [Required(ErrorMessageResourceName = "NameEnRequired", ErrorMessageResourceType = typeof(Messages), AllowEmptyStrings = false)]
        [EnglishText(ErrorMessage = "Write the name using English characters only")]
        [StringLength(100, MinimumLength = 5, ErrorMessageResourceName = "NameLenght", ErrorMessageResourceType = typeof(Messages))]
        public string? ShippingTypeEname { get; set; }
        [Required(ErrorMessageResourceName = "FactorRequired", ErrorMessageResourceType = typeof(Shipping), AllowEmptyStrings = false)]
        [Range(0.25, 10, ErrorMessageResourceName = "FactorRange", ErrorMessageResourceType = typeof(Shipping))]
        public double ShippingFactor { get; set; }
    }
}
