using AppResources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BL.Dtos
{
    public class LoginDto
    {

        [Required(ErrorMessageResourceName = "EmailRequired", ErrorMessageResourceType = typeof(Messages), AllowEmptyStrings = false)]
        [EmailAddress(ErrorMessageResourceName = "EmailNotValid", ErrorMessageResourceType = typeof(Messages))]
        [StringLength(150, ErrorMessageResourceName = "EmailLenght", ErrorMessageResourceType = typeof(Messages))]
        public string Email { get; set; }

        [Required(ErrorMessageResourceName = "PasswordRequired", ErrorMessageResourceType = typeof(Messages), AllowEmptyStrings = false)]
        [StringLength(100, MinimumLength = 8, ErrorMessageResourceName = "PasswordLenght", ErrorMessageResourceType = typeof(Messages))]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$",
            ErrorMessageResourceName = "PasswordNotValid", ErrorMessageResourceType = typeof(Messages))]
        public string Password { get; set; }

    }
}
