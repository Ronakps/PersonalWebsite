using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace Group5_LonghornAirlines_FinalProject.Models
{
    public class FlightCreation
    {
        [Display(Name = "Flight Number")]
        [Range(1000, 9999, ErrorMessage = "The number must be four digits (1000-9999).")]
        [Required]
        public Int32 FlightNumber { get; set; }

        [Required]
        [Display(Name = "Time of Flight")]
        [DataType(DataType.Time)]
        public TimeSpan DepartureTime { get; set; }

        [Required]
        public int SelectedFlightPath { get; set; }

        [Required]
        [Display(Name = "Economy Price per seat")]
        [DisplayFormat(DataFormatString = "{0:c}")]
        public Decimal EconomyPrice { get; set; }

        [Required]
        [Display(Name = "Start Date")]
        [DateRange("2024-04-15", "2024-05-30", ErrorMessage = "Start date must be between April 15, 2024 and May 30, 2024")]
        public DateOnly StartDate { get; set; }

        [Required]
        [Display(Name = "End Date")]
        [DateGreaterThan("StartDate", ErrorMessage = "The end date must be after the start date.")]
        [DateRange("2024-04-15", "2024-05-30", ErrorMessage = "End date must be between April 15, 2024 and May 30, 2024")]
        public DateOnly EndDate { get; set; }

        [Required]
        [Display(Name = "Dates of Departure: ")]
        public DepDays DepDays { get; set; }

        public FlightCreation()
        {

        }



        //-------------------------------------------------------------------------------------------------------------

        public class DateGreaterThanAttribute : ValidationAttribute
        {
            private readonly string _startDatePropertyName;

            public DateGreaterThanAttribute(string startDatePropertyName)
            {
                _startDatePropertyName = startDatePropertyName;
            }

            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                var startDatePropertyInfo = validationContext.ObjectType.GetProperty(_startDatePropertyName);
                if (startDatePropertyInfo == null)
                {
                    throw new ArgumentException("Property with this name not found");
                }

                var startDate = (DateOnly)startDatePropertyInfo.GetValue(validationContext.ObjectInstance);

                if (value != null && value is DateOnly endDate)
                {
                    if (endDate < startDate)
                    {
                        return new ValidationResult(ErrorMessage ?? "End date must be after start date.");
                    }
                }
                return ValidationResult.Success;
            }
        }

        public class DateRangeAttribute : ValidationAttribute
        {
            private readonly DateOnly _minDate;
            private readonly DateOnly _maxDate;

            public DateRangeAttribute(string minDate, string maxDate)
            {
                _minDate = DateOnly.Parse(minDate);
                _maxDate = DateOnly.Parse(maxDate);
            }

            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                if (value is DateOnly date)
                {
                    if (date < _minDate || date > _maxDate)
                    {
                        return new ValidationResult(ErrorMessage ?? $"Date must be between {_minDate:yyyy-MM-dd} and {_maxDate:yyyy-MM-dd}.");
                    }
                }
                return ValidationResult.Success;
            }
        }
    }
}
