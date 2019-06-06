using Sweetie.Pages.DashboardPage;
using Sweetie.Pages.Home;
using Sweetie.Pages.ProductList;
using Sweetie.Pages.Shop;
using Sweetie.Pages.Login;
using System;
using System.Collections.Generic;
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
using Sweetie.Pages.Category;
using Sweetie.Pages.AccountInfo;
using Sweetie.Pages.AccountList;
using Sweetie.GUI.Export;
using Sweetie.GUI.SaleReport;

namespace Sweetie
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Frame_Content.Content = new SaleReportPage();
        }

        private void ButtonPopupLogout_Click(object sender, RoutedEventArgs e)
        {
            //Application.Current.Shutdown();
            var newScreen = new LoginPage();
            newScreen.Show();
            this.Close();
        }
        
        private void IAccount_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Frame_Content.Content = new AccountListPage();
        }

        private void Btn_AccountInfo_Click(object sender, RoutedEventArgs e)
        {
            Frame_Content.Content = new AccountInfoPage();
        }

        private void IDashboard_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Frame_Content.Content = new DashboardPage();
        }

        private void IAbout_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Frame_Content.Content = new HomePage();
        }

        private void IProductList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Frame_Content.Content = new ProductListPage();
        }

        private void ICategory_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Frame_Content.Content = new CategoryPage();
        }
        private void IExport_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Frame_Content.Content = new ExportPage();
        }

        private void ISaleReport_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Frame_Content.Content = new SaleReportPage();
        }

        private void ButtonQuit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
