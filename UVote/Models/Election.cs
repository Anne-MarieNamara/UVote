using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UVote.Models
{
    public class Election
    {
        public string CampaignId { get; set; }
        public string RoleTitle { get; set; }
        public string RoleDetails { get; set; }
        public string OfficeTerm { get; set; }
        public string CampaignStart { get; set; }
        public string CampaignEnd { get; set; }
    }
}