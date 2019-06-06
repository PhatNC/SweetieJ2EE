using Sweetie.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sweetie.DAO
{
    public class BillDAO
    {
        private static BillDAO instance;

        public static BillDAO Instance
        {
            get { if (instance == null) { instance = new BillDAO(); } return instance; }
            private set { instance = value; }
        }

        private BillDAO() { }

        public DataTable getBillList()
        {
            List<Bill> accountList = new List<Bill>();

            string query = "SELECT * FROM dbo.Bill";

            DataTable data = DataProvider.Instance.executeQuery(query);

            return data;
        }

        public bool InsertBill(string dateCheckIn, string dateCheckOut, int status, int total)
        {
            string query = string.Format("INSERT dbo.Bill (DateCheckIn, DateCheckOut, status, total) VALUES  ( N'{0}', N'{1}', {2}, {3})",
                dateCheckIn,
                dateCheckOut,
                status,
                total
                );
            int result = DataProvider.Instance.executeNonQuery(query);

            return result > 0;
        }

        public bool UpdateBill(int id, string dateCheckIn, string dateCheckOut, int status, int total)
        {
            string query = string.Format("UPDATE dbo.Bill SET DateCheckIn = N'{1}', DateCheckOut = N'{2}', status = {3}, total = N'{4}' WHERE id = {0}",
                id,
                dateCheckIn,
                dateCheckOut,
                status,
                total
                );
            int result = DataProvider.Instance.executeNonQuery(query);

            return result > 0;
        }

        public bool DeleteBill(int id)
        {
            string query_BillInfo = string.Format("DELETE dbo.BillInfo WHERE idBill = {0}", id);
            string query_Bill = string.Format("DELETE dbo.Bill WHERE id = {0}", id);

            int result_BillInfo = DataProvider.Instance.executeNonQuery(query_BillInfo);
            int result_Bill = DataProvider.Instance.executeNonQuery(query_Bill);

            return (result_BillInfo > 0) && (result_Bill > 0);
        }
    }

}
