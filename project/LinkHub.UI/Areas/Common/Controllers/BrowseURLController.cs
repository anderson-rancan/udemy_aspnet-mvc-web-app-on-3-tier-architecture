using LinkHub.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LinkHub.UI.Areas.Common.Controllers
{
    public class BrowseURLController : Controller
    {

        public const string AscendingOrder = "Asc";
        public const string DescendingOrder = "Desc";
        public const double PageCount = 10;

        private AdminBs objBs;

        public BrowseURLController()
        {
            this.objBs = new AdminBs();
        }

        //
        // GET: /Common/BrowseURL/
        public ActionResult Index(string sortOrder, string sortBy, string page)
        {
            ViewBag.SortOrder = sortOrder;
            ViewBag.SortBy = sortBy;

            var urls = this.objBs.Url.GetAll().Where(p => string.Equals(p.IsApproved, "A", StringComparison.OrdinalIgnoreCase));
            bool desc = string.Equals(sortOrder, DescendingOrder, StringComparison.OrdinalIgnoreCase);
            if (string.IsNullOrWhiteSpace(sortBy)) sortBy = "Title";

            switch (sortBy)
            {
                case "Title":
                    if (desc)
                        urls = urls.OrderByDescending(k => k.UrlTitle);
                    else
                        urls = urls.OrderBy(x => x.UrlTitle);
                    break;
                case "Category":
                    if (desc)
                        urls = urls.OrderByDescending(k => k.tbl_Category.CategoryName);
                    else
                        urls = urls.OrderBy(k => k.tbl_Category.CategoryName);
                    break;
                case "Url":
                    if (desc)
                        urls = urls.OrderByDescending(k => k.UrlTitle);
                    else
                        urls = urls.OrderBy(k => k.UrlTitle);
                    break;
                case "UrlDesc":
                    if (desc)
                        urls = urls.OrderByDescending(k => k.UrlDesc);
                    else
                        urls = urls.OrderBy(k => k.UrlDesc);
                    break;
            }

            ViewBag.TotalPages = Math.Ceiling(urls.Count() / PageCount);

            int thisPage = int.Parse(string.IsNullOrWhiteSpace(page) ? "1" : page);
            ViewBag.Page = thisPage;
            urls = urls.Skip((thisPage - 1) * 10).Take(10);

            return View(urls);
        }
    }
}