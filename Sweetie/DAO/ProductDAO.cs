using Sweetie.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sweetie.DAO
{
    public class ProductDAO
    {
        private static ProductDAO instance;

        public static ProductDAO Instance
        {
            get { if (instance == null) instance = new ProductDAO(); return instance; }
            private set { instance = value; }
        }

        private ProductDAO() { }

        public DataTable getProductList()
        {
            List<Product> accountList = new List<Product>();

            string query = "SELECT * FROM dbo.Product";

            DataTable data = DataProvider.Instance.executeQuery(query);

            return data;
        }

        public bool InsertProduct(string name, int idCategory, int price, string descript, int remain)
        {
            string query = string.Format("INSERT dbo.Product (name, idCategory, price, descript, remain) VALUES  ( N'{0}', {1}, {2}, N'{3}', {4})",
                name,
                idCategory,
                price,
                descript,
                remain
                );
            int result = DataProvider.Instance.executeNonQuery(query);

            return result > 0;
        }

        public bool UpdateProduct(int id, string name, int idCategory, int price, string descript, int remain)
        {
            string query = string.Format("UPDATE dbo.Product SET name = N'{1}', idCategory = {2}, price = {3}, descript = N'{4}', remain = {5} WHERE id = {0}", 
                id, 
                name,
                idCategory,
                price,
                descript,
                remain
                );
            int result = DataProvider.Instance.executeNonQuery(query);

            return result > 0;
        }

        public bool DeleteProduct(int id)
        {
            string query = string.Format("DELETE dbo.Product WHERE id = {0}", id);
            int result = DataProvider.Instance.executeNonQuery(query);

            return result > 0;
        }        
    }
}
