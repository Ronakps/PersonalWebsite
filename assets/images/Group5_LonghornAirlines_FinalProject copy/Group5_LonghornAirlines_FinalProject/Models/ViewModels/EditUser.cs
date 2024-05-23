using System;
using System.ComponentModel.DataAnnotations;

namespace Group5_LonghornAirlines_FinalProject.Models
{
    public class EditUser
    {
        public String Id { get; set; }

        [Required(ErrorMessage = "First name is required")]
        [Display(Name = "First Name")]
        public String FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        [Display(Name = "Last Name")]
        public String LastName { get; set; }

        [Display(Name = "Middle Initial")]
        [StringLength(1, ErrorMessage = "Middle Initial should be a single character")]
        public string? MiddleInitial { get; set; }


        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MMMM d, yyyy")]
        public DateTime? DateOfBirth { get; set; }

        [Required(ErrorMessage = "Street is required")]
        public String? Street { get; set; }

        [Required(ErrorMessage = "City is required")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "City must be alphabetic")]
        public String? City { get; set; }

        [Required(ErrorMessage = "Zip is required")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Zip must contain only numbers")]
        public String? Zip { get; set; }

        [Required(ErrorMessage = "State is required")]
        [RegularExpression(@"^[a-zA-Z]{2}$", ErrorMessage = "State must contain exactly two letters")]
        public String? State { get; set; }

        public Boolean ActiveStatus { get; set; }

        public EditUser()
        { }
    }
}

