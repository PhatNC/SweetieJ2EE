using Sweetie.DAO;
using Sweetie.GUI.Category;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Sweetie.Utilities;
using System.Data;
using FastMember;

namespace Sweetie.Pages.Category
{
    /// <summary>
    /// Interaction logic for CategoryPage.xaml
    /// </summary>
    public partial class CategoryPage : Page
    {
        public CategoryPage()
        {
            InitializeComponent();
            loadCategoryList();
        }

        void loadCategoryList()
        {
            var data = Database.GetAllCategories();
            //foreach (var item in data)
            //{
            //    Console.WriteLine(item.id);
            //}
            DataTable dataTable = new DataTable();
            using (var reader = ObjectReader.Create(data, "id", "name", "description"))
            {
                dataTable.Load(reader);
            }
            
            dgCategory.ItemsSource = dataTable.DefaultView;
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            NewCategoryScreen addScreen = new NewCategoryScreen();
            addScreen.ShowDialog();
            loadCategoryList();
        }

        private void UpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            object item = dgCategory.SelectedItem;
            int id = Int32.Parse((dgCategory.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text);
            string name= (dgCategory.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;
            string descript= (dgCategory.SelectedCells[2].Column.GetCellContent(item) as TextBlock).Text;
            var status = Database.UpdateCategory( id, name, descript);
            if (status == HttpStatusCode.OK)
            {
                MessageBox.Show("Update Succesfully!");
            }
            else if(status == (HttpStatusCode)422)
            {
                MessageBox.Show("Name cannot be empty!");
            }
            loadCategoryList();
            
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            //object item = dgCategory.SelectedItem;
            //int id = Int32.Parse((dgCategory.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text);

            //CategoryDAO.Instance.DeleteCategory(id);
            //MessageBox.Show("Delete Succesfully!");
        }

        private void RefreshBtn_Click(object sender, RoutedEventArgs e)
        {
            //dgCategory.ItemsSource = null;
            //dgCategory.ItemsSource = CategoryDAO.Instance.getCategoryList().DefaultView;
            loadCategoryList();
        }
    }
}
