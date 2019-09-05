using BusinessManagementSystemApp.Models.Models;
using BusinessManagementSystemApp.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessManagementSystemApp.Models;

namespace BusinessManagementSystemApp.BLL.Manager
{
    public class CategoryManager
    {
        CategoryRepository _categoryRepository = new CategoryRepository();
        public List<Category> SearchCategory(CategoryViewModel categoryViewModel)
        {
            return _categoryRepository.SearchCategory(categoryViewModel);
        }
        public bool IsExistCategory(CategoryViewModel categoryViewModel)
        {
            return _categoryRepository.IsExistCategory(categoryViewModel);
        }
        public bool SaveCategory(Category category)
        {
            return _categoryRepository.SaveCategory(category);
        }
        public bool UpdateCategory(Category category)
        {
            return _categoryRepository.UpdateCategory(category);
        }
        public bool DeleteCategory(Category category)
        {
            return _categoryRepository.DeleteCategory(category);
        }
        public List<Category> GetCategories()
        {
            return _categoryRepository.GetCategories();
        }
        public Category CategoryGetById(Category category)
        {
            return _categoryRepository.CategoryGetById(category);
        }
    }
}
