using Shop_Тепляков.Data.Models;
using System.Collections.Generic;

namespace Shop_Тепляков.Data.ViewModell
{
    public class VMItems
    {
        public IEnumerable<Models.Items> Items { get; set; }
        public IEnumerable<Models.Categorys> Categorys { get; set; }
        public List<ItemsBasket> ItemsBaskets { get; set; }
        public int SelectCategory = 0;
    }
}
