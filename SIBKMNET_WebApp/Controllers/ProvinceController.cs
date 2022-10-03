using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SIBKMNET_WebApp.Context;
using SIBKMNET_WebApp.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SIBKMNET_WebApp.Controllers
{
    public class ProvinceController : Controller
    {
        MyContext myContext;

        public ProvinceController(MyContext myContext)
        {
            this.myContext = myContext;
        }
        public IActionResult Index()
        {
            var data = myContext.Provinces.Include( x => x.Region).ToList();
            return View(data);
        }

        //GET BY ID
        //GET
        [HttpGet]
        public IActionResult Details(int id)
        {
            var data = myContext.Provinces.Include(x => x.Region).FirstOrDefault( x => x.Id.Equals(id));
            return View(data);
        }
        //CREATE
        //GET
        //[HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Province country)
        {
           if(ModelState.IsValid)
            {
                myContext.Provinces.Add(country);
                var result = myContext.SaveChanges();
                if (result > 0)
                    return RedirectToAction("Index");
            }
           return View();
        }

        //UPDATE
        //GET
        [HttpGet]
        public IActionResult Update(int id)
        {
            var data = myContext.Provinces.Include(x => x.Region).FirstOrDefault(x => x.Id.Equals(id));
            return View(data);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Province country)
        {
            if (ModelState.IsValid)
            {
                myContext.Provinces.Update(country);
                var result = myContext.SaveChanges();
                if (result > 0)
                    return RedirectToAction("Index");
            }
            return View();
        }

        //DELETE
        //GET
        [HttpGet]
        public IActionResult Delete()
        {
            return View();
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Province country)
        {
            if (ModelState.IsValid)
            {
                myContext.Provinces.Remove(country);
                var result = myContext.SaveChanges();
                if (result > 0)
                    return RedirectToAction("Index");
            }
            return View();
        }
    }
}
