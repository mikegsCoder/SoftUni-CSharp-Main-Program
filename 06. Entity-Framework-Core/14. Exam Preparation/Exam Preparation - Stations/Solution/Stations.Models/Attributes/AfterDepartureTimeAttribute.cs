using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Stations.Models.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class AfterDepartureTimeAttribute : ValidationAttribute
    {
        private string departureTimePropertyName;

        public AfterDepartureTimeAttribute(string departureTimePropertyName)
        {
            this.departureTimePropertyName = departureTimePropertyName;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime arrivalDate = (DateTime)value;
            var departureTimeProperty = validationContext.ObjectType
                .GetProperty(departureTimePropertyName, BindingFlags.Instance | BindingFlags.Public);

            if(departureTimeProperty == null)
            {
                throw new ArgumentException($"There is no property {departureTimePropertyName} in class {validationContext.ObjectType.Name}");
            }

            DateTime departureDate = (DateTime)departureTimeProperty.GetValue(validationContext.ObjectInstance);
            if(departureDate > arrivalDate)
            {
                return new ValidationResult("Deprture date must be before arrival date!");
            }

            return ValidationResult.Success;
        }
    }
}
