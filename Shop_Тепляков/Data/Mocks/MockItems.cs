using Shop_Тепляков.Data.Interfaces;
using Shop_Тепляков.Data.Models;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Shop_Тепляков.Data.Mocks
{
    public class MockItems : IItems
    {
        public ICategorys _category = new MockCategorys();
        public IEnumerable<Models.Items> AllItems
        {
            get
            {
                return new List<Models.Items>() 
                {
                    new Items()
                    {
                        Id = 0,
                        Name = "Электрическая варочная поверхность DEXP 4M2CTYL/B",
                        Description = "Электрическая варочная поверхность DEXP 4M2CTYL/B отличается от прочих подобных устройств компактными размерами и наличием 2 конфорок для приготовления пищи.",
                        Img = "https://c.dns-shop.ru/thumb/st4/fit/300/300/cb10e446733f6cff0f0dd2dce8c1949d/d489c9311092ae6bbf46d114b5e308b5ccfca6f4901c39c246df62abe4e287c7.jpg.webp",
                        Price = 6999,
                        Category = _category.AllCategorys.First(x => x.Id == 0)
                    },
                    new Items()
                    {
                        Id = 1,
                        Name = "Газовая варочная поверхность Akpo PGA 302 FGC BL",
                        Description = "Газовая варочная поверхность Akpo PGA 302 FGC BL представляет из себя довольно компактную модель бытовой техники для кухни.",
                        Img = "https://c.dns-shop.ru/thumb/st1/fit/300/300/fab02df5b8a4d86392759e0e3b1ba750/5fca4856a5f01b1535c72362ff8c307faee12ec312bf8c1888a7a13c4d5f82cd.jpg.webp",
                        Price = 5199,
                        Category = _category.AllCategorys.First(x => x.Id == 0)
                    },
                    new Items()
                    {
                        Id = 2,
                        Name = "Вытяжка подвесная DEXP MSH340 черный",
                        Description = "Вытяжка подвесная DEXP MSH340 выполнена в металлическом корпусе и имеет уменьшенную ширину 49.7 см, что делает ее идеальным решением для небольших кухонных помещений.",
                        Img = "https://c.dns-shop.ru/thumb/st1/fit/300/300/c39d70ee846c79988de20530207677f6/a343ca4fb2f053b9bb83dd7c687d6682831aba0085bb30166026985dc1987e07.jpg.webp",
                        Price = 3299,
                        Category = _category.AllCategorys.First(x => x.Id == 1)
                    },
                    new Items()
                    {
                        Id = 3,
                        Name = "Электрический духовой шкаф Weissgauff EOM 180 X серебристый",
                        Description = "Электрический духовой шкаф от Weissgauff, выполненный в цвете \"нержавеющая сталь\". Технологичные поворотные переключатели Soft Switch - дают уверенность в надёжности.",
                        Img = "https://c.dns-shop.ru/thumb/st1/fit/300/300/024df4290afb350d3b063fa40aa5b676/54d82a91831a51be77c6fa5e55017aa94ec477dfdbc0647f4f57d470fe76a794.jpg.webp",
                        Price = 16999,
                        Category = _category.AllCategorys.First(x => x.Id == 2)
                    }
                };
            }
        }
    }
}
