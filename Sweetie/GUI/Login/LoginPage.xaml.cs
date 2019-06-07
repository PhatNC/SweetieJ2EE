using Sweetie.DAO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
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
        private static readonly HttpClient client = new HttpClient();
        private async void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            string user = username.Text;
            string pass = password.Password.ToString();

            bool isLoged = await isLoginAsync(user, pass);
            if (isLoged)
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

        async Task<bool> isLoginAsync(string user, string pass)
        {
            //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //var values = new Dictionary<string, string>
            //{
            //    { "username", user },
            //    { "password", pass }
            //};
            //var content = new FormUrlEncodedContent(values);


            //var response = await client.PostAsync("http://shopping-server-13706.herokuapp.com/users/signin", content);

            //var responseString = await response.Content.ReadAsStringAsync();
            //MessageBox.Show(responseString);
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://shopping-server-13706.herokuapp.com/users/signin");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";
            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream())) {
                string json = "{\"username\":\""+user+"\"," +
                                "\"password\":\""+pass+"\"}";
                //string json = @"{
                //    'username':'admin',
                //    'password':'12345678'
                //}";
                streamWriter.Write(json);
                streamWriter.Flush();
                streamWriter.Close();
            }
            var httpRespond = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpRespond.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                MessageBox.Show(result);
                if (result.Contains("token"))
                {
                    return true;
                }
            }
            return false;
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
