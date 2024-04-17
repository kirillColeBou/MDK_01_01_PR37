using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Shop_Тепляков.Data.Common;
using Shop_Тепляков.Data.Models;

namespace Shop_Тепляков.Data.DataBase
{
    public class DBCategory : Interfaces.ICategorys
    {
        public IEnumerable<Categorys> FindCategorys(string searchString)
        {
            List<Categorys> foundCategorys = new List<Categorys>();
            MySqlConnection MySqlConnection = Connection.MySqlOpen();
            string query = "SELECT * FROM need.categorys WHERE Name LIKE @search OR Description LIKE @search;";
            MySqlCommand command = new MySqlCommand(query, MySqlConnection);
            command.Parameters.AddWithValue("@search", "%" + searchString + "%");
            MySqlDataReader CategorysData = command.ExecuteReader();
            while (CategorysData.Read())
            {
                foundCategorys.Add(new Categorys()
                {
                    Id = CategorysData.IsDBNull(0) ? -1 : CategorysData.GetInt32(0),
                    Name = CategorysData.IsDBNull(1) ? null : CategorysData.GetString(1),
                    Description = CategorysData.IsDBNull(2) ? null : CategorysData.GetString(2)
                });
            }
            MySqlConnection.Close();
            return foundCategorys;
        }

        public IEnumerable<Categorys> AllCategorys
        {
            get
            {
                return FindCategorys("");
            }
        }
    }
}
