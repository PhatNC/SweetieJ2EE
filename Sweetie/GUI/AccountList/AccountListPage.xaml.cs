using Sweetie.DAO;
using Sweetie.DTO;
using Sweetie.GUI.AccountList;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Sweetie.Pages.AccountList
{
    /// <summary>
    /// Interaction logic for AccountListPage.xaml
    /// </summary>
    public partial class AccountListPage : Page
    {
        public AccountListPage()
        {
            InitializeComponent();
            loadAccountList();
        }

        void loadAccountList()
        {
            //    string query = "SELECT UserName, DisplayName, Type FROM dbo.Account";            
            dgAccount.ItemsSource = AccountDAO.Instance.getAccountList().DefaultView;
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            NewAccountScreen addScreen = new NewAccountScreen();
            addScreen.ShowDialog();
        }

        private void UpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            object item = dgAccount.SelectedItem;
            string username = (dgAccount.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
            string displayName = (dgAccount.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;
            string password = (dgAccount.SelectedCells[2].Column.GetCellContent(item) as TextBlock).Text;
            string type = ((dgAccount.SelectedCells[3].Column.GetCellContent(item)) as CheckBox).IsChecked == true ? "1" : "0";

            AccountDAO.Instance.UpdateAccount(username, displayName, password, type);
            MessageBox.Show("Update Succesfully!");
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            object item = dgAccount.SelectedItem;
            string username = (dgAccount.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
            
            AccountDAO.Instance.DeleteAccount(username);
            MessageBox.Show("Delete Succesfully!");
        }

        private void RefreshBtn_Click(object sender, RoutedEventArgs e)
        {
            dgAccount.ItemsSource = null;
            dgAccount.ItemsSource = AccountDAO.Instance.getAccountList().DefaultView;
        }

        private void DgAccount_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //object item = dgAccount.SelectedItem;
            //string username = (dgAccount.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
            //MessageBox.Show(username);
        }
    }
}
