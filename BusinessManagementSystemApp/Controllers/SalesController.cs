using AutoMapper;
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
    public class SalesController : Controller
    {
        SalesManager _salesManager = new SalesManager();
        private SalesDetails _salesDetails = new SalesDetails();
        private Sale sale = new Sale();
        CustomerManager _customerManager = new CustomerManager();
        ProductManager _productManager = new ProductManager();
        // GET: Sales
        [HttpGet]
        public ActionResult Save()
        {
            SalesSaveViewModel salesModelVm = new SalesSaveViewModel();
            salesModelVm.CustomerList = _customerManager.FindAll().Select(c => new SelectListItem()
            {
                Value = c.Id.ToString(),
                Text = c.CustName
            });
            return View(salesModelVm);
        }
        [HttpPost]
        public ActionResult Save(SalesSaveViewModel salesModelVm)
        {
            if (ModelState.IsValid)
            {
                SalesDetails salesModel = new SalesDetails();
                salesModel = Mapper.Map<SalesDetails>(salesModelVm);
                if (_salesManager.Save(salesModel))
                {
                    TempData["SuccessMessage"] = "Data Saved SuccessFully!";
                    ViewBag.SuccessMsg = "Data Saved SuccessFully!";
                }
                else
                {
                    TempData["SuccessDeleteMessage"] = "Record Delete Successfully";
                    ViewBag.FailMsg = "Data Saved Fail!";
                }
            }
            else
            {
                TempData["SuccessDeleteMessage"] = "Record Delete Successfully";
                ViewBag.FailMsg = "Data Validtion Fail!";
            }
            salesModelVm.CustomerList = _customerManager.FindAll().Select(c => new SelectListItem()
            {
                Value = c.Id.ToString(),
                Text = c.CustName
            });
            return View(salesModelVm);
        }
        public ActionResult Delete(Sale sale)
        {
            sale.Id = sale.Id;

            if (_salesManager.Delete(sale))
            {
                ViewBag.SuccessMsg = "Data Delete SuccessFully!";
                TempData["SuccessDeleteMessage"] = "Record Delete Successfully";
                return RedirectToAction("FindAll");
            }
            else
            {
                ViewBag.FailMsg = "Data Delete Fail!";
                TempData["SuccessMessage"] = "Data Delete Fail!";
                return RedirectToAction("FindAll");
            }

            return View();
        }
        [HttpGet]
        public ActionResult FindAll(SalesSaveViewModel salesSaveViewModel)
        {
            SalesSaveViewModel salesSaveVM = new SalesSaveViewModel();

            salesSaveVM.SalesList = _salesManager.FindAll();

            salesSaveVM.CustomerList = _customerManager.FindAll()
                .Select(c => new SelectListItem()
                {
                    Value = c.Id.ToString(),
                    Text = c.CustName
                });
            return View(salesSaveVM);
        }
        [HttpPost]
        public ActionResult FindAll(CustomerModel customerModel)
        {
            SalesSaveViewModel salesSaveVM = new SalesSaveViewModel();
            var customers = _customerManager.FindAll();
            if (customerModel.CustName != null)
            {
                customers = customers.Where(c => c.CustName.ToLower().Contains(customerModel.CustName.ToLower())).ToList();
            }

            foreach (var v in customers)
            {
                customerModel.Id = v.Id;
            }
            var salesList = _salesManager.FindAll();
            if (customerModel != null)
            {
                salesList = salesList.Where(c => c.CustomerModelsId == customerModel.Id).ToList();
            }

            salesSaveVM.SalesList = salesList;

            salesSaveVM.CustomerList = _customerManager.FindAll()
                .Select(c => new SelectListItem()
                {
                    Value = c.Id.ToString(),
                    Text = c.CustName
                });
            return View(salesSaveVM);
        }

        public ActionResult BatchSalesAdd()
        {
            var customers = _customerManager.FindAll();
            ViewBag.Customers = new SelectList(customers, "Id", "CustName");

            var products = _productManager.GetProducts();
            ViewBag.Products = new SelectList(products, "ProductId", "ProductName");

            return View();
        }

        [HttpPost]
        public ActionResult BatchSalesAdd(SalesSaveViewModel Model)
        {
            sale.CustomerModelsId = Model.CustomerModelsId;
            int loyaltyPoint = (Convert.ToInt32(Model.CustomerPayment) / 1000);
            CustomerModel customer = new CustomerModel();
            customer.Id = sale.CustomerModelsId;
            var aCustomer = _customerManager.FindById(customer);
            if (Model.Discount > 0)
            {
                aCustomer.CustLoyaltyPoints = aCustomer.CustLoyaltyPoints - (Convert.ToInt32(Model.Discount * 10));
            }
            else
            {
                aCustomer.CustLoyaltyPoints = aCustomer.CustLoyaltyPoints + loyaltyPoint;
            }


            sale.Date = Model.Date;
            sale.Comments = Model.Comments;
            sale.CustomerPayment = Model.CustomerPayment;
            sale.SalesDetailsList = Model.SalesDetailsList;
            if (_salesManager.SaveSalesProduct(sale))
            {
                if (_customerManager.Update(aCustomer))
                {
                    var customersList = _customerManager.FindAll();
                    ViewBag.Customers = new SelectList(customersList, "Id", "CustName");

                    var products = _productManager.GetProducts();
                    ViewBag.Products = new SelectList(products, "ProductId", "ProductName");
                    TempData["SuccessMessage"] = "Data Saved SuccessFully!";
                    ViewBag.SuccessMsg = "Data Saved SuccessFully!";
                    return View();
                }

            }
            else
            {
                ViewBag.FailMsg = "Data Saved Fail!";
            }


            //var salesModel = new List<SalesDetails>();

            //if (ModelState.IsValid)
            //{
            //   // Model.CustomerModelsId = 1;

            //    int CustId = Model.CustomerModelsId;
            //    foreach (var value in Model.SalesDetailsList)

            //    {
            //        salesModel.Add(value);
            //    }
            //    if (_salesManager.Save(salesModel))
            //    {
            //        ViewBag.SuccessMsg = "Data Saved SuccessFully!";
            //    }
            //    else
            //    {
            //        ViewBag.FailMsg = "Data Saved Fail!";
            //    }
            //}



            //Model.ProductList = _productManager.GetAll()
            //    .Select(c => new SelectListItem()
            //    {
            //        Value = c.ID.ToString(),
            //        Text = c.Name
            //    }).ToList();
            //var customers = _customerManager.FindAll();
            //ViewBag.Customers = new SelectList(customers, "Id", "CustName");

            //var products = _productManager.GetAll();
            //ViewBag.Products = new SelectList(products, "ID", "Name");

            return View(Model);
        }
        public JsonResult GetCustLoyaltyPoints(int CustId)
        {
            var customer = _salesManager.GetCustLoyaltyPoints(CustId);

            return Json(customer, JsonRequestBehavior.AllowGet);
        }
        public JsonResult ProductDetails(int ProId)
        {
            var Product = _salesManager.ProductDetails(ProId);

            return Json(Product, JsonRequestBehavior.AllowGet);
        }
        public ActionResult VoucherDetails(int voucherNo)
        {

            var vouchweDetails = _salesManager.VoucherDetails(voucherNo);
            SalesSaveViewModel salesSaveView = new SalesSaveViewModel();
            foreach (var p in vouchweDetails)
            {
                SalesDetails s = new SalesDetails();
                s.Quantity = p.Quantity;
                s.UnitPrice = p.UnitPrice;
                s.ProductsId = p.ProductsId;
                s.SubTotal = p.SubTotal;
                salesSaveView.SalesDetailsList.Add(s);
            }
            return PartialView("Shared/_SalesDetails", salesSaveView);
        }

    }
}