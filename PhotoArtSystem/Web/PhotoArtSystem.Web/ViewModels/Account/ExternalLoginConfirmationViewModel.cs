﻿namespace PhotoArtSystem.Web.ViewModels.Account
{
    using System.ComponentModel.DataAnnotations;
    using Common.Constants;

    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]
         [RegularExpression(AuthConstants.EmailRegEx, ErrorMessage = GlobalConstants.EmailNotValidValidationMessages)]
        public string Email { get; set; }
    }
}
