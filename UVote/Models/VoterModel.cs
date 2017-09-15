using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UVote.Models
{
    public class VoterModel
    {
        [Display(Name = "Student Number")]
        [RegularExpression(@"^(\d{8})$")]
        [Required]
        public string StudentNumber { get; set; }

        [Required]
        [StringLength(10, ErrorMessage = "Minimum of 5 characters required", MinimumLength = 5)]
        public string Password { get; set; }
    }
}