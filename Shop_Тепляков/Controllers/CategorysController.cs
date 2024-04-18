using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Shop_Тепляков.Data.Interfaces;
using Shop_Тепляков.Data.Models;
using System.Collections.Generic;
using System.IO;
using System;
using System.Linq;

namespace Shop_Тепляков.Controllers
{
    public class CategorysController : Controller
    {
        private readonly IHostingEnvironment hostingEnvironment;
        private ICategorys IAllCategorys;

        public CategorysController(ICategorys IAllCategorys) => this.IAllCategorys = IAllCategorys;

        public ViewResult List(string search)
        {
            ViewBag.Title = "Страница с категориями";
            var cars = IAllCategorys.FindCategorys(search);
            return View(cars);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public RedirectResult Add(string name, string description)
        {
            Categorys newCategory = new Categorys();
            newCategory.Name = name;
            newCategory.Description = description;
            int id = IAllCategorys.Add(newCategory);
            return Redirect("/Categorys/Update&id=" + id);
        }

        [HttpPost]
        public IActionResult Delete(int categoysId)
        {
            IAllCategorys.Delete(categoysId);
            return RedirectToAction("List", "Categorys");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var category = IAllCategorys.AllCategorys.FirstOrDefault(c => c.Id == id);
            if (category == null) return NotFound();
            return View(category);
        }

        [HttpPost]
        public IActionResult Edit(Categorys category)
        {
            IAllCategorys.Update(category);
            return RedirectToAction("List", "Categorys");
        }
    }
}