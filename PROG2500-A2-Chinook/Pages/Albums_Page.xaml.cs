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
    /// Interaction logic for Albums_Page.xaml
    /// </summary>
    public partial class Albums_Page : Page
    {
        ChinookContext _context = new ChinookContext();
        CollectionViewSource albumsViewSource = new CollectionViewSource();
        public Albums_Page()
        {
            InitializeComponent();

            albumsViewSource = (CollectionViewSource)FindResource(nameof(albumsViewSource));

            _context.Albums.Load();

            albumsViewSource.Source = _context.Albums.Local.ToObservableCollection();
        }

        private void searchButton_Click(object sender, RoutedEventArgs e)
        {
            var query = _context.Albums.Where(word => word.Title.Contains(searchBox.Text)).ToList();
            albumsViewSource.Source = query;
        }
    }
}
