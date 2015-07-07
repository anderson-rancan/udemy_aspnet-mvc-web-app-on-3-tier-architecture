using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using LinkHub.BLL;

namespace LinkHub.UI.Areas.Common.Controllers
{
    // HACK - atributo AllowAnonymous vai permitir acessar a página sem autenticação, contradizendo a diretiva em Global.asax.cs
    [AllowAnonymous]
    public abstract class BaseCommonController : Controller
    {
        protected AdminBs objBs;

        public BaseCommonController()
        {
            this.objBs = new AdminBs();
        }
	}
}