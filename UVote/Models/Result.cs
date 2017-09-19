using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UVote.Models
{
    public class Result
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ImageUrl { get; set; }
        public int Votes { get; set; }
    }
}