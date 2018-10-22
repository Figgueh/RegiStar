using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace RegiStar.Validation
{
    public class LengthValidation : ValidationRule
    {
        private int _min;
        private int _max;

        public int Min { get => _min; set => _min = value; }
        public int Max { get => _max; set => _max = value; }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string stringValue = value.ToString();
            if (stringValue.Length < Min || stringValue.Length > Max)
            {
                return new ValidationResult(false, String.Format("String length must be between {0} and {1}.", Min, Max));
            }

            return ValidationResult.ValidResult;
        }
    }
}
