namespace PhotoArtSystem.Web.Infrastructure.Filters
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;
    using PhotoArtSystem.Common.Constants;

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
            string errorMessage = this.FormatErrorMessage(metadata.DisplayName);

            ModelClientValidationRule rule = new ModelClientValidationRule();
            rule.ErrorMessage = errorMessage;
            rule.ValidationType = "validateimagefile";

            rule.ValidationParameters.Add("validtypes", string.Join(",", this.allowedMimeTypes));

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
