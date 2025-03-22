using System.ComponentModel.DataAnnotations;

namespace ITI_MVC.ViewModel
{
    public class LoginAdminViewModel
    {
        public string AdminName { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name ="Remember Me")]
        public bool RememberMe { get; set; }
    }
}
