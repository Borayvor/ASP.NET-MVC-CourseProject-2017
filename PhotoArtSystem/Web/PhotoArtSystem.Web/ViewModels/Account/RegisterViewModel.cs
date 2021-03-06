﻿namespace PhotoArtSystem.Web.ViewModels.Account
{
    using System.ComponentModel.DataAnnotations;
    using Common.Constants;

    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        [RegularExpression(AuthConstants.EmailRegEx, ErrorMessage = GlobalConstants.EmailNotValidValidationMessages)]
        public string Email { get; set; }

        [Required]
        [MaxLength(ModelConstants.ApplicationUserNamesMaxLength)]
        [MinLength(ModelConstants.ApplicationUserNamesMinLength)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(ModelConstants.ApplicationUserNamesMaxLength)]
        [MinLength(ModelConstants.ApplicationUserNamesMinLength)]
        public string LastName { get; set; }

        [Required]
        [StringLength(AuthConstants.PasswordMaxLength, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = AuthConstants.PasswordMinLength)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
