using Microsoft.EntityFrameworkCore;
using PROG2500_A2_Chinook.Data;
using PROG2500_A2_Chinook.Models;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PROG2500_A2_Chinook.Pages
{
    /// <summary>
    /// Interaction logic for CustomerOrdersPage.xaml
    /// </summary>
    public partial class CustomerOrdersPage : Page
    {
        private readonly ChinookContext _context = new ChinookContext();
        private CollectionViewSource ordersViewSource;
        public CustomerOrdersPage()
        {
            InitializeComponent();
            ordersViewSource = (CollectionViewSource)FindResource(nameof(ordersViewSource));

            _context.Customers.Load();
            _context.Invoices.Load();
            _context.InvoiceLines.Load();

            ordersViewSource.Source = _context.Customers.Local.ToObservableCollection();
        }

        private void searchButton_Click(object sender, RoutedEventArgs e)
        {
            var query =
                from Cust in _context.Customers 
                where Cust.FirstName.Contains(searchBox.Text)
                group Cust by Cust.FirstName into newGroup
                select new
                {
                    Index = newGroup.Key,
                    CustCount = newGroup.Count().ToString(),
                    Cust = newGroup.ToList<Customer>()
                };
                        
            ordersListView.ItemsSource = query.ToList();
        }
    }
}
