using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMS.Models;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace CMS.Controllers
{
    public class CustomerController : Controller
    {
        private cusDBContext _Customer;

        public CustomerController(cusDBContext customer)
        {
            _Customer = customer;
        }
        public async Task<IActionResult> Index()
        {
            var data =await _Customer.Customers.ToListAsync();
            return View(data);
        }
        public async Task<IActionResult> Location()
        {
            var loc =await  _Customer.Locations.ToListAsync();
            return View(loc);
        }

        public IActionResult CustomerList(int id)
        {
            var customers = _Customer.Customers.Where(m => m.Location.locId == id);
            return View(customers);
        }

        public IActionResult CustomerDetail(int id)
        {
            var customers = _Customer.Customers.SingleOrDefault(m => m.cusId == id);  // LINQ Query
            return View(customers);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Customer cobj)
        {
            if (ModelState.IsValid)
            {
                string ImageName = UploadedFile(cobj);
                cobj.cusImage = ImageName;
                _Customer.Customers.Add(cobj);
                int n = await _Customer.SaveChangesAsync();
                if (n != 0)
                {
                    TempData["insert"] = "<script>alert('Customer Added SuccessFully!!')</script>";
                }
                else
                {
                    TempData["insert"] = "<script>alert('Customer Failed !!')</script>";
                }
                return RedirectToAction("Index");
            }
            return View();
        }
        private string UploadedFile(Customer objcus)
        {
            //save image file into folder
            string uniqueFileName = null;
            if (objcus.cusImageFile != null)
            {
                string uploadsFolder = Path.GetFullPath("wwwroot") + "\\images";
                uniqueFileName = Guid.NewGuid().ToString() + "_" + objcus.cusImageFile.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var FileStream = new FileStream(filePath, FileMode.Create))
                {
                    objcus.cusImageFile.CopyTo(FileStream);
                }
            }
            return uniqueFileName;
        }

        public async Task<IActionResult> Edit(int id)
        {
            var row = await _Customer.Customers.Where(m => m.cusId == id).FirstOrDefaultAsync();
            return View(row);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Customer cobj)
        {
            if (ModelState.IsValid)
            {
                string ImageName = UploadedFile(cobj);
                cobj.cusImage = ImageName;
                _Customer.Entry(cobj).State = EntityState.Modified;
                int n = await _Customer.SaveChangesAsync();
                if (n != 0)
                {
                    TempData["update"] = "<script>alert('Customer Updated SuccessFully!!')</script>";
                }
                else
                {
                    TempData["update"] = "<script>alert('Customer Updation Failed !!')</script>";
                }
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> Delete(int id)
        {
            var deleterow = await _Customer.Customers.Where(m => m.cusId == id).FirstOrDefaultAsync();
            return View(deleterow);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Customer cobj)
        {
            if (ModelState.IsValid)
            {
                string ImageName = UploadedFile(cobj);
                cobj.cusImage = ImageName;
                _Customer.Entry(cobj).State = EntityState.Deleted;
                int n = await _Customer.SaveChangesAsync();
                if (n != 0)
                {
                    TempData["delete"] = "<script>alert('Customer Deleted SuccessFully!!')</script>";
                }
                else
                {
                    TempData["delete"] = "<script>alert('Customer Deletion Failed !!')</script>";
                }
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var employees = await _Customer.Customers.FirstOrDefaultAsync(m => m.cusId == id);

            if (employees == null)
            {
                return NotFound();
            }
            return View(employees);
        }
    }
}
