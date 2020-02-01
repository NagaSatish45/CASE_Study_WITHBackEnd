using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CaseStudy.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CaseStudy.Controllers
{
    public class BuyerController : Controller
    {
        public readonly BuyerContext _context;
        public BuyerController(BuyerContext context)
        {
            this._context = context;

        }
        public ActionResult Index()
        {
             return View();
        }

        // GET: Buyer
        [HttpGet]
        public ActionResult BuyerRegister()
        {
            return View();
        }
        [HttpPost]
        public ActionResult BuyerRegister(Buyer buy)
        {
            try
            {
                _context.Add(buy);
                _context.SaveChanges();
                ViewBag.message = buy.Name + "  registration successful";
                return View();
            }
            catch (Exception e)
            {
                ViewBag.message =buy.Name  + "  registration failed ";
                return View();
            }

        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Buyer buy)
        {
            var loginuser = _context.Buyers.Where(e => e.Name == buy.Name && e.Password == buy.Password).ToList();
            if (loginuser.Count == 0)
            {
                ViewBag.message = "not valid";
                return View();

            }
            else
            {
                HttpContext.Session.SetString("Name",buy.Name);
                Response.Cookies.Append("lastLogin",DateTime.Now.ToString());
                HttpContext.Session.SetString("lastlogin", DateTime.Now.ToString());

                return RedirectToAction("DashBoard");
               
            }
        
        }

        public ActionResult DashBoard()
        {
            if (HttpContext.Session.GetString("Name") != null)
            {

                ViewBag.Bname = HttpContext.Session.GetString("Name").ToString();
                ViewBag.lldt = HttpContext.Session.GetString("lastlogin").ToString();
                return View();
            }
            if (Request.Cookies["lastlogin"] != null)
            {
                ViewBag.lldt = Request.Cookies["lastlogin"].ToString();
                return View();
            }
            return View();
        }
        public ActionResult logout()
        {
            Response.Cookies.Append("lastlogin",DateTime.Now.ToString());
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }

        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Buyer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Buyer/Create
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

        // GET: Buyer/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Buyer/Edit/5
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

        // GET: Buyer/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Buyer/Delete/5
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