using Shop_Тепляков.Data.Interfaces;
using System.Collections;
using System.Collections.Generic;

namespace Shop_Тепляков.Data.Mocks
{
    public class MockCategorys : ICategorys
    {
        public IEnumerable<Models.Categorys> AllCategorys
        {
            get
            {
                return new List<Models.Categorys>
                {
                    new Models.Categorys()
                    {
                        Id = 0,
                        Name = "Варочные панели",
                        Description = "Варочная панель – одна из двух составляющих кухонной плиты, которая разделена для более удобного встраивания."
                    },
                    new Models.Categorys()
                    {
                        Id = 1,
                        Name = "Вытяжки",
                        Description = "вытяжка — устройство для очищения воздуха от дыма, продуктов сгорания, испарений, запахов и прочих нежелательных примесей, образующихся при готовке"
                    },
                    new Models.Categorys()
                    {
                        Id = 2,
                        Name = "Духовые шкафы",
                        Description = "Духовой шкаф – это кухонный прибор, относящийся к крупной бытовой технике. Используется для запекания и выпечки."
                    }
                };
            }
        }
    }
}
