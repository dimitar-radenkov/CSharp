namespace Validations.ValidationRules
{
    using System;
    using System.Globalization;
    using System.Windows.Controls;

    public class AgeValidationRule : ValidationRule
    {
        public int Min { get; set; }
        public int Max { get; set; }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            int age = 0;
            if( Int32.TryParse(value.ToString(), out age))
            {
                if (age < this.Min || age > this.Max)
                {
                    return new ValidationResult(
                        false,
                        string.Format(
                            "Age must be in range [{0}...{1}]",
                            this.Min,
                            this.Max));
                }

                return new ValidationResult(true, value);
            }
            else
            {
                return new ValidationResult(false, "Wrong age input.");
            }   
        }
    }
}
