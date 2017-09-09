using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UVote.Models;

namespace UVote.Controllers
{
    public class CampaignController : Controller
    {
        DAO dao = new DAO();

        // GET: Campaign
        public ActionResult Index()
        {
            return View();
        }

        // GET: Campaign/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Campaign/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Campaign/Create
        [HttpPost]
        public ActionResult Create(CampaignModel campaignModel)
        {
            int count = 0;
            if (ModelState.IsValid)
            {
                count = dao.InsertCampaign(campaignModel);
                if (count == 1)
                {
                    ViewBag.Message = "Campaign created!";
                    return View("Success");
                }
                else
                {
                    ViewBag.Message = $"Error {dao.message}!";
                    return View("Error");
                }
            }
            return View(campaignModel);
        }

        // GET: Campaign/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Campaign/Edit/5
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

        // GET: Campaign/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Campaign/Delete/5
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
