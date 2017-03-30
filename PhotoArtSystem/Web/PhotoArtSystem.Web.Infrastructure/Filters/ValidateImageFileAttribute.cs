namespace PhotoArtSystem.Web.Infrastructure.Filters
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Common.Constants;

    public class ValidateImageFileAttribute : BaseValidateFileAttribute
    {
        private const int MaxFileSize = 1024 * 1024 * 3 /* 3 MB*/;

        private readonly IList<string> allowedMimeTypes = new List<string>()
        {
            GlobalConstants.ImageJpeg,
            GlobalConstants.ImagePng
        };

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
