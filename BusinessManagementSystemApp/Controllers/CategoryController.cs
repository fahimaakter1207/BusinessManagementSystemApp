using BusinessManagementSystemApp.BLL.Manager;
using BusinessManagementSystemApp.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BusinessManagementSystemApp.Controllers
{
    public class CategoryController : Controller
    {
        CategoryManager _categoryManager = new CategoryManager();
        Category category = new Category();
        
        // GET: Category
        public ActionResult Index()
        {
            List<CategoryViewModel> categories = _categoryManager.GetCategories().Select(c=>new CategoryViewModel {CategoryId=c.CategoryId, CategoryName=c.CategoryName,CategoryCode=c.CategoryCode,IsActive=c.IsActive,Date=c.Date}).ToList();
            CategoryViewModel categoryViewModel = new CategoryViewModel();
            categoryViewModel.Categories = categories;
            return View(categoryViewModel);
        }
        [HttpPost]
        public ActionResult Index(CategoryViewModel categoryViewModel)
        {
            List<CategoryViewModel> categories = _categoryManager.SearchCategory(categoryViewModel).Select(c => new CategoryViewModel { CategoryId = c.CategoryId, CategoryName = c.CategoryName, CategoryCode = c.CategoryCode, IsActive = c.IsActive, Date = c.Date }).ToList();
            CategoryViewModel category = new CategoryViewModel();
            category.Categories = categories;
            return View(category);
        }
        public ActionResult SaveCategory()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SaveCategory(CategoryViewModel categoryViewModel)
        {
            if (ModelState.IsValid)
            {
                categoryViewModel.ActionType = "Insert";
                if (_categoryManager.IsExistCategory(categoryViewModel)==false)
                {
                    category.CategoryName = categoryViewModel.CategoryName;
                    category.CategoryCode = categoryViewModel.CategoryCode;
                    category.IsActive = categoryViewModel.IsActive;
                    category.Date = categoryViewModel.Date;
                    if (_categoryManager.SaveCategory(category))
                    {
                        TempData["SuccessMessage"] = "Data Saved SuccessFully!";
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ViewBag.Message = "Operation Failed!";
                    }
                }
                else
                {
                    TempData["SuccessDeleteMessage"] = "This category is already exist!";
                    ViewBag.Message = "This category is already exist!";
                }
            }
            else
            {
                ViewBag.Message = "Input Validation Error!";
            }
            return View(categoryViewModel);
        }
        public ActionResult UpdateCategory(int id)
        {
            if (id > 0)
            {
                category.CategoryId = id;
                var aCategory = _categoryManager.CategoryGetById(category);
                if (aCategory != null)
                {
                    CategoryViewModel categoryViewModel = new CategoryViewModel();
                    categoryViewModel.CategoryId = aCategory.CategoryId;
                    categoryViewModel.CategoryName = aCategory.CategoryName;
                    categoryViewModel.CategoryCode = aCategory.CategoryCode;
                    categoryViewModel.IsActive = aCategory.IsActive;
                    categoryViewModel.Date = aCategory.Date;
                    return View(categoryViewModel);
                }
                else
                {
                    ViewBag.Message = "No Data Found!";
                }
            }
            else
            {
                return HttpNotFound();
            }
            return View();
        }
        [HttpPost]
        public ActionResult UpdateCategory(CategoryViewModel categoryViewModel)
        {
            if (ModelState.IsValid)
            {
                categoryViewModel.ActionType = "Update";
                if (_categoryManager.IsExistCategory(categoryViewModel) == false)
                {
                    category.CategoryId = categoryViewModel.CategoryId;
                    category = _categoryManager.CategoryGetById(category);
                    category.CategoryName = categoryViewModel.CategoryName;
                    category.CategoryCode = categoryViewModel.CategoryCode;
                    category.IsActive = categoryViewModel.IsActive;
                    category.Date = categoryViewModel.Date;
                    if (_categoryManager.UpdateCategory(category))
                    {
                        TempData["SuccessMessage"] = "Data Update SuccessFully!";
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ViewBag.Message = "Opereation Failed!";
                    }
                }
                else
                {
                    ViewBag.Message = "This category is already exist!";
                }
            }
            else
            {
                ViewBag.Message = "Input Validation Failed";
            }
            return View(categoryViewModel);
        }
        public ActionResult GetCategoryDetails(int id)
        {
            if (id > 0)
            {
                category.CategoryId = id;
                var aCategory = _categoryManager.CategoryGetById(category);
                if (aCategory != null)
                {
                    CategoryViewModel categoryViewModel = new CategoryViewModel();
                    categoryViewModel.CategoryId = aCategory.CategoryId;
                    categoryViewModel.CategoryName = aCategory.CategoryName;
                    categoryViewModel.CategoryCode = aCategory.CategoryCode;
                    categoryViewModel.IsActive = aCategory.IsActive;
                    categoryViewModel.Date = aCategory.Date;
                    return View(categoryViewModel);
                }
            }
            else
            {
                return HttpNotFound();
            }
            return View();
        }
        
        public ActionResult DeleteCategory(int id)
        {
            if (id > 0)
            {
                category.CategoryId = id;
                var aCategory = _categoryManager.CategoryGetById(category);
                if (aCategory != null)
                {
                    CategoryViewModel categoryViewModel = new CategoryViewModel();
                    categoryViewModel.CategoryId = aCategory.CategoryId;
                    categoryViewModel.CategoryName = aCategory.CategoryName;
                    categoryViewModel.CategoryCode = aCategory.CategoryCode;
                    categoryViewModel.IsActive = aCategory.IsActive;
                    categoryViewModel.Date = aCategory.Date;
                    return View(categoryViewModel);
                }
                else
                {
                    return HttpNotFound();
                }
            }
            return View();
        }
        [HttpPost]
        public ActionResult DeleteCategory(CategoryViewModel categoryViewModel)
        {
            if (categoryViewModel.CategoryId > 0)
            {
                category.CategoryId = categoryViewModel.CategoryId;
                category.CategoryName = categoryViewModel.CategoryName;
                category.CategoryCode = categoryViewModel.CategoryCode;
                category.IsActive = categoryViewModel.IsActive;
                category.Date = categoryViewModel.Date;
                if (_categoryManager.DeleteCategory(category))
                {
                    TempData["SuccessDeleteMessage"] = "Record Delete Successfully";
                    return RedirectToAction("Index");
                }
            }
            return View();
        }
    }
}