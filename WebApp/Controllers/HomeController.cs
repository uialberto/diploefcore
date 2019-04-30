using Diplomado.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AppContext = Diplomado.DataAccess.AppContext;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var categories = new List<Category>();
            using (var context = new AppContext())
            {
                categories = context.Categories.ToList();
            }
            return View(categories);
        }
        [HttpPost]
        public ActionResult Index(string categoryName)
        {            
            using (var context = new AppContext())
            {
                var entity = new Category()
                {
                    CategoryName = categoryName
                };
                context.Categories.Add(entity);
                var result = context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}