using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Uialberto.Northwind.Entities;
using Uialberto.Northwind.Services;

namespace Uialberto.Northwind.DataAccess
{
    public class NorthwindRepo : INorthwindRepo, IDisposable
    {
        private NorthwindContext _context;
        private bool _isUnitOfWork;

        public NorthwindRepo(bool isUow = false)
        {
            this._context = new NorthwindContext();
            this._isUnitOfWork = isUow;
        }
        public int SaveChanges()
        {
            var result = 0;
            if (_context != null)
            {
                try
                {
                    result = _context.SaveChanges();
                }
                catch (Exception ex)
                {
                    var mensaje = ex.Message;
                    //ToDo Gestionar Excepciones
                }                
            }
            return result;
        }

        private bool Save()
        {
            int changes = 0;
            if (!_isUnitOfWork)
            {
                changes = SaveChanges();
            }
            return changes == 1;
        }

        public Category CreateCategory(Category category)
        {
            category = _context.Add(category).Entity;
            Save();
            return category;
        }

        public Category GetCategoryById(int categoryId)
        {
            return _context.Find<Category>(categoryId);
        }

        public bool UpdateCategory(Category category)
        {
            _context.Update(category);
            return Save();
        }

        public bool DeleteCategory(int categoryId)
        {
            _context.Remove(new Category() { CategoryID = categoryId });
            return Save();
        }

        public List<Category> GetCategories()
        {
            return _context.Categories.ToList();
        }

        public List<Log> GetLogs()
        {
            return _context.Logs.ToList();
        }

        public Log CreateLog(Log log)
        {
            log = _context.Add(log).Entity;
            Save();
            return log;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

    }
}
