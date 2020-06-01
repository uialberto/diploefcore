using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Uialberto.Northwind.Services;

namespace CoreAppWeb.Controllers
{
    public class LogsController : Controller
    {
        private ILogRepo _repo;
        public LogsController(ILogRepo pRepo)
        {
            this._repo = pRepo;
        }
        public IActionResult GetAll()
        {
            var model = _repo.GetAll();
            return View(model);

        }
    }
}