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

namespace Sweetie.GUI.AccountList
{
    /// <summary>
    /// Interaction logic for NewAccountScreen.xaml
    /// </summary>
    public partial class NewAccountScreen : Window
    {
        public NewAccountScreen()
        {
            InitializeComponent();
        }

        private bool isCanChecked()
        {
            if (tbxUsername.Text == null ||
                tbxUsername.Text == "" ||
                tbxDisplayName.Text == null ||
                tbxDisplayName.Text == "" ||
                tbxPassword.Password.ToString() == null ||
                tbxPassword.Password.ToString() == "")         
                return false;           
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
                MessageBox.Show("Please fill all fields");
                return;
            }

            if (tbxPassword.Password == tbxReEnter.Password)
            {
                AccountDAO.Instance.InsertAccount(
                    tbxUsername.Text,
                    tbxDisplayName.Text,
                    tbxPassword.Password.ToString(),
                    checkAdmin.IsChecked == true ? "1" : "0");
                MessageBox.Show("Add Successful!");
                this.Close();
            }
            else
            {
                MessageBox.Show("Password and Re-Enter Password do not match. Please try again!");
            }

        }
    }
}
