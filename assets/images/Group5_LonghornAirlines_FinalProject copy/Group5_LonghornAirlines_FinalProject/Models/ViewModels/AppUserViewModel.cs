using System;
using System.ComponentModel.DataAnnotations;



namespace Group5_LonghornAirlines_FinalProject.Models
{
    public class AppUserViewModel
    {

        [Display(Name = "First Name")]
        public String? FirstName { get; set; }

        
        [Display(Name = "Last Name")]
        public String? LastName { get; set; }

        [Display(Name = "Middle Initial")]
        public String? MiddleInitial { get; set; }

        [Display(Name = "Date of birth")]
        //[Required(ErrorMessage = "Date of birth is required")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MMMM d, yyyy")]
        public DateTime? DateOfBirth { get; set; }

        public Boolean ActiveStatus { get; set; }

        [Range(5000, int.MaxValue, ErrorMessage = "AdvantageNumber must be a number greater than 4999")]
        public Int32? AdvantageNumber { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Miles must be a positive number")]
        public Int32? Miles { get; set; }

        public string? Email { get; set; }

    }
}

