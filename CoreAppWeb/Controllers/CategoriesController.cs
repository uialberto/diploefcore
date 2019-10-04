using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Uialberto.Northwind.Entities;
using Uialberto.Northwind.Services;

namespace CoreAppWeb.Controllers
{
    public class CategoriesController : Controller
    {
        private ICategoryRepo _repo;
        public CategoriesController(ICategoryRepo pRepo)
        {
            this._repo = pRepo;
        }
        public IActionResult Create(string name, string descripcion)
        {
            IActionResult result = null;
            var category = new Category() { 
                CategoryName = name, 
                Description = descripcion
            };
            category = _repo.Create(category);
            if (category != null)
            {
                result = Content($"Entidad Insertada: {category.CategoryID}");
            }
            else
            {
                result = Content($"No se inserto la categoria");
            }
            return result;

        }

        public IActionResult GetCategorie(int id) 
        {
            IActionResult result = null;

            var category = _repo.GetById(id);
            if (category != null)
            {
                result = Content($"Entidad Encontrada: Id: {category.CategoryID}, Name:{category.CategoryName}");
            }
            else
            {
                result = Content($"No se encontro la categoria");
            }
            return result;
        }

        public IActionResult Update(int id, string name, string descripcion)
        {
            IActionResult result = null;
            var category = new Category()
            {
                CategoryID = id,
                CategoryName = name,
                Description = descripcion
            };
            var process = _repo.Update(category);
            if (process)
            {
                result = Content($"Entidad Modificada.");
            }
            else
            {
                result = Content($"Not Modify");
            }
            return result;

        }

        public IActionResult DeleteById(int id, bool withLog = false)
        {
            IActionResult result = null;

            var process = withLog ? _repo.DeleteWithLog(id) : _repo.Delete(id);
            if (process)
            {
                result = Content($"Entidad Eliminada.");
            }
            else
            {
                result = Content($"Not Delete");
            }
            return result;
        }

        public IActionResult GetAll()
        {
            var model = _repo.GetAll();
            return View(model);

        }

    }
}