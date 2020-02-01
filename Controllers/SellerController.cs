using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CaseStudy.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CaseStudy.Controllers
{
    public class SellerController : Controller
    {
        // GET: Seller

        private readonly SellerContext _context;
        private readonly IWebHostEnvironment hostingEnvironment;
        public SellerController(SellerContext context, IWebHostEnvironment hostingEnvironment)
        {
            this._context = context;
            this.hostingEnvironment = hostingEnvironment;
        }
        public ActionResult Home()
        {
            return View();
        }
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult SellerRegister()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SellerRegister(SellerCreateView model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = null;

                // If the Photo property on the incoming model object is not null, then the user
                // has selected an image to upload.
                if (model.Photopath != null)
                {
                    // The image must be uploaded to the images folder in wwwroot
                    // To get the path of the wwwroot folder we are using the inject
                    // HostingEnvironment service provided by ASP.NET Core
                    string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                    // To make sure the file name is unique we are appending a new
                    // GUID value and and an underscore to the file name
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Photopath.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    // Use CopyTo() method provided by IFormFile interface to
                    // copy the file to wwwroot/images folder
                    model.Photopath.CopyTo(new FileStream(filePath, FileMode.Create));
                }

                Seller sel = new Seller
                {
                    Sname = model.Sname,
                    Spassword = model.Spassword,
                    Companyname = model.Companyname,
                    Saddress = model.Saddress,
                    Contactno = model.Contactno,
                    Semail = model.Semail,
                    SID = model.SID,

                    // Store the file name in PhotoPath property of the employee object
                    // which gets saved to the Employees database table
                    PhotoPath = uniqueFileName
                };

                _context.Add(sel);
                _context.SaveChanges();
                return RedirectToAction("Details", new { id = sel.SID});
            }
                 return View();

        }
        public ActionResult Details(int id)
        {
            Seller sel = _context.Sellers.FirstOrDefault(e => e.SID == id);
            return View(sel);
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(Seller sel)
        {
            var loginuser = _context.Sellers.Where(e => e.Sname ==sel.Sname&& e.Spassword ==sel.Spassword).ToList();
            if (loginuser.Count == 0)
            {
                ViewBag.message = "not valid";
                return View();

            }
            else
            {

                HttpContext.Session.SetString("SName",sel.Sname);
                Response.Cookies.Append("lastLogin", DateTime.Now.ToString());
                HttpContext.Session.SetString("llogin", DateTime.Now.ToString());

                return RedirectToAction("SellerDashBoard");

            }
        }
        public ActionResult SellerDashBoard()
        {
            if (HttpContext.Session.GetString("SName") != null)
            {

                ViewBag.Sname = HttpContext.Session.GetString("SName").ToString();
                ViewBag.lldt = HttpContext.Session.GetString("llogin").ToString();
                return View();
            }
            if (Request.Cookies["lastlogin"] != null)
            {
                ViewBag.lld = Request.Cookies["lastlogin"].ToString();
                return View();
            }
            return View();
        }
        public ActionResult logout()
        {
            Response.Cookies.Append("lastlogin", DateTime.Now.ToString());
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }





        // GET: Seller/Details/5
        public ActionResult Create()
        {
            return View();
        }

        // GET: Seller/Create
       

        // POST: Seller/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Seller/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Seller/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Seller/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Seller/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}