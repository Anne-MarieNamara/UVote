using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UVote.Models
{
    public class CandidateModel
    {
        [Display(Name = "Candidate ID")]
        [RegularExpression(@"^(\d{8})$")]
        [Required]
        public string CandidateId { get; set; }

        [Display(Name = "First name")]
        [RegularExpression(@"^[A-Za-z]+$")]
        [Required]
        public string FirstName { get; set; }

        [Display(Name = "Last name")]
        [RegularExpression(@"^[A-Za-z]+$")]
        [Required]
        public string LastName { get; set; }

        [Required]
        public string Manifesto { get; set; }
       
        public string ImageUrl { get; set; }

        [Display(Name = "Previous history")]
        [Required]
        public string PreviousHistory { get; set; }

        public string CampaignId { get; set; }
        public IEnumerable<SelectListItem> CampaignIds { get; set; }

 
        public string EmployeeId { get; set; }
    }
}