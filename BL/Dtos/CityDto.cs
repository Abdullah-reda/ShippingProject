using AppResources;
using BL.Dtos.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BL.Dtos
{
    public class CityDto : BaseDto
    {
        [Required(ErrorMessageResourceName = "NameArRequired", ErrorMessageResourceType = typeof(Messages), AllowEmptyStrings = false)]
        [ArabicText(ErrorMessage = "Write the name using Arabic characters only")]
        [StringLength(100, MinimumLength = 5, ErrorMessageResourceName = "NameLenght", ErrorMessageResourceType = typeof(Messages))]
        public string? CityAname { get; set; }

        [Required(ErrorMessageResourceName = "NameEnRequired", ErrorMessageResourceType = typeof(Messages), AllowEmptyStrings = false)]
        [EnglishText(ErrorMessage = "Write the name using English characters only")]
        [StringLength(100, MinimumLength = 5, ErrorMessageResourceName = "NameLenght", ErrorMessageResourceType = typeof(Messages))]
        public string? CityEname { get; set; }

        public Guid CountryId { get; set; }
    }
}
