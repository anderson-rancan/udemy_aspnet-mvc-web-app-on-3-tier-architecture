using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using LinkHub.BLL;

namespace LinkHub.UI.Areas.Admin.Controllers
{
    [Authorize(Roles = "A")]
    public abstract class BaseAdminController : Controller
    {
        protected AdminBs objBs;

        public BaseAdminController()
        {
            this.objBs = new AdminBs();
        }
    }
}