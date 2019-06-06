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

namespace Sweetie.Pages.Login
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Window
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            string user = username.Text;
            string pass = password.Password.ToString();

            if (isLogin(user, pass))
            {
                var newScreen = new MainWindow();
                newScreen.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Wrong Username or Password!");
            }
        }

        bool isLogin(string user, string pass)
        {
            return AccountDAO.Instance.Login(user, pass);
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Do you want to shutdown this application now?", "Warning", MessageBoxButton.OKCancel) != MessageBoxResult.OK)
            {
                return;
            }
            Application.Current.Shutdown();
        }

        private void Password_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                LoginBtn_Click(sender,e);
            }
        }
    }
}
