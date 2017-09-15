using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UVote.Models;

namespace UVote.Controllers
{
    public class CandidateController : Controller
    {
        DAO dao = new DAO();

        // GET: Candidate
        public ActionResult Index()
        {
            
            return View();
        }

        // GET: Candidate/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Candidate/Create
        public ActionResult Create()
        {
            ViewBag.CampaignChoice = new SelectList(dao.GetCampaignDropDown(), "CampaignId", "RoleTitle");
            return View();
        }

        // POST: Candidate/Create
        [HttpPost]
        public ActionResult Create(CandidateModel candidateModel)
        {
            ViewBag.CampaignChoice = new SelectList(dao.GetCampaignDropDown(), "CampaignId", "RoleTitle");
            
            int count = 0;
            if (ModelState.IsValid)
            {
                string fileName = Path.GetFileName(candidateModel.ImageFile.FileName);
                string uploadedPath = Path.Combine(Server.MapPath("~/Content/Images/"), fileName);
                candidateModel.ImageFile.SaveAs(uploadedPath);
                count = dao.InsertCandidate(candidateModel);
                if (count == 1)
                {
                    ViewBag.Message = "Candidate added!";
                    return View("Success");
                }
                else
                {
                    ViewBag.Message = $"Error {dao.message}";
                    return View("Error");
                }
            }
            return View(candidateModel);
        }


        // GET: Candidate/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Candidate/Edit/5
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

        // GET: Candidate/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Candidate/Delete/5
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
