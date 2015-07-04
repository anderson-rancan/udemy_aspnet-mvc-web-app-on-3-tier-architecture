using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using LinkHub.BLL;
using LinkHub.BOL;

namespace LinkHub.UI.Areas.Security.Controllers
{
    public class RegisterController : Controller
    {

        private AdminBs objBs;

        public RegisterController()
        {
            this.objBs = new AdminBs();
        }

        //
        // GET: /Security/Register/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create(tbl_User user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    user.Role = "U";
                    this.objBs.User.Insert(user);
                    TempData["Msg"] = "Created successfully";
                }
                else
                {
                    return View("Index");
                }
            }
            catch (Exception ex)
            {
                TempData["Msg"] = "Creation failed: " + ex.Message;
            }

            return RedirectToAction("Index");
        }

	}
}