using BusinessManagementSystemApp.BLL.Manager;
using BusinessManagementSystemApp.Models;
using BusinessManagementSystemApp.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BusinessManagementSystemApp.Controllers
{
    public class StockController : Controller
    {
        StockManager _stockManager = new StockManager();
        ProductManager _productManager = new ProductManager();
        CategoryManager _categoryManager = new CategoryManager();
        Product _product = new Product();


        // GET: Stock
        public ActionResult Search()
        {

            return View();
        }



        [HttpPost]
        public ActionResult Search(StockVM  stockVM, DateTime startDate, DateTime endDate)
        {


            _product.ProductName = stockVM.ProductName;
            _product.CategoryName = stockVM.CategoryName;
            try
            {
                List<StockVM> products = _productManager.GetProductsWithCatagory(_product).Select(c => new StockVM
                {
                    ProductName = c.ProductName,
                    CategoryName = c.Category.CategoryName,
                    ReorderLevel = c.ReorderLevel,
                    Code = c.ProductCode,
                }).ToList();

                foreach (var product in products)
                {
                    Product pro = new Product();
                    pro.ProductName = product.ProductName;
                    var availableQuantity = _productManager.AvailableQuantity(pro);
                    var expireDate = _productManager.PurchaseDetails(pro, startDate, endDate);
                    foreach (var item in products)
                    {
                        if (item.ProductName == pro.ProductName)
                        {
                            item.ExpireDate = expireDate.ExpireDate;
                            item.Quantity = availableQuantity.Quantity;
                            TempData["SuccessMessage"] = "Search Successfully";
                        }

                    }
                }
                ViewBag.Products = products;
            }
            catch (Exception ex)
            {
                TempData["SuccessMessage"] = "Search data not found";
            }
            return View();
        }
        public ActionResult SearchByReorderLevel()
        {

            return View();
        }



        [HttpPost]
        public ActionResult SearchByReorderLevel(StockVM stockVM)
        {


            _product.ProductName = stockVM.ProductName;
            _product.CategoryName = stockVM.CategoryName;
                List<StockVM> products = _productManager.GetProductsWithCatagory(_product).Select(c => new StockVM
                {
                    ProductName = c.ProductName,
                    CategoryName = c.Category.CategoryName,
                    ReorderLevel = c.ReorderLevel,
                    Code = c.ProductCode,
                }).ToList();

                foreach (var product in products)
                {
                    Product pro = new Product();
                    pro.ProductName = product.ProductName;
                    pro.ProductCode = product.Code;
                    pro.CategoryName = product.CategoryName;
                    pro.ReorderLevel = product.ReorderLevel;
                    var availableQuantity = _productManager.AvailableQuantity(pro);
                    foreach (var item in products)
                    {
                        if (item.ProductName == pro.ProductName)
                        {
                      
                            item.Code = pro.ProductCode;
                            item.ProductName= pro.ProductName;
                            item.CategoryName = pro.CategoryName;
                            item.ReorderLevel = pro.ReorderLevel;
                            item.Quantity =availableQuantity.Quantity ;

                        }

                    }
                }

            return View(stockVM);
        }
    }
}