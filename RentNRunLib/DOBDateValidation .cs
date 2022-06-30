using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace RentNRunLib
{
public class DOBDateValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value,ValidationContext validationContext)
        {
            DateTime date;
            bool parsed = DateTime.TryParse(value.ToString(), out date);
            if (!parsed)
                return new ValidationResult("Invalid Date");
            else
            {
               //change below as per requirement
                var min = DateTime.Now.AddYears(-18); //for min 18 age
                var max = DateTime.Now.AddYears(-100); //for max 100 age
                var msg = string.Format("Please enter a value between {0:MM/dd/yyyy} and {1:MM/dd/yyyy}", max, min);
                try
                {
                    if (date > min || date < max)
                        return new ValidationResult(msg);
                    else
                        return ValidationResult.Success;
                }
                catch (Exception e)
                {
                    return new ValidationResult(e.Message);
                }
            }
        }
    }
}
