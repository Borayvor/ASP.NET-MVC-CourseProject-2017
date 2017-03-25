namespace PhotoArtSystem.Web.ViewModels.UserModels
{
    using System.ComponentModel.DataAnnotations;
    using Data.Models.TransitionalModels;
    using Infrastructure.Mapping;

    public class UserHomePageViewModel : BaseDbKeyViewModel<string>, IMapFrom<ApplicationUserTransitional>
    {
        [Display(Name = "User name")]
        public string UserName { get; set; }

        public string Email { get; set; }
    }
}
