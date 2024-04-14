using Microsoft.AspNetCore.Mvc;
using Shop_Тепляков.Data.Interfaces;
using Shop_Тепляков.Data.ViewModell;

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

        public ViewResult List(int id = 0)
        {
            ViewBag.Title = "Страница с предметами";
            VMItem.Items = IAllItems.AllItems;
            VMItem.Categorys = IAllCategorys.AllCategorys;
            VMItem.SelectCategory = id;
            return View(VMItem);
        }
    }
}