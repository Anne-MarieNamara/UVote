﻿using System;
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


        // GET: Candidate/Create
        public ActionResult Create()
        {
            var campaignIds = dao.GetAllCampaignID();
            var model = new CandidateModel();
            model.CampaignIds = GetSelectListItems(campaignIds);
            return View(model);
        }

        private IEnumerable<SelectListItem> GetSelectListItems(IEnumerable<int> campaignIds)
        {
            var selectList = new List<SelectListItem>();
            foreach (var id in campaignIds)
            {
                selectList.Add(new SelectListItem
                {
                    Value = id.ToString(),
                    Text = id.ToString()
                });
            }
            return selectList;
        }

        // POST: Candidate/Create
        [HttpPost]
        public ActionResult Create(
            //[Bind(Include = "CandidateId, FirstName, LastName, Manifesto, ImageUrl, PreviousHistory, CampaignId, EmployeeId")] 
            CandidateModel candidateModel, 
            HttpPostedFileBase imageUrl)
        {
            var campaignIds = dao.GetAllCampaignID();
            candidateModel.CampaignIds = GetSelectListItems(campaignIds);
            int count = 0;
            if (ModelState.IsValid)
            {

                var fileName = Path.GetFileName(imageUrl.FileName);
                var directory = Server.MapPath(Url.Content("~/Content/Images"));
                var path = Path.Combine(directory, fileName);
                imageUrl.SaveAs(path);
                candidateModel.ImageUrl = fileName;
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
            else return View(candidateModel);
        }
    }
}
