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
using FastMember;
using Sweetie.Utilities;

namespace Sweetie.GUI.SaleReport
{
    /// <summary>
    /// Interaction logic for SaleReportPage.xaml
    /// </summary>
    public partial class SaleReportPage : Page
    {
        public SaleReportPage()
        {
            InitializeComponent();
            
            var bills = Database.GetAllBills();

            DataTable dataTable = new DataTable();

            using (var reader = ObjectReader.Create(bills, "id", "userId", "createdDate", "totalPrice"))
            {
                dataTable.Load(reader);
            }

            ReportDetailDataGrid.ItemsSource = dataTable.DefaultView;
        }
    }
}
