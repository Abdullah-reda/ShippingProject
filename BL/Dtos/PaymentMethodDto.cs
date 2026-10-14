using AppResources;
using BL.Dtos.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BL.Dtos
{
    public class PaymentMethodDto : BaseDto
    {
        [Required(ErrorMessageResourceName = "NameArRequired", ErrorMessageResourceType = typeof(Messages), AllowEmptyStrings = false)]
        [ArabicText(ErrorMessage = "Write the name using Arabic characters only")]
        [StringLength(100, MinimumLength = 5, ErrorMessageResourceName = "NameLenght", ErrorMessageResourceType = typeof(Messages))]
        public string? MethdAname { get; set; }

        [Required(ErrorMessageResourceName = "NameEnRequired", ErrorMessageResourceType = typeof(Messages), AllowEmptyStrings = false)]
        [EnglishText(ErrorMessage = "Write the name using English characters only")]
        [StringLength(100, MinimumLength = 5, ErrorMessageResourceName = "NameLenght", ErrorMessageResourceType = typeof(Messages))]
        public string? MethodEname { get; set; }
    }
}
