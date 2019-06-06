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

namespace Sweetie.GUI.Export
{
    /// <summary>
    /// Interaction logic for ExportPage.xaml
    /// </summary>
    public partial class ExportPage : Page
    {
        DataTable data = new DataTable();

        public ExportPage()
        {
            InitializeComponent();
            initDG();
        }

        private void initDG()
        {
            DataColumn column;

            // Create new DataColumn, set DataType, ColumnName and add to DataTable.    
            column = new DataColumn();            
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "productName";
            data.Columns.Add(column);

            // Create second column.
            column = new DataColumn();
            column.DataType = Type.GetType("System.Int32");
            column.ColumnName = "price";
            data.Columns.Add(column);

            // Create third column.
            column = new DataColumn();
            column.DataType = Type.GetType("System.Int32");
            column.ColumnName = "quatity";
            data.Columns.Add(column);

            // Create 4th column.
            column = new DataColumn();
            column.DataType = Type.GetType("System.Int32");
            column.ColumnName = "total";
            data.Columns.Add(column);
        }

        private void AddBillBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void RefreshBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteBillBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddProductBtn_Click(object sender, RoutedEventArgs e)
        {
            AddProductToBill addScreen = new AddProductToBill();
            addScreen.ShowDialog();
            DataRowView product = addScreen.productSelected;
            int quantity = addScreen.quantity;

            DataRow row = data.NewRow();
            row["productName"] = product.Row.ItemArray[2];
            data.Rows.Add(row);

        }

        private void UpdateProductBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteProductBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
