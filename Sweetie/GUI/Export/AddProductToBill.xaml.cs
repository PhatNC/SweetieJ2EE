using Sweetie.DAO;
using Sweetie.DTO;
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
using System.Windows.Shapes;

namespace Sweetie.GUI.Export
{
    /// <summary>
    /// Interaction logic for AddProductToBill.xaml
    /// </summary>
    public partial class AddProductToBill : Window
    {
        private System.Collections.IEnumerable products;
        public DataRowView productSelected;
        public int quantity;

        public AddProductToBill()
        {
            InitializeComponent();
            loadProduct();
        }
        private void loadProduct()
        {
            products = ProductDAO.Instance.getProductList().DefaultView;
            cbProduct.ItemsSource = products;
            cbProduct.SelectedIndex = 0;
        }

        private void CbProduct_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataRowView selected = cbProduct.SelectedItem as DataRowView;
            updownQuatity.Maximum = (int)selected.Row.ItemArray[5];
            if (updownQuatity.Value > updownQuatity.Maximum)
            {
                updownQuatity.Value = updownQuatity.Maximum;
            }
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            DataRowView selected = cbProduct.SelectedItem as DataRowView;
            productSelected = selected;
            quantity =(int) updownQuatity.Value;
            this.Close();
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
