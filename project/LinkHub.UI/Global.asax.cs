using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace LinkHub.UI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            // HACK - acrescenta autorização obrigatória em todas páginas que não possuem atributo especificando o contrário
            GlobalFilters.Filters.Add(new AuthorizeAttribute());
        }
    }
}
