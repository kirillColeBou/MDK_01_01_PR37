using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Shop_Тепляков.Data.DataBase
{
    public class DBCategory : Interfaces.ICategorys
    {
        public IEnumerable<Models.Categorys> AllCategorys
        {
            get
            {
                List<Models.Categorys> categorys = new List<Models.Categorys>();
                MySqlConnection MySqlConnection = Common.Connection.MySqlOpen();
                MySqlDataReader CategorysReader = Common.Connection.MySqlQuery("Select * from pr38.Categorys Order By 'Name';", MySqlConnection);
                while (CategorysReader.Read())
                {
                    categorys.Add(new Models.Categorys()
                    {
                        Id = CategorysReader.IsDBNull(0) ? -1 : CategorysReader.GetInt32(0),
                        Name = CategorysReader.IsDBNull(1) ? null : CategorysReader.GetString(1),
                        Description = CategorysReader.IsDBNull(2) ? null : CategorysReader.GetString(2),
                    });
                }
                return categorys;
            }
        }
    }
}
