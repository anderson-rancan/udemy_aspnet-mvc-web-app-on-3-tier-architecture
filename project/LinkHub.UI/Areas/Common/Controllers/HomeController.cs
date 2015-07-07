using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LinkHub.UI.Areas.Common.Controllers
{
    public class HomeController : BaseCommonController
    {
        //
        // GET: /Common/Home/
        public ActionResult Index()
        {
            return View();
        }
	}
}