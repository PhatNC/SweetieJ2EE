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
            
            ProductDAO.Instance.InsertProduct(
                tbxName.Text,
                Int32.Parse(tbxidCategory.Text),
                Int32.Parse(tbxPrice.Text),
                tbxDescript.Text,
                Int32.Parse(tbxRemain.Text)
                );
            MessageBox.Show("Add Successful!");
            this.Close();
        }
    }
}
