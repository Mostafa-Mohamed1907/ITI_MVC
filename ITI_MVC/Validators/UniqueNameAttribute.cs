using ITI_MVC.Models;
using System.ComponentModel.DataAnnotations;

namespace ITI_MVC.Validators
{
    public class UniqueNameAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value,
            ValidationContext validationContext)
        {
            if (value == null)
                return null;
            string newName = value.ToString();
            ITIContext context = new ITIContext();
            Employee employee = context.Employee.FirstOrDefault(i => i.Name == newName); 
            if(employee!=null)
            {
                return new ValidationResult("Name Must Be Unique, Choose Another Name"); 
            }
            return ValidationResult.Success;
        }
    }
}
