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

        public int Add(Categorys category)
        {
            MySqlConnection MySqlConnection = Connection.MySqlOpen();
            Connection.MySqlQuery($"Insert into `categorys` (`Name`, `Description`) Values ('{category.Name}', '{category.Description}');", MySqlConnection);
            MySqlConnection.Close();
            int IdItem = -1;
            MySqlConnection = Connection.MySqlOpen();
            MySqlDataReader mySqlDataReaderItem = Connection.MySqlQuery($"Select `Id` from `categorys` where `Name` = '{category.Name}' and `Description` = '{category.Description}';", MySqlConnection);
            if (mySqlDataReaderItem.HasRows)
            {
                mySqlDataReaderItem.Read();
                IdItem = mySqlDataReaderItem.GetInt32(0);
            }
            MySqlConnection.Close();
            return IdItem;
        }

        public void Delete(int id)
        {
            MySqlConnection mySqlConnection = Connection.MySqlOpen();
            Connection.MySqlQuery(
                $"DELETE FROM categorys WHERE Id = {id}", mySqlConnection);
            mySqlConnection.Close();
        }

        public void Update(Categorys category)
        {
            MySqlConnection mySqlConnection = Connection.MySqlOpen();
            Connection.MySqlQuery($"UPDATE categorys SET Name = '{category.Name}', Description = '{category.Description}' WHERE Id = {category.Id}", mySqlConnection);
            mySqlConnection.Close();
        }
    }
}
