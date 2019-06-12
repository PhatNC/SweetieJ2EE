using Sweetie.DAO;
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
using System.Windows.Shapes;
using Sweetie.Utilities;
using System.Net;
using System.Data;
using FastMember;

namespace Sweetie.GUI.ProductList
{
    /// <summary>
    /// Interaction logic for NewProductScreen.xaml
    /// </summary>
    public partial class NewProductScreen : Window
    {
        public NewProductScreen()
        {
            InitializeComponent();
            loadCategory();
        }
        private void loadCategory()
        {
            var data = Database.GetAllCategories();
            DataTable dataTable = new DataTable();

            using (var reader = ObjectReader.Create(data, "id", "name", "description"))
            {
                dataTable.Load(reader);
            }

            cbbxCategory.ItemsSource = data;
        }
        private bool isCanChecked()
        {
            if (tbxName.Text == null ||
                tbxName.Text == "")
            {
                return false;
            }

            return true;
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (!isCanChecked())
            {
                MessageBox.Show("Please fill the name of product");
                return;
            }
            var category = cbbxCategory.SelectedValue as Sweetie.Utilities.Category;
            int categoryID = int.Parse(category.id);
            var status = Database.CreateNewProduct(tbxName.Text,tbxDescript.Text, categoryID, float.Parse( tbxPrice.Text), int.Parse(tbxRemain.Text));
            if (status == HttpStatusCode.OK)
            {
                MessageBox.Show("Add Successful!");
            }
            else if (status == (HttpStatusCode)422)
            {
                MessageBox.Show("Name cannot be empty");
            }
            this.Close();
        }
    }
}
