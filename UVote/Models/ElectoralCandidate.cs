using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UVote.Models
{
    public class ElectoralCandidate
    {   
        public string CandidateId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Manifesto { get; set; }
        public string ImageUrl { get; set; }
        public string PreviousHistory { get; set; }
        public string CampaignId { get; set; }
    }
}