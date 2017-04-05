namespace PhotoArtSystem.Web.Infrastructure.Filters
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;
    using Common;

    public class CompareDateAttribute : ValidationAttribute, IClientValidatable
    {
        private const string GreaterThanString = "greater than ";
        private const string GreaterThanOrEqualString = "greater than or equal to ";
        private const string LessThanString = "less than ";
        private const string LessThanOrEqualString = "less than or equal to ";
        private const string ValidationTypeString = "comparedate";
        private const string CompareToPropertyNameString = "comparetopropertyname";
        private const string OperatorNameString = "operatorname";

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

            ModelClientValidationRule rule = new ModelClientValidationRule();
            rule.ErrorMessage = errorMessage;
            rule.ValidationType = ValidationTypeString;
            rule.ValidationParameters.Add(CompareToPropertyNameString, this.CompareToPropertyName);
            rule.ValidationParameters.Add(OperatorNameString, this.OperatorName.ToString());

            yield return rule;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string operString = this.OperatorName == GenericCompareOperator.GreaterThan ?
                GreaterThanString :
                (this.OperatorName == GenericCompareOperator.GreaterThanOrEqual ?
                GreaterThanOrEqualString :
                (this.OperatorName == GenericCompareOperator.LessThan ? LessThanString :
                (this.OperatorName == GenericCompareOperator.LessThanOrEqual ? LessThanOrEqualString : string.Empty)));

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

            return ValidationResult.Success;
        }
    }
}
