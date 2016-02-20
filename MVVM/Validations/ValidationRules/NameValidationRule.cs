namespace Validations.ValidationRules
{
    using System.Globalization;
    using System.Windows.Controls;
    using System.Linq;

    public class NameValidationRule : ValidationRule
    {
        public int MinLength { get; set; }
        public int MaxLenght { get; set; }
        public bool IsUpperCase { get; set; }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var val = value.ToString();
            if (val.Length < this.MinLength || val.Length > this.MaxLenght)
            {
                return new ValidationResult(
                        false,
                        string.Format(
                            "Name lenght must in range [{0}...{1}]",
                            this.MinLength,
                            this.MaxLenght));
            }

            if (this.IsUpperCase && 
                val.Any(c => char.IsLower(c)))
            {
                return new ValidationResult(
                    false, 
                    "Name must be upper case");
            }

            return new ValidationResult(true, value);
        }
    }
}
