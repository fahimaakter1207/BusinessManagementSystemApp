using AutoMapper;
using BusinessManagementSystemApp.BLL.BLL;
using BusinessManagementSystemApp.BLL.Manager;
using BusinessManagementSystemApp.Models;
using BusinessManagementSystemApp.Models.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace BusinessManagementSystemApp.Controllers
{
    public class SupplierController : Controller
    {
        SupplierManager _supplierManager = new SupplierManager();
        SupplierVM _supplierVM = new SupplierVM();
        private Supplier _supplier = new Supplier();
        string _fileName = string.Empty;
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        // GET: Suppliers
        [HttpPost]
        public ActionResult Add(SupplierVM supplierVM, HttpPostedFileBase image)
        {

            if (ModelState.IsValid)
            {
                _fileName = Path.GetFileNameWithoutExtension(image.FileName);
                string extension = Path.GetExtension(image.FileName);
                _fileName = supplierVM.Name + _fileName + DateTime.Now.ToString("yymmssfff") + extension;
                supplierVM.Image = "~/images/SupplierImage/" + _fileName;

                //Supplier supplier = new Supplier();
                var supplier = Mapper.Map<Supplier>(supplierVM);
                if (_supplierManager.Add(supplier))
                {
                    _fileName = Path.Combine(Server.MapPath("~/images/SupplierImage/"), _fileName);
                    image.SaveAs(_fileName);
                    ViewBag.SuccessMsg = "Saved";
                    TempData["SuccessMessage"] = "Saved Successfully";
                    return RedirectToAction("Show");


                }
                else
                {
                    ViewBag.FailMsg = "Save Failed!!";
                }
            }
            else
            {
                ViewBag.FailMsg = "Validation Error!!";
            }

            return View(supplierVM);
        }
        [HttpGet]
        public ActionResult Delete(int Id)
        {
            _supplier.Id = Id;
            var supplier = _supplierManager.GetByID(_supplier);
            _supplierVM = Mapper.Map<SupplierVM>(supplier);
            return View(_supplierVM);
        }
        [HttpPost]
        public ActionResult Delete(SupplierVM supplierVM, HttpPostedFileBase image)
        {
            //fileName = Path.GetFileNameWithoutExtension(image.FileName);
            //string extension = Path.GetExtension(image.FileName);
            //fileName = supplierVM.Name + fileName + DateTime.Now.ToString("yymmssfff") + extension;
            //supplierVM.Image = "~/images/SupplierImage/" + fileName;
            var supplier = Mapper.Map<Supplier>(supplierVM);
            if (ModelState.IsValid)
            {
                //fileName = Path.Combine(Server.MapPath("~/images/SupplierImage/"), fileName);
                if (_supplierManager.Delete(supplier))
                {
                    ViewBag.SuccessMsg = "Deleted";
                    TempData["SuccessDeleteMessage"] = "Record Delete Successfully";
                    return RedirectToAction("Show");
                }
                else
                {
                    ViewBag.FailMsg = "Failed";
                }

            }
            else
            {
                ViewBag.FailMsg = "Validation Error";
            }

            return View(supplierVM);
        }
        [HttpGet]
        public ActionResult Edit(int Id)
        {
            _supplier.Id = Id;
            var supplier = _supplierManager.GetByID(_supplier);
            _supplierVM = Mapper.Map<SupplierVM>(supplier);
            return View(_supplierVM);
        }
        [HttpPost]
        public ActionResult Edit(SupplierVM supplierVM, HttpPostedFileBase image)
        {
            //fileName = Path.GetFileNameWithoutExtension(image.FileName);
            //string extension = Path.GetExtension(image.FileName);
            //fileName = supplierVM.Name + fileName + DateTime.Now.ToString("yymmssfff") + extension;
            //supplierVM.Image = "~/images/SupplierImage/" + fileName;
            var supplier = Mapper.Map<Supplier>(supplierVM);
            if (ModelState.IsValid)
            {
                //fileName = Path.Combine(Server.MapPath("~/images/SupplierImage/"), fileName);
                if (_supplierManager.Update(supplier))
                {
                    ViewBag.SuccessMsg = "Updated";
                    TempData["SuccessMessage"] = "Updated Successfully";
                    return RedirectToAction("Show");


                }
                else
                {
                    ViewBag.FailMsg = "Failed";
                }
            }
            else
            {
                ViewBag.FailMsg = "Validation Error";
            }

            return View(supplierVM);
        }
        [HttpGet]
        public ActionResult Show()
        {
            _supplierVM.Suppliers = _supplierManager.GetAll();
            return View(_supplierVM);
        }
        [HttpPost]
        public ActionResult Show(SupplierVM supplierVM )
        {
            Supplier supplier = new Supplier();
            supplier = Mapper.Map<Supplier>(supplierVM);
            var suppliers = _supplierManager.GetAll();

            if (supplierVM.Name != null)
            {
                //students = students.Where(c => c.Name.Contains(student.Name)).ToList();
                TempData["SuccessMessage"] = "Search Successfully";
                suppliers = suppliers.Where(c => c.Name.ToLower().Contains(supplierVM.Name.ToLower())).ToList();
            }
            if (supplierVM.Address != null)
            {
                TempData["SuccessMessage"] = "Search Successfully";
                suppliers = suppliers.Where(c => c.Address.ToLower().Contains(supplierVM.Address.ToLower())).ToList();
            }
            if (supplierVM.Email != null)
            {
                TempData["SuccessMessage"] = "Search Successfully";
                suppliers = suppliers.Where(c => c.Email.ToLower().Contains(supplierVM.Email.ToLower())).ToList();
            }
            if (supplierVM.Contact > 0)
            {
                TempData["SuccessMessage"] = "Search Successfully";
                suppliers = suppliers.Where(c => c.Contact == supplierVM.Contact).ToList();
            }
            if (supplierVM.ContactPerson > 0)
            {
                TempData["SuccessMessage"] = "Search Successfully";
                suppliers = suppliers.Where(c => c.ContactPerson == supplierVM.ContactPerson).ToList();
            }
            supplierVM.Suppliers = suppliers;
            return View(supplierVM);
        }
        public JsonResult IsExistSupplierName(string supplierCode)
        {
            bool isExist = false;
            Supplier supplier = new Supplier();
            supplier.Code = supplierCode;
            isExist = _supplierManager.IsExistSupplier(supplier);
            return Json(isExist, JsonRequestBehavior.AllowGet);
        }
    }
}