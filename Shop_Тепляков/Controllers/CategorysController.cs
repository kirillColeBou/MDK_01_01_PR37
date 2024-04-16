using Microsoft.AspNetCore.Mvc;
using Shop_Тепляков.Data.Interfaces;

namespace Shop_Тепляков.Controllers
{
    public class CategorysController : Controller
    {
        private ICategorys IAllCategorys;

        public CategorysController(ICategorys IAllCategorys) => this.IAllCategorys = IAllCategorys;

        public ViewResult List(string search)
        {
            ViewBag.Title = "Страница с категориями";
            var cars = IAllCategorys.FindCategorys(search);
            return View(cars);
        }
    }
}