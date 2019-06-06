using Sweetie.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sweetie.DAO
{
    public class AccountDAO
    {
        private static AccountDAO instance;

        public static AccountDAO Instance
        {
            get { if (instance == null) instance = new AccountDAO(); return instance; }
            private set { instance = value; }
        }

        private AccountDAO() { }

        public bool Login(string username, string password)
        {
            string query = "SELECT * FROM dbo.Account WHERE Username = N'" + username + "' AND Pass = N'" + password + "' AND admin_flg = N'1'" ;

            DataTable result = DataProvider.Instance.executeQuery(query);

            return result.Rows.Count > 0;
        }

        public DataTable getAccountList()
        {
            List<Account> accountList = new List<Account>();

            string query = "SELECT * FROM dbo.Account";

            DataTable data = DataProvider.Instance.executeQuery(query);

            return data;
        }

        public bool InsertAccount(string username, string displayname, string password, string type)
        {
            string query = string.Format("INSERT dbo.Account ( Username, DisplayName, Pass, admin_flg )VALUES  ( N'{0}', N'{1}', N'{2}', N'{3}')", 
                username, 
                displayname, 
                password, 
                type);
            int result = DataProvider.Instance.executeNonQuery(query);

            return result > 0;
        }

        public bool UpdateAccount(string username, string displayname, string password, string type)
        {
            string query = string.Format("UPDATE dbo.Account SET DisplayName = N'{1}', Pass = N'{2}', admin_flg = N'{3}' WHERE Username = N'{0}'", username, displayname, password, type);
            int result = DataProvider.Instance.executeNonQuery(query);

            return result > 0;
        }

        public bool DeleteAccount(string username)
        {
            string query = string.Format("DELETE dbo.Account WHERE Username = N'{0}'", username);
            int result = DataProvider.Instance.executeNonQuery(query);

            return result > 0;
        }
    }
}
