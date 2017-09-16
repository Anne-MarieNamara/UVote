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
                    //Session["name"] = admin.Name;
                    //ViewBag.Session = Session["employeeId"] + "" + Session["name"];
                    ViewBag.Session = Session["studentNumber"];
                    return View("Index");
                }
                else
                {
                    ViewBag.Message = $"Error {dao.message}!";
                    return View("Error");
                }
            }
            else return View(voter);
        }

        // GET: Vote/Details/5
        public ActionResult Candidates(int id)
        {
            List<ElectoralCandidate> list = dao.GetElectionCandidates(id);
            return View("Candidates", list);
        }

        // GET: Vote/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Vote/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Vote/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Vote/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Vote/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Vote/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
