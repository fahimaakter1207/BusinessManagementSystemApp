using BusinessManagementSystemApp.DatabaseContext.DatabaseContext;
using BusinessManagementSystemApp.Models.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessManagementSystemApp.Repository.Repository
{
    public class CategoryRepository
    {
        BusinessManagementDbContext db = new BusinessManagementDbContext();
        public List<Category> SearchCategory(CategoryViewModel categoryViewModel)
        {
            var categories = db.Categories.Where(c =>c.CategoryName.ToLower().Contains(categoryViewModel.SearchText.ToLower()) && c.IsActive=="True" || c.CategoryCode.ToLower().Contains(categoryViewModel.SearchText.ToLower()) && c.IsActive=="True").ToList();
            return categories;
        }
        public bool IsExistCategory(CategoryViewModel categoryViewModel)
        {
            if (categoryViewModel.ActionType == "Insert")
            {
                var aCategory = db.Categories.Where(c => c.CategoryName.ToLower() == categoryViewModel.CategoryName.ToLower() && c.IsActive == "True").FirstOrDefault();
                if (aCategory != null)
                {
                    return true;
                }
            }
            if (categoryViewModel.ActionType == "Update")
            {
                var aCategory = db.Categories.Where(c => c.CategoryName.ToLower() == categoryViewModel.CategoryName.ToLower() && c.IsActive == "True").FirstOrDefault();
                if (aCategory != null)
                {
                    if (aCategory.CategoryId == categoryViewModel.CategoryId)
                    {
                        return false;
                    }
                    return true;
                }
                else
                {
                    return false;
                }
            }

            return false;
        }
        public bool SaveCategory(Category category)
        {
            db.Categories.Add(category);
            return db.SaveChanges() > 0;
        }
        public bool UpdateCategory(Category category)
        {
            db.Entry(category).State = EntityState.Modified;
            return db.SaveChanges() > 0;
        }
        public bool DeleteCategory(Category category)
        {
            db.Entry(category).State = EntityState.Modified;
            return db.SaveChanges() > 0;
        }
        public List<Category> GetCategories()
        {
            return db.Categories.Where(c => c.IsActive == "True").ToList();
        }
        public Category CategoryGetById(Category category)
        {
            var aCategory = db.Categories.FirstOrDefault(c => c.CategoryId == category.CategoryId);
            return aCategory;
        }
    }
}
