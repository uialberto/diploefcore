using System;
using System.Collections.Generic;
using System.Text;
using Uialberto.Northwind.Entities;

namespace Uialberto.Northwind.Services
{
    public interface INorthwindRepo : IDisposable
    {
        #region Categories
        
        Category CreateCategory(Category category);
        Category GetCategoryById(int categoryId);
        bool UpdateCategory(Category category);
        bool DeleteCategory(int categoryId);
        List<Category> GetCategories();

        #endregion

        #region Logs
        
        List<Log> GetLogs();
        Log CreateLog(Log log);

        #endregion

        #region UnitOfWork

        int SaveChanges();

        #endregion

    }
}
