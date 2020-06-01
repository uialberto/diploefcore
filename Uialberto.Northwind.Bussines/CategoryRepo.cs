using System;
using System.Collections.Generic;
using System.Text;
using Uialberto.Northwind.DataAccess;
using Uialberto.Northwind.Entities;
using Uialberto.Northwind.Services;

namespace Uialberto.Northwind.Bussines
{
    public class CategoryRepo : ICategoryRepo
    {
        public Category Create(Category category)
        {
            if (!string.IsNullOrWhiteSpace(category.CategoryName))
            {
                using (var repo = NorthwindRepoFactory.GetNorthwindRepo())
                {
                    category = repo.CreateCategory(category);
                }
            }
            else
            {
                category = null;
            }
            return category;
        }

        public bool Delete(int categoryId)
        {
            var result = false;
            using (var repo = NorthwindRepoFactory.GetNorthwindRepo())
            {
                result = repo.DeleteCategory(categoryId);
            }
            return result;
        }

        public bool DeleteWithLog(int categoryId)
        {
            var result = false;
            using (var repo = NorthwindRepoFactory.GetNorthwindRepo(true))
            {
                repo.DeleteCategory(categoryId);
                var log = new Log()
                {
                    Type = LogType.DeleteCategory,
                    Message = $"ID:{categoryId}",
                    Fecha = DateTime.Now
                };
                repo.CreateLog(log);
                result = repo.SaveChanges() == 2;
            }
            return result;
        }

        public List<Category> GetAll()
        {
            return NorthwindRepoFactory.GetNorthwindRepo().GetCategories();
        }

        public Category GetById(int categoryId)
        {
            Category result = null;
            if (categoryId > 0)
            {
                using (var repo = NorthwindRepoFactory.GetNorthwindRepo())
                {
                    result = repo.GetCategoryById(categoryId);
                }
            }
            return result;
        }

        public bool Update(Category category)
        {
            var result = false;
            using (var repo = NorthwindRepoFactory.GetNorthwindRepo())
            {
                result = repo.UpdateCategory(category);
            }
            return result;
        }
    }
}
