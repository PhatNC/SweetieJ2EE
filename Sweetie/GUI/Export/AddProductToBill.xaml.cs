using Sweetie.DAO;
using Sweetie.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
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
using Product = Sweetie.Utilities.Product;

namespace Sweetie.GUI.Export
{
    /// <summary>
    /// Interaction logic for AddProductToBill.xaml
    /// </summary>
    public partial class AddProductToBill : Window
    {
        private System.Collections.IEnumerable products;
        public Product productSelected;
        public int quantity;

        public AddProductToBill()
        {
            InitializeComponent();
            loadProduct();
        }
        private void loadProduct()
        {
            products = Database.GetAllProduct();
//            products = ProductDAO.Instance.getProductList().DefaultView;
            cbProduct.ItemsSource = products;
            cbProduct.SelectedIndex = 0;

        }

        private void CbProduct_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            productSelected = cbProduct.SelectedItem as Product;
            updownQuatity.Maximum = productSelected.remaining;
            if (updownQuatity.Value > updownQuatity.Maximum)
            {
                updownQuatity.Value = updownQuatity.Maximum;
            }
//            DataRowView selected = cbProduct.SelectedItem as DataRowView;
//            updownQuatity.Maximum = (int)selected.Row.ItemArray[5];
//            if (updownQuatity.Value > updownQuatity.Maximum)
//            {
//                updownQuatity.Value = updownQuatity.Maximum;
//            }
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
//            DataRowView selected = cbProduct.SelectedItem as DataRowView;
            productSelected = cbProduct.SelectedItem as Product;
            quantity =(int) updownQuatity.Value;
            
            var statusCode = Database.AddToCart(productSelected.id, quantity);
            if (statusCode == HttpStatusCode.OK)
            {
                this.Close();
            }
            else if(statusCode == (HttpStatusCode)422)
            {
                MessageBox.Show("Invalid input");
            }
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
