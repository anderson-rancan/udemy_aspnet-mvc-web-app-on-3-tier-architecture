using LinkHub.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LinkHub.UI.Areas.Admin.Controllers
{
    public class ListCategoryController : Controller
    {

        public const string AscendingOrder = "Asc";
        public const string DescendingOrder = "Desc";
        public const double PageCount = 10;

        private AdminBs objBs;

        public ListCategoryController()
        {
            this.objBs = new AdminBs();
        }

        //
        // GET: /Admin/ListCategory/
        public ActionResult Index(string sortOrder, string sortBy, string page)
        {
            ViewBag.SortOrder = sortOrder;
            ViewBag.SortBy = sortBy;

            var categories = this.objBs.Category.GetAll();
            bool desc = string.Equals(sortOrder, DescendingOrder, StringComparison.OrdinalIgnoreCase);
            if (string.IsNullOrWhiteSpace(sortBy)) sortBy = "CategoryName";

            switch (sortBy)
            {
                case "CategoryName":
                    if (desc)
                        categories = categories.OrderByDescending(k => k.CategoryName);
                    else
                        categories = categories.OrderBy(k => k.CategoryName);
                    break;
                case "CategoryDesc":
                    if (desc)
                        categories = categories.OrderByDescending(k => k.CategoryDesc);
                    else
                        categories = categories.OrderBy(k => k.CategoryDesc);
                    break;
            }

            ViewBag.TotalPages = Math.Ceiling(categories.Count() / PageCount);

            int thisPage = int.Parse(string.IsNullOrWhiteSpace(page) ? "1" : page);
            ViewBag.Page = thisPage;
            categories = categories.Skip((thisPage - 1) * 10).Take(10);

            return View(categories);
        }

        public ActionResult Delete(int id)
        {
            try
            {
                this.objBs.Category.Delete(id);
                TempData["Msg"] = "Deleted successfully";
            }
            catch (Exception ex)
            {
                TempData["Msg"] = "Delete failed: " + ex.Message;
            }

            return this.RedirectToAction("Index");
        }

	}
}