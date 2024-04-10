using Microsoft.EntityFrameworkCore;
using PROG2500_A2_Chinook.Data;
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
    /// Interaction logic for Artists_Page.xaml
    /// </summary>
    public partial class Artists_Page : Page
    {
        ChinookContext _context = new ChinookContext();
        CollectionViewSource artistsViewSource = new CollectionViewSource();
        public Artists_Page()
        {
            InitializeComponent();

            artistsViewSource = (CollectionViewSource)FindResource(nameof(artistsViewSource));

            _context.Artists.Load();

            artistsViewSource.Source = _context.Artists.Local.ToObservableCollection();
        }

        private void searchButton_Click(object sender, RoutedEventArgs e)
        {
            var query = _context.Artists.Where(word => word.Name.Contains(searchBox.Text)).ToList();
            artistsViewSource.Source = query;
        }
    }
}
