using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UVote.Models
{
    public class StudentModel
    {
        [Display(Name = "Student Number")]
        [RegularExpression(@"^(\d{8})$")]
        [Required]
        public string StudentNumber { get; set; }

        [Display(Name = "First Name")]
        [RegularExpression("[A-Za-z]+")]
        [Required]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [RegularExpression("[A-Za-z]+")]
        [Required]
        public string LastName { get; set; }

        [DataType(DataType.PhoneNumber, ErrorMessage = "Invalid phone number")]
        [RegularExpression(@"^(\d{10})$")]
        [Required]
        public string Telephone { get; set; }

        [EmailAddress]
        [Required]
        public string Email { get; set; }

        [Required]
        [StringLength(10, ErrorMessage = "Invalid password length", MinimumLength = 5)]
        public string Password { get; set; }

        [Display(Name = "Address Line 1")]
        [Required]
        public string AddressLine1 { get; set; }

        [Display(Name = "Address Line 2")]
        [Required]
        public string AddressLine2 { get; set; }

        [Display(Name = "Address Line 3")]
        [Required]
        public string AddressLine3 { get; set; }

        [Display(Name = "Address Line 4")]
        [Required]
        public string AddressLine4 { get; set; }

        [Required]
        public string EmployeeId { get; set; }
    }
}