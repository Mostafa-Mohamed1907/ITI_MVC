﻿using System.ComponentModel.DataAnnotations;

namespace ITI_MVC.ViewModel
{
    public class RegisterUserViewModel
    {
        public string UserName { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Compare("Password")]
        [Display(Name ="Confirm Password")]
        public string ConfirmPassword { get; set; }
        public string Address { get; set; }


    }
}
