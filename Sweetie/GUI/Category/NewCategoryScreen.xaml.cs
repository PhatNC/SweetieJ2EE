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

namespace Sweetie.GUI.Category
{
    /// <summary>
    /// Interaction logic for NewCategoryScreen.xaml
    /// </summary>
    public partial class NewCategoryScreen : Window
    {
        public NewCategoryScreen()
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

            var status = Database.CreateNewCategory(tbxName.Text, tbxDescript.Text);
            if (status == HttpStatusCode.OK)
            {
                MessageBox.Show("Add Successful!");
            }
            else if(status == (HttpStatusCode)422)
            {
                MessageBox.Show("Name cannot be empty");
            }
            
            this.Close();
        }
    }
}
