namespace PhotoArtSystem.Web.Infrastructure.Filters
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;
    using Common;

    public class CompareDateAttribute : ValidationAttribute, IClientValidatable
    {
        private const string GreaterThan = "greater than ";
        private const string GreaterThanOrEqual = "greater than or equal to ";
        private const string LessThan = "less than ";
        private const string LessThanOrEqual = "less than or equal to ";

        private GenericCompareOperator operatorName = GenericCompareOperator.GreaterThanOrEqual;

        public string CompareToPropertyName { get; set; }

        public GenericCompareOperator OperatorName
        {
            get { return this.operatorName; }

            set { this.operatorName = value; }
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            string errorMessage = this.FormatErrorMessage(metadata.DisplayName);
            ModelClientValidationRule compareRule = new ModelClientValidationRule();
            compareRule.ErrorMessage = errorMessage;
            compareRule.ValidationType = "comparedate";
            compareRule.ValidationParameters.Add("comparetopropertyname", this.CompareToPropertyName);
            compareRule.ValidationParameters.Add("operatorname", this.OperatorName.ToString());
            yield return compareRule;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string operString = this.OperatorName == GenericCompareOperator.GreaterThan ?
                GreaterThan :
                (this.OperatorName == GenericCompareOperator.GreaterThanOrEqual ?
                GreaterThanOrEqual :
                (this.OperatorName == GenericCompareOperator.LessThan ? LessThan :
                (this.OperatorName == GenericCompareOperator.LessThanOrEqual ? LessThanOrEqual : string.Empty)));

            var basePropertyInfo = validationContext.ObjectType.GetProperty(this.CompareToPropertyName);

            var valueOther = (IComparable)basePropertyInfo.GetValue(validationContext.ObjectInstance, null);

            var valueThis = (IComparable)value;

            if ((valueThis != null && valueOther != null) &&
                ((this.operatorName == GenericCompareOperator.GreaterThan && valueThis.CompareTo(valueOther) <= 0) ||
                (this.operatorName == GenericCompareOperator.GreaterThanOrEqual && valueThis.CompareTo(valueOther) < 0) ||
                (this.operatorName == GenericCompareOperator.LessThan && valueThis.CompareTo(valueOther) >= 0) ||
                (this.operatorName == GenericCompareOperator.LessThanOrEqual && valueThis.CompareTo(valueOther) > 0)))
            {
                return new ValidationResult(this.ErrorMessage);
            }

            return null;
        }
    }
}
