using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Shop_Тепляков.Data.DataBase
{
    public class DBItems : Interfaces.IItems
    {
        public IEnumerable<Models.Categorys> Categorys = new DBCategory().AllCategorys;

        public IEnumerable<Models.Items> AllItems
        {
            get
            {
                List<Models.Items> items = new List<Models.Items>();
                MySqlConnection MySqlConnection = Common.Connection.MySqlOpen();
                MySqlDataReader ItemsReader = Common.Connection.MySqlQuery("Select * from pr38.Items Order By 'Name';", MySqlConnection);
                while (ItemsReader.Read())
                {
                    items.Add(new Models.Items()
                    {
                        Id = ItemsReader.IsDBNull(0) ? -1 : ItemsReader.GetInt32(0),
                        Name = ItemsReader.IsDBNull(1) ? null : ItemsReader.GetString(1),
                        Description = ItemsReader.IsDBNull(2) ? null : ItemsReader.GetString(2),
                        Img = ItemsReader.IsDBNull(3) ? null : ItemsReader.GetString(3),
                        Price = ItemsReader.IsDBNull(4) ? -1 : ItemsReader.GetInt32(4),
                        Category = ItemsReader.IsDBNull(5) ? null : Categorys.First(x => x.Id == ItemsReader.GetInt32(5))
                    });
                }
                MySqlConnection.Close();
                return items;
            }
        }
    }
}
