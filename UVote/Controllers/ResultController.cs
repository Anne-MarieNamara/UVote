using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UVote.Models;

namespace UVote.Controllers
{
    public class ResultController : Controller
    {
        DAO dao = new DAO();
        // GET: Result
        public ActionResult Index()
        {
            List<Result> list = dao.GetResults();
            return View(list);
        }
    }
}
