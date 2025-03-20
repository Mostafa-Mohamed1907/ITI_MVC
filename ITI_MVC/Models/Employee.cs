using ITI_MVC.Validators;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITI_MVC.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required attribute")]
        [MaxLength(25, ErrorMessage = "MaxLength is 25 character")]
        [MinLength(3, ErrorMessage = "MinLength is 3 character")]
        // [UniqueName] // Server Side
        [Remote(action: "CheckName", controller: "Employee", AdditionalFields ="Address"
            ,ErrorMessage = "Name must contain ITI")] // Client Side
        public string? Name { get; set; }
        public int Salary { get; set; }
        public string? JobTitle { get; set; }
        [Required(ErrorMessage = "ImageURL is required attribute")]
        [RegularExpression(@"\w+\.(jpg|png)")]
        public string? ImageURL { get; set; }
        [Required(ErrorMessage = "Address is required attribute")]
        [RegularExpression(@"^[a-zA-Z\s]+$", 
            ErrorMessage = "Address must contain only letters and spaces.")]

        public string? Address { get; set; }
        [ForeignKey("Department")]
        public int DepartmentID { get; set; }
        public Department? Department { get; set; }

    }
}
