using System.Collections.Generic;

namespace Shop_Тепляков.Data.ViewModell
{
    public class VMItems
    {
        public IEnumerable<Models.Items> Items { get; set; }
        public IEnumerable<Models.Categorys> Categorys { get; set; }
        public int SelectCategory = 0;
    }
}
