using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using LinkHub.BLL;
using LinkHub.BOL;

namespace LinkHub.UI.Areas.User.Controllers
{
    public class URLController : Controller
    {

        private AdminBs objBs;

        public URLController()
        {
            this.objBs = new AdminBs();
        }

        //
        // GET: /User/URL/
        public ActionResult Index()
        {
            ViewBag.CategoryId = new SelectList(objBs.Category.GetAll(), "CategoryId", "CategoryName");
            ViewBag.UserId = new SelectList(objBs.User.GetAll(), "UserId", "UserEmail");
            return View();
        }

        public ActionResult Create(tbl_Url objUrl)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    this.objBs.Url.Insert(objUrl);
                    TempData["Msg"] = "Created Successfully";
                    
                }
                else
                {
                    ViewBag.CategoryId = new SelectList(objBs.Category.GetAll(), "CategoryId", "CategoryName");
                    ViewBag.UserId = new SelectList(objBs.User.GetAll(), "UserId", "UserEmail");
                    return View("Index");
                }
            }
            catch (Exception ex)
            {
                TempData["Msg"] = "Create failed: " + ex.Message;
            }

            return this.RedirectToAction("Index");
        }
	}
}