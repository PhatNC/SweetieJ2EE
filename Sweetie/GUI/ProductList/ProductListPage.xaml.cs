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
using Sweetie.Utilities;
using FastMember;
using System.Net;

namespace Sweetie.Pages.ProductList
{
    /// <summary>
    /// Interaction logic for ProductListPage.xaml
    /// </summary>
    public partial class ProductListPage : Page
    {
        private System.Collections.IEnumerable categories;
        static DataTable categoryTable;
        public ProductListPage()
        {
            InitializeComponent();
            loadCategory();
            loadProductList();
        }

        private void loadCategory()
        {
            var data = Database.GetAllCategories();
            DataTable dataTable = new DataTable();

            using (var reader = ObjectReader.Create(data, "id", "name", "description"))
            {
                dataTable.Load(reader);
            }

            cbCategory.ItemsSource = data;
        }

        void loadProductList()
        {
            var data = Database.GetAllProduct();
            DataTable dataTable = new DataTable();
            
            using (var reader = ObjectReader.Create(data, "id", "name", "description","category","price","remaining","enable" ))
            {
                dataTable.Load(reader);
            }
            //cbCategory.ItemsSource = dataTable.Columns[3].Table;
            //categoryTable = dataTable.DefaultView.ToTable(false, dataTable.Columns[3].ColumnName);

            //cbCategory.ItemsSource = categoryTable.DefaultView;
            dgProduct.ItemsSource = dataTable.DefaultView;
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            NewProductScreen addScreen = new NewProductScreen();
            addScreen.ShowDialog();
            loadCategory();
            loadProductList();
        }

        private void UpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            object item = dgProduct.SelectedItem;
            int id = Int32.Parse((dgProduct.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text);
            string name = (dgProduct.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;
            var comboBox = dgProduct.SelectedCells[2].Column.GetCellContent(item) as ComboBox;
            var category = comboBox.SelectedValue as Sweetie.Utilities.Category;
            string idCategory = category.id;
            float price = float.Parse((dgProduct.SelectedCells[3].Column.GetCellContent(item) as TextBlock).Text);
            string description = (dgProduct.SelectedCells[4].Column.GetCellContent(item) as TextBlock).Text;
            int remaining = Int32.Parse((dgProduct.SelectedCells[5].Column.GetCellContent(item) as TextBlock).Text);
            var status = Database.UpdateProduct(id.ToString(), name, description, int.Parse(idCategory), price, remaining);
            if (status == HttpStatusCode.OK)
            {
                MessageBox.Show("Update Successful!");
                loadCategory();
                loadProductList();
            }
            else if (status == (HttpStatusCode)422)
            {
                MessageBox.Show("Something when wrong");
            }
            
            //ProductDAO.Instance.UpdateProduct(id, name, idCategory, price, descript, remain);
            //MessageBox.Show("Update Succesfully!");
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
