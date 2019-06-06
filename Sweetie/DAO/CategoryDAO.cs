using Sweetie.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sweetie.DAO
{
    public class CategoryDAO
    {
        private static CategoryDAO instance;

        public static CategoryDAO Instance
        {
            get { if (instance == null) instance = new CategoryDAO(); return instance; }
            private set { instance = value; }
        }

        private CategoryDAO() { }
        
        public DataTable getCategoryList()
        {
            List<Category> accountList = new List<Category>();

            string query = "SELECT * FROM dbo.Category";

            DataTable data = DataProvider.Instance.executeQuery(query);

            return data;
        }

        public bool InsertCategory(string name, string descript)
        {
            string query = string.Format("INSERT dbo.Category (name, descript) VALUES  ( N'{0}', N'{1}')",                
                name,
                descript
                );
            int result = DataProvider.Instance.executeNonQuery(query);

            return result > 0;
        }

        public bool UpdateCategory(int id, string name, string descript)
        {
            string query = string.Format("UPDATE dbo.Category SET name = N'{1}', descript = N'{2}' WHERE id = {0}", id, name, descript);
            int result = DataProvider.Instance.executeNonQuery(query);

            return result > 0;
        }

        public bool DeleteCategory(int id)
        {
            string query = string.Format("DELETE dbo.Category WHERE id = {0}", id);
            int result = DataProvider.Instance.executeNonQuery(query);

            return result > 0;
        }
    }

}
