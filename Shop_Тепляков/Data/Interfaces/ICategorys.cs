using Shop_Тепляков.Data.Models;
using System.Collections.Generic;

namespace Shop_Тепляков.Data.Interfaces
{
    public interface ICategorys
    {
        IEnumerable<Models.Categorys> AllCategorys { get; }
        public IEnumerable<Categorys> FindCategorys (string search);
        public int Add(Categorys category);
        public void Delete(int id);
        public void Update(Categorys category);
    }
}
