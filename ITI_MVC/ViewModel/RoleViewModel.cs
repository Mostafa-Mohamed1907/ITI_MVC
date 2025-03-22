using System.ComponentModel.DataAnnotations;

namespace ITI_MVC.ViewModel
{
    public class RoleViewModel
    {
        [Display(Name = "Role Name")]
        public string RoleName { get; set; }
    }
}
