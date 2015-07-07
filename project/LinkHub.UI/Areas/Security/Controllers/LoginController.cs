using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using LinkHub.BOL;
using System.Web.Security;

namespace LinkHub.UI.Areas.Security.Controllers
{
    public class LoginController : BaseSecurityController
    {
        //
        // GET: /Security/Login/
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignIn(tbl_User user)
        {
            try
            {
                if (Membership.ValidateUser(user.UserEmail, user.Password))
                {
                    FormsAuthentication.SetAuthCookie(user.UserEmail, false);
                    return RedirectToAction("Index", "Home", new { area = "Common" });
                }

                TempData["Msg"] = "Login failed";
            }
            catch (Exception ex)
            {
                TempData["Msg"] = "Login failed: " + ex.Message;
            }

            return RedirectToAction("Index");
        }

        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home", new { area = "Common" });
        }
	}
}