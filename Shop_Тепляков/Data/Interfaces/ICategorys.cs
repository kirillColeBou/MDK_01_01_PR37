using System.Collections.Generic;

namespace Shop_Тепляков.Data.Interfaces
{
    public interface ICategorys
    {
        IEnumerable<Models.Categorys> AllCategorys { get; }
    }
}
