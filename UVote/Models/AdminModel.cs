using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UVote.Models
{
    public class AdminModel
    {
        [Display(Name = "Employee ID")]
        [RegularExpression(@"^(\d{8})$")]
        [Required]
        public string EmployeeId { get; set; }

        [Required]
        public string Name { get; set; }

        [EmailAddress]
        [Required]
        public string Email { get; set; }

        [Required]
        [StringLength(10, ErrorMessage = "Minimum of 5 characters required", MinimumLength = 5)]
        public string Password { get; set; }
    }
}