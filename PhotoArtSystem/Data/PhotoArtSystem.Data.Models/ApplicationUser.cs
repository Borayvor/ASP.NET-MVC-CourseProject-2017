namespace PhotoArtSystem.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Common.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using PhotoArtSystem.Common.Constants;
    using PhotoArtSystem.Common.DateTime;

    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser, IBaseModel<string>, IAuditInfo, IDeletableEntity
    {
        public ApplicationUser()
        {
            // This will prevent UserManager.CreateAsync from causing exception
            this.CreatedOn = ServerDateTime.Now();
        }

        public bool IsTeacher { get; set; }

        [MaxLength(ModelConstants.ApplicationUserNamesMaxLength)]
        [MinLength(ModelConstants.ApplicationUserNamesMinLength)]
        public string FirstName { get; set; }

        [MaxLength(ModelConstants.ApplicationUserNamesMaxLength)]
        [MinLength(ModelConstants.ApplicationUserNamesMinLength)]
        public string LastName { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? DeletedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? ModifiedOn { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        [RegularExpression(AuthConstants.EmailRegEx, ErrorMessage = GlobalConstants.EmailNotValidValidationMessages)]
        public override string Email { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);

            // Add custom user claims here
            return userIdentity;
        }
    }
}
