using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;

//Change this namespace to match your project
namespace Group5_LonghornAirlines_FinalProject.Models
{
    //NOTE: This is the view model used to allow the user to login
    //The user only needs teh email and password to login
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    //NOTE: This is the view model used to register a user
    //When the user registers, they only need to specify the
    //properties listed in this model
    public class RegisterViewModel
    {
        //NOTE: Here is the property for email
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        //NOTE: Here is the property for phone number
        [Required(ErrorMessage = "Phone number is required")]
        [Display(Name = "Phone Number")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Invalid phone number. Use exactly 10 digits.")]
        public string PhoneNumber { get; set; }

        //Add any fields that you need for creating a new user
        //First name is provided as an example
        [Required(ErrorMessage = "First name is required.")]
        [Display(Name = "First Name")]
        public String FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required.")]
        [Display(Name = "First Name")]
        public String LastName { get; set; }

        [Display(Name = "Middle Initial")]
        [RegularExpression(@"^[A-Z]$", ErrorMessage = "Invalid middle initial. Use exactly one uppercase letter.")]
        public String? MiddleInitial { get; set; }

        public DateTime? DateOfBirth { get; set; }
        public String? Street { get; set; }
        public String? City { get; set; }

        [Display(Name = "ZIP Code")]
        [RegularExpression(@"^\d{5}$", ErrorMessage = "Invalid ZIP Code. Use exactly 5 digits.")]
        public String? Zip { get; set; }

        [Display(Name = "State")]
        [RegularExpression(@"^[A-Z]{2}$", ErrorMessage = "Invalid state format. Use exactly 2 uppercase letters.")]
        public String? State { get; set; }

        public Boolean ActiveStatus { get; set; }
        public Int32 Age { get; set; }
        public Int32? AdvantageNumber { get; set; }
        public Int32? Miles { get; set; }


        //NOTE: Here is the logic for putting in a password
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    //NOTE: This is the view model used to allow the user to 
    //change their password
    public class ChangePasswordViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Current password")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    //NOTE: This is the view model used to display basic user information
    //on the index page
    public class IndexViewModel
    {
        public bool HasPassword { get; set; }
        public String UserName { get; set; }
        public String Email { get; set; }
        public String UserID { get; set; }
    }
}
