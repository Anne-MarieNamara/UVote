using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UVote.Models
{
    public class CampaignDropDown
    {
        public string CampaignId { get; set; }
        [Required(ErrorMessage = "Select a campaign")]
        public string RoleTitle { get; set; }
    }
}