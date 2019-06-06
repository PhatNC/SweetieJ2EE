using Sweetie.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sweetie.DAO
{
    public class BillInfoDAO
    {
        private static BillInfoDAO instance;

        public static BillInfoDAO Instance
        {
            get { if (instance == null) { instance = new BillInfoDAO(); } return instance; }
            private set { instance = value; }
        }

        private BillInfoDAO() { }

        public DataTable getBillInfoList()
        {
            List<BillInfo> accountList = new List<BillInfo>();

            string query = "SELECT * FROM dbo.BillInfo";

            DataTable data = DataProvider.Instance.executeQuery(query);

            return data;
        }

        public bool InsertBillInfo(int idBill, int idProduct, int quantity)
        {
            string query = string.Format("INSERT dbo.BillInfo (idBill, idProduct, quantity) VALUES  ({0}, {1}, {2})",
                idBill,
                idProduct,
                quantity
                );
            int result = DataProvider.Instance.executeNonQuery(query);

            return result > 0;
        }

        public bool UpdateBillInfo(int id, int idBill, int idProduct, int quantity)
        {
            string query = string.Format("UPDATE dbo.BillInfo SET idBill = {1}, idProduct = {2}, quantity = {3} WHERE id = {0}",
                id,
                idBill,
                idProduct,
                quantity
                );
            int result = DataProvider.Instance.executeNonQuery(query);

            return result > 0;
        }

        public bool DeleteBillInfo(int id)
        {
            string query = string.Format("DELETE dbo.BillInfo WHERE id = {0}", id);
            int result = DataProvider.Instance.executeNonQuery(query);

            return result > 0;
        }
    }
}
