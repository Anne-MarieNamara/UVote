using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UVote.Models;

namespace UVote.Controllers
{
    public class VoteController : Controller
    {
        DAO dao = new DAO();
        // GET: Vote
        public ActionResult Index()
        {
            List<Election> list = dao.GetElections();
            

            return View(list);
        }

        

        // GET: Login
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        // POST: Login
        [HttpPost]
        public ActionResult Login(VoterModel voter)
        {
            if (ModelState.IsValid)
            {
                voter.StudentNumber = dao.VoterLogin(voter);
                if (voter.StudentNumber != null)
                {
                    Session["studentNumber"] = voter.StudentNumber;
                    ViewBag.Session = Session["studentNumber"];
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Message = $"Error {dao.message}!";
                    return View("Error");
                }
            }
            else return View(voter);
        }

        [HttpPost]
        public ActionResult Index(FormCollection form)
        {
            int campaignId = int.Parse(form["CampaignId"]);
            List<ElectoralCandidate> electoralCandidates = dao.GetElectionCandidates(campaignId);
            ViewBag.CampaignId = campaignId;
            return View("Details", electoralCandidates);
        }

        public ActionResult Details()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Vote vote)
        {
            int count = 0;
            if (ModelState.IsValid)
            {
                count = dao.InsertVote(vote);
                if (count == 1)
                {
                    ViewBag.Message = "Your vote has been added";
                    return View("VoteSuccess");
                }
                else
                {
                    ViewBag.Message = "Your vote was not added.";
                    return View("VoteError");
                }
            }
            else return View(vote);
        }

        public ActionResult Logout()
        {
            Session.Clear();
            Session.Abandon();
            return View("../Home/Index");
        }
    }      
}
