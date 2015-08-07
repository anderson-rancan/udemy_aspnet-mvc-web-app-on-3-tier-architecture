using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using LinkHub.BOL;

namespace LinkHub.UI.Areas.Common.Controllers
{
    public class QuickURLSubmitController : BaseCommonController
    {
        //
        // GET: /Common/QuickURLSubmit/
        public ActionResult Index()
        {
            ViewBag.CategoryId = new SelectList(objBs.Category.GetAll(), "CategoryId", "CategoryName");
            return View();
        }

        [HttpPost]
        public ActionResult Create(QuickURLSubmitModel model)
        {
            try
            {
                // HACK - cheira gambiarra
                ModelState.Remove("User.Password");
                ModelState.Remove("User.ConfirmPassword");
                ModelState.Remove("Url.UrlDesc");

                if (ModelState.IsValid)
                {
                    objBs.InsertQuickURL(model);
                    TempData["Msg"] = "Created successfully";
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.CategoryID = new SelectList(objBs.Category.GetAll(), "CategoryId", "CategoryName");
                    return View("Index");
                }

            }
            catch (Exception ex)
            {
                TempData["Msg"] = "Create failed: " + ex.Message;
                return RedirectToAction("Index");
            }
        }

	}
}