using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using LinkHub.BOL;
using LinkHub.BLL;

namespace LinkHub.UI.Areas.Admin.Controllers
{
    public class CategoryController : BaseAdminController
    {
        //
        // GET: /Admin/Category/
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(tbl_Category category)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    this.objBs.Category.Insert(category);
                    TempData["Msg"] = "Created successfully";
                }
                else
                {
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