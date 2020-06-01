using System;
using System.Collections.Generic;
using System.Text;
using Uialberto.Northwind.Entities;

namespace Uialberto.Northwind.Services
{
    public interface ICategoryRepo
    {
        Category Create(Category category);
        Category GetById(int categoryId);
        bool Update(Category category);
        bool Delete(int categoryId);
        List<Category> GetAll();
        bool DeleteWithLog(int categoryId);
    }
}
