using LinkHub.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LinkHub.UI.Areas.Admin.Controllers
{
    public class ListUserController : BaseAdminController
    {
        public const string AscendingOrder = "Asc";
        public const string DescendingOrder = "Desc";
        public const double PageCount = 10;

        //
        // GET: /Admin/ListUser/
        public ActionResult Index(string sortOrder, string sortBy, string page)
        {
            ViewBag.SortOrder = sortOrder;
            ViewBag.SortBy = sortBy;

            var users = this.objBs.User.GetAll();
            bool desc = string.Equals(sortOrder, DescendingOrder, StringComparison.OrdinalIgnoreCase);
            if (string.IsNullOrWhiteSpace(sortBy)) sortBy = "UserEmail";

            switch (sortBy)
            {
                case "UserEmail":
                    if (desc)
                        users = users.OrderByDescending(k => k.UserEmail);
                    else
                        users = users.OrderBy(k => k.UserEmail);
                    break;
                case "Role":
                    if (desc)
                        users = users.OrderByDescending(k => k.Role);
                    else
                        users = users.OrderBy(k => k.Role);
                    break;
            }

            ViewBag.TotalPages = Math.Ceiling(users.Count() / PageCount);

            int thisPage = int.Parse(string.IsNullOrWhiteSpace(page) ? "1" : page);
            ViewBag.Page = thisPage;
            users = users.Skip((thisPage - 1) * 10).Take(10);

            return View(users);
        }
    }
}