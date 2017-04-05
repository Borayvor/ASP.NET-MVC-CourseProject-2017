namespace PhotoArtSystem.Web.Infrastructure.Filters
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;
    using PhotoArtSystem.Common.DateTime;

    public class ValidateDateTimeNowAttribute : ValidationAttribute, IClientValidatable
    {
        private const string ValidationMessageString = "Cannot to choose a date from the past !";

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            string errorMessage = this.FormatErrorMessage(metadata.DisplayName);
            var currentDatetimeString = ServerDateTime.Now().ToLocalTime().ToString();

            ModelClientValidationRule rule = new ModelClientValidationRule();
            rule.ErrorMessage = errorMessage;
            rule.ValidationType = "validatedatetimenow";

            rule.ValidationParameters.Add("validdatatime", currentDatetimeString);

            yield return rule;
        }

        public override bool IsValid(object value)
        {
            var currentDatetime = ServerDateTime.Now().ToLocalTime();
            var valueThis = (DateTime)value;

            if (valueThis < currentDatetime)
            {
                this.ErrorMessage = ValidationMessageString;

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
