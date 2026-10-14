using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using BL.Dtos.Base;
using AppResources;

namespace BL.Dtos
{
    public class UserReceiverDto : BaseDto
    {
        public Guid UserId { get; set; }
        
        [Required(ErrorMessageResourceName = "NameEnRequired", ErrorMessageResourceType = typeof(Messages), AllowEmptyStrings = false)]
        [StringLength(100, MinimumLength = 2, ErrorMessageResourceName = "NameLenght", ErrorMessageResourceType = typeof(Messages))]
        public string? ReceiverName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Phone is required")]
        [Phone(ErrorMessage = "Invalid Phone Number")]
        public string? Phone { get; set; }

        public Guid CityId { get; set; }

        [Required(ErrorMessage = "Address is required", AllowEmptyStrings = false)]
        [StringLength(250)]
        public string? Address { get; set; }
    }
}
