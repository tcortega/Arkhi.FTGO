using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace Arkhi.FTGO.Libs.Core.DataAnnotations
{
    [AttributeUsage(AttributeTargets.Property)]
    public class MinAttribute : DataTypeAttribute
    {
        private readonly double _min;

        public MinAttribute(int min) : base("min")
        {
            _min = min;
        }

        public MinAttribute(double min) : base("min")
        {
            _min = min;
        }

        public object Min => _min;

        public override string FormatErrorMessage(string name)
        {
            if (ErrorMessage == null && ErrorMessageResourceName == null) ErrorMessage = "The field {0} must be greater than or equal to {1}";

            return string.Format(CultureInfo.CurrentCulture, ErrorMessageString, name, _min);
        }

        public override bool IsValid(object value)
        {
            if (value == null) return true;

            var isDouble = double.TryParse(Convert.ToString(value), out var valueAsDouble);

            return isDouble && valueAsDouble >= _min;
        }
    }
}