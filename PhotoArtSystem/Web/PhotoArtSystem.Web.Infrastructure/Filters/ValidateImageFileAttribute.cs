namespace PhotoArtSystem.Web.Infrastructure.Filters
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;
    using Common.Constants;

    public class ValidateImageFileAttribute : BaseValidateFileAttribute, IClientValidatable
    {
        private const int MaxFileSize = 1024 * 1024 * 3 /* 3 MB*/;

        private readonly ICollection<string> allowedMimeTypes = new List<string>()
        {
            GlobalConstants.ImageJpeg,
            GlobalConstants.ImagePng
        };

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            var displayName = metadata.GetDisplayName().ToLower();

            var rule = new ModelClientValidationRule
            {
                ValidationType = displayName + "validation",
                ErrorMessage = this.ErrorMessageString
            };

            rule.ValidationParameters.Add(displayName + "types", string.Join(",", this.allowedMimeTypes));

            yield return rule;
        }

        public override bool IsValid(object value)
        {
            try
            {
                this.ValidateOrThrowException(value, MaxFileSize, this.allowedMimeTypes);
            }
            catch (Exception e)
            {
                this.ErrorMessage = e.Message;

                return false;
            }

            return true;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (this.IsValid(value))
            {
                return ValidationResult.Success;
            }

            return new ValidationResult(this.ErrorMessage);
        }
    }
}
