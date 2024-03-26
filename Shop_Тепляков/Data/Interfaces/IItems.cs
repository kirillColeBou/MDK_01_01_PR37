using Shop_Тепляков.Data.Models;
using System.Collections.Generic;


namespace Shop_Тепляков.Data.Interfaces
{
    public interface IItems
    {
        public IEnumerable<Models.Items> AllItems { get; }
    }
}
