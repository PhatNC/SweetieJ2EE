using Sweetie.DAO;
using Sweetie.GUI.ProductList;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace Sweetie.Pages.ProductList
{
    /// <summary>
    /// Interaction logic for ProductListPage.xaml
    /// </summary>
    public partial class ProductListPage : Page
    {
        private System.Collections.IEnumerable categories;

        public ProductListPage()
        {
            InitializeComponent();
            loadCategory();
            loadProductList();
        }

        private void loadCategory()
        {
            categories = CategoryDAO.Instance.getCategoryList().DefaultView;
            cbCategory.ItemsSource = categories;
        }

        void loadProductList()
        {        
            dgProduct.ItemsSource = ProductDAO.Instance.getProductList().DefaultView;
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            NewProductScreen addScreen = new NewProductScreen();
            addScreen.ShowDialog();
        }

        private void UpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            object item = dgProduct.SelectedItem;
            int id = Int32.Parse((dgProduct.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text);
            string name = (dgProduct.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;
            int idCategory = Int32.Parse((dgProduct.SelectedCells[2].Column.GetCellContent(item) as ComboBox).SelectedValue.ToString());
            int price = Int32.Parse((dgProduct.SelectedCells[3].Column.GetCellContent(item) as TextBlock).Text);
            string descript = (dgProduct.SelectedCells[4].Column.GetCellContent(item) as TextBlock).Text;
            int remain = Int32.Parse((dgProduct.SelectedCells[5].Column.GetCellContent(item) as TextBlock).Text);

            ProductDAO.Instance.UpdateProduct(id, name, idCategory, price, descript, remain);
            MessageBox.Show("Update Succesfully!");
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            object item = dgProduct.SelectedItem;
            int id = Int32.Parse((dgProduct.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text);

            ProductDAO.Instance.DeleteProduct(id);
            MessageBox.Show("Delete Succesfully!");
        }

        private void RefreshBtn_Click(object sender, RoutedEventArgs e)
        {
            dgProduct.ItemsSource = null;
            dgProduct.ItemsSource = ProductDAO.Instance.getProductList().DefaultView;
        }
    }
}
