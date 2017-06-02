using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Top.Infrastructure.Web.Helpers
{
    [AttributeUsage(AttributeTargets.Class)]
    public class MatchLocalizedAttribute : ValidationAttribute
    {
        public String SourceProperty { get; set; }
        public String MatchProperty { get; set; }

        public MatchLocalizedAttribute(string source, string match, string errorMessage)
        {
            SourceProperty = source;
            MatchProperty = match;
            ErrorMessage = errorMessage;
        }

        public override Boolean IsValid(Object value)
        {
            var objectType = value.GetType();

            var properties = objectType.GetProperties();

            var sourceValue = new object();
            var matchValue = new object();

            var counter = 0;

            foreach (var propertyInfo in properties.Where(propertyInfo => propertyInfo.Name == SourceProperty || propertyInfo.Name == MatchProperty))
            {
                if (counter == 0)
                {
                    sourceValue = propertyInfo.GetValue(value, null);
                }
                if (counter == 1)
                {
                    matchValue = propertyInfo.GetValue(value, null);
                }
                counter++;
                if (counter == 2)
                {
                    break;
                }
            }

            if (sourceValue == null && matchValue == null)
                return true;

            return sourceValue != null && sourceValue.Equals(matchValue);
        }
    }
}
