using System.ComponentModel.DataAnnotations;

namespace ITI_MVC.ViewModel
{
    public class RegisterAdminViewModel
    {
        public string AdminName { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Compare("Password")]
        [Display(Name ="Confirm Password")]
        public string ConfirmPassword { get; set; }
        public string Address { get; set; }


    }
}
