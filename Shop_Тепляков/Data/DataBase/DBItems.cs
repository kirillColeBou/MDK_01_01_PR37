using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Shop_Тепляков.Data.Common;
using Shop_Тепляков.Data.Models;

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
                MySqlDataReader ItemsReader = Common.Connection.MySqlQuery("Select * from Items Order By 'Name';", MySqlConnection);
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

        public IEnumerable<Items> FindItems(string searchString)
        {
            List<Items> foundItems = new List<Items>();
            MySqlConnection MySqlConnection = Connection.MySqlOpen();
            string query = "SELECT * FROM need.items WHERE Name LIKE @search OR Description LIKE @search;";
            MySqlCommand command = new MySqlCommand(query, MySqlConnection);
            command.Parameters.AddWithValue("@search", "%" + searchString + "%");
            MySqlDataReader ItemsData = command.ExecuteReader();
            while (ItemsData.Read())
            {
                foundItems.Add(new Items()
                {
                    Id = ItemsData.IsDBNull(0) ? -1 : ItemsData.GetInt32(0),
                    Name = ItemsData.IsDBNull(1) ? "" : ItemsData.GetString(1),
                    Description = ItemsData.IsDBNull(2) ? "" : ItemsData.GetString(2),
                    Img = ItemsData.IsDBNull(3) ? "" : ItemsData.GetString(3),
                    Price = ItemsData.IsDBNull(4) ? -1 : ItemsData.GetInt32(4),
                    Category = ItemsData.IsDBNull(5) ? null : Categorys.FirstOrDefault(x => x.Id == ItemsData.GetInt32(5))
                });
            }
            MySqlConnection.Close();
            return foundItems;
        }
    }
}
