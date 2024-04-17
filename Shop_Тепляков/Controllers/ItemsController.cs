using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop_Тепляков.Data.DataBase;
using Shop_Тепляков.Data.Interfaces;
using Shop_Тепляков.Data.Models;
using Shop_Тепляков.Data.ViewModell;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Shop_Тепляков.Controllers
{
    public class ItemsController : Controller
    {
        private readonly IHostingEnvironment hostingEnvironment;
        private IItems IAllItems;
        private ICategorys IAllCategorys;
        VMItems VMItem = new VMItems();

        public ItemsController(IItems IAllItems, ICategorys IAllCategorys, IHostingEnvironment environment)
        {
            this.IAllItems = IAllItems;
            this.IAllCategorys = IAllCategorys;
            this.hostingEnvironment = environment;
        }

        public ViewResult List(int id = 0, string sortBy = "0", string search = "")
        {
            ViewBag.Title = "Страница с предметами";
            var items = IAllItems.AllItems;
            if (id != 0) items = items.Where(i => i.Category.Id == id);
            if (!string.IsNullOrEmpty(search))
            {
                DBItems temp = new DBItems();
                items = temp.FindItems(search);
                ViewBag.Title = "Результаты поиска";
                ViewBag.Items = search;
            }
            if (sortBy == "desc") items = items.OrderByDescending(i => i.Price);
            else if (sortBy == "asc") items = items.OrderBy(i => i.Price);
            VMItem.Items = items;
            VMItem.Categorys = IAllCategorys.AllCategorys;
            VMItem.SelectCategory = id;
            return View(VMItem);
        }

        [HttpGet]
        public ViewResult Add()
        {
            IEnumerable<Data.Models.Categorys> Categorys = IAllCategorys.AllCategorys;
            return View(Categorys);
        }

        [HttpPost]
        public RedirectResult Add(string name, string description, IFormFile files, float price, int idCategory)
        {
            if(files != null)
            {
                var uploads = Path.Combine(hostingEnvironment.WebRootPath, "img");
                var filePath = Path.Combine(uploads, files.FileName);
                files.CopyTo(new FileStream(filePath, FileMode.Create));
            }
            Items newItems = new Items();
            newItems.Name = name;
            newItems.Description = description;
            newItems.Img = files.FileName;
            newItems.Price = Convert.ToInt32(price);
            newItems.Category = new Categorys() { Id = idCategory };
            int id = IAllItems.Add(newItems);
            return Redirect("/Items/Update&id=" + id);
        }

        [HttpPost]
        public IActionResult Delete(int itemId)
        {
            IAllItems.Delete(itemId);
            return RedirectToAction("List", "Items");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            ViewBag.Categories = IAllCategorys.AllCategorys;
            var EditItem = IAllItems.AllItems.FirstOrDefault(i => i.Id == id);
            if (EditItem == null) return NotFound();
            return View(EditItem);
        }

        [HttpPost]
        public RedirectResult Update(int itemId, string name, string description, IFormFile files, float price, int idCategory)
        {
            Items itemToUpdate = new Items();
            itemToUpdate.Id = itemId;
            itemToUpdate.Name = name;
            itemToUpdate.Description = description;
            if (files != null)
            {
                var uploads = Path.Combine(hostingEnvironment.WebRootPath, "img");
                var filePath = Path.Combine(uploads, files.FileName);
                files.CopyTo(new FileStream(filePath, FileMode.Create));
                itemToUpdate.Img = files.FileName;
            }
            itemToUpdate.Price = Convert.ToInt32(price);
            itemToUpdate.Category = new Categorys() { Id = idCategory };
            IAllItems.Update(itemToUpdate);
            return Redirect("/Items/Update&id=" + itemId);
        }
    }
}