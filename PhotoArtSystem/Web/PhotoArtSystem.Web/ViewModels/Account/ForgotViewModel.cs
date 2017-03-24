namespace PhotoArtSystem.Web.ViewModels.Account
{
    using System.ComponentModel.DataAnnotations;
    using Common.Constants;

    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        [RegularExpression(AuthConstants.EmailRegEx)]
        public string Email { get; set; }
    }
}
