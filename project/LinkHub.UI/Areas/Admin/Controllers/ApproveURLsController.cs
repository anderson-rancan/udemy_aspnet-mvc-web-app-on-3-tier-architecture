    using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using LinkHub.BLL;

namespace LinkHub.UI.Areas.Admin.Controllers
{
    public class ApproveURLsController : BaseAdminController
    {
        //
        // GET: /Admin/ApprovedURLs/
        public ActionResult Index(string status)
        {
            bool statusNull = string.IsNullOrWhiteSpace(status);
            ViewBag.Status = (statusNull ? "P" : status);

            var urls = objBs.Url.GetAll().Where(p => p.IsApproved == ViewBag.Status);
            return View(urls);
        }

        public ActionResult ChangeStatus(int id, string status)
        {
            try
            {
                var myUrl = objBs.Url.GetByID(id);
                myUrl.IsApproved = status;
                objBs.Url.Update(myUrl);
                TempData["Msg"] = "Status successfully changed";
            }
            catch (Exception ex)
            {
                TempData["Msg"] = "Status change failed: " + ex.Message;
            }

            return RedirectToAction("Index");
        }

	}
}