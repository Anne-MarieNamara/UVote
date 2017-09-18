using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UVote.Models
{
    public class Election
    {
        [Required]
        public string CampaignId { get; set; }

        [Required]
        public string RoleTitle { get; set; }
    }
}