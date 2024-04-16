using Microsoft.AspNetCore.Mvc;
using Shop_Тепляков.Data.DataBase;
using Shop_Тепляков.Data.Interfaces;
using Shop_Тепляков.Data.ViewModell;
using System.Linq;

namespace Shop_Тепляков.Controllers
{
    public class ItemsController : Controller
    {
        private IItems IAllItems;
        private ICategorys IAllCategorys;
        VMItems VMItem = new VMItems();

        public ItemsController(IItems IAllItems, ICategorys IAllCategorys)
        {
            this.IAllItems = IAllItems;
            this.IAllCategorys = IAllCategorys;
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
    }
}