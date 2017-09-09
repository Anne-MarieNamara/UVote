using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UVote.Models
{
    public class CandidateModel
    {
        [Display(Name = "Candidate ID")]
        [RegularExpression(@"^(\d{8})$")]
        [Required]
        public string CandidateId { get; set; }

        [Display(Name = "First name")]
        [RegularExpression("[A-Za-z]+")]
        [Required]
        public string FirstName { get; set; }

        [Display(Name = "Last name")]
        [RegularExpression("[A-Za-z]+")]
        [Required]
        public string LastName { get; set; }

        [Required]
        public string Manifesto { get; set; }

        [Display(Name = "Avatar")]
        [Required]
        public string ImageUrl { get; set; }

        [Display(Name = "Previous history")]
        [Required]
        public string PreviousHistory { get; set; }

        [Display(Name = "Campaign ID")]
        [Required]
        public string CampaignId { get; set; }

        [Required]
        public string EmployeeId { get; set; }
    }
}