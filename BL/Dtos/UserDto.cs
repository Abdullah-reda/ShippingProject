using AppResources;
using BL.Dtos.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Dtos
{
    public class UserDto : BaseDto
    {
        [Required(ErrorMessageResourceName = "FirstNameRequired", ErrorMessageResourceType = typeof(Messages), AllowEmptyStrings = false)]
        [StringLength(50, MinimumLength = 2, ErrorMessageResourceName = "NameLenght", ErrorMessageResourceType = typeof(Messages))]
        public string? FirstName { get; set; }

        [Required(ErrorMessageResourceName = "LastNameRequired", ErrorMessageResourceType = typeof(Messages), AllowEmptyStrings = false)]
        [StringLength(50, MinimumLength = 2, ErrorMessageResourceName = "NameLenght", ErrorMessageResourceType = typeof(Messages))]
        public string? LastName { get; set; }

        [Required(ErrorMessageResourceName = "PhoneRequired", ErrorMessageResourceType = typeof(Messages), AllowEmptyStrings = false)]
        [Phone(ErrorMessageResourceName = "PhoneNotValid", ErrorMessageResourceType = typeof(Messages))]
        [StringLength(20, MinimumLength = 7, ErrorMessageResourceName = "PhoneLenght", ErrorMessageResourceType = typeof(Messages))]
        public string? Phone { get; set; }

        [Required(ErrorMessageResourceName = "EmailRequired", ErrorMessageResourceType = typeof(Messages), AllowEmptyStrings = false)]
        [EmailAddress(ErrorMessageResourceName = "EmailNotValid", ErrorMessageResourceType = typeof(Messages))]
        [StringLength(150, ErrorMessageResourceName = "EmailLenght", ErrorMessageResourceType = typeof(Messages))]
        public string Email { get; set; }

        [Required(ErrorMessageResourceName = "PasswordRequired", ErrorMessageResourceType = typeof(Messages), AllowEmptyStrings = false)]
        [StringLength(100, MinimumLength = 8, ErrorMessageResourceName = "PasswordLenght", ErrorMessageResourceType = typeof(Messages))]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$",
            ErrorMessageResourceName = "PasswordNotValid", ErrorMessageResourceType = typeof(Messages))]
        public string Password { get; set; }

        [Required(ErrorMessageResourceName = "ConfirmPasswordRequired", ErrorMessageResourceType = typeof(Messages), AllowEmptyStrings = false)]
        [Compare(nameof(Password), ErrorMessageResourceName = "PasswordNotMatch", ErrorMessageResourceType = typeof(Messages))]
        public string? ConfirmPassword { get; set; }

        public string? Role { get; set; }

        public string? ReturnUrl { get; set; }
    }
}