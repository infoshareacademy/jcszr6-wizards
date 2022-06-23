﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Wizards.BusinessLogic
{
    public class PlayerForCreate
    {
        [Required]
        [Display(Name = "User Name")]
        [MinLength(3)]
        [MaxLength(20)]
        public string UserName { get; set; }

        [Required]
        [MinLength(8)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Confirm Password")]
        [MinLength(8)]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage = "Password and Confirm Password should be the same!")]
        public string ConfirmPassword { get; set; }

        [Required]
        [Display(Name = "Email addres")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Date of birth")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        public Player ToPlayer()
        {
            return new Player()
            {
                UserName = this.UserName,
                Password = this.Password,
                Email = this.Email,
                DateOfBirth = this.DateOfBirth,
            };
        }
    }
}