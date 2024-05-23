using Group5_LonghornAirlines_FinalProject.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Group5_LonghornAirlines_FinalProject.Models
{
    public class AppUser : IdentityUser
    {
        //------------------- Properties-----------------------------------------------------------------
        [Required(ErrorMessage = "First name is required")]
        [Display(Name = "First Name")]
        public String FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        [Display(Name = "Last Name")]
        public String LastName { get; set; }

        [Display(Name = "Middle Initial")]
        public String? MiddleInitial { get; set; }

        [Display(Name = "Date of birth")]
        //[Required(ErrorMessage = "Date of birth is required")]
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

        //Check to see if the user is employed or not
        public Boolean ActiveStatus { get; set; }

        //Creating the age variable; don't need this, 
        // public Int32? Age { get; set; }

        public Int32? Age
        {
            get
            {
                if (DateOfBirth == null)
                    return null;

                DateTime now = DateTime.Today;
                int age = now.Year - DateOfBirth.Value.Year;
                if (now < DateOfBirth.Value.AddYears(age)) age--;

                return age;
            }
        }

        //Need to add an annotation to ensure that advantage number is unique 
        //[Required(ErrorMessage = "AdvantageNumber is required")]
        [Range(5000, int.MaxValue, ErrorMessage = "AdvantageNumber must be a number greater than 4999")]
        public Int32? AdvantageNumber { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Miles must be a positive number")]
        public Int32? Miles { get; set; }

        //------------------- Navigational Properties and List creation for "many side"-----------------------------------------------------------------

        // Navigation property for reservations - A single
        public List<Reservation> Reservations { get; set; }

        // Navigation property for tickets - A single
        public List<Ticket> Tickets { get; set; }

        // Constructor to initialize Reservations and Tickets lists
        public AppUser()
        {
            if (Reservations == null)
            {
                Reservations = new List<Reservation>();
            }

            if (Tickets == null)
            {
                Tickets = new List<Ticket>();
            }
        }

    }
}
