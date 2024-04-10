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
    public partial class Tracks_Page : Page
    {
        ChinookContext _context = new ChinookContext();
        CollectionViewSource tracksViewSource = new CollectionViewSource();
        public Tracks_Page()
        {
            InitializeComponent();

            tracksViewSource = (CollectionViewSource)FindResource(nameof(tracksViewSource));

            _context.Tracks.Load();

            tracksViewSource.Source = _context.Tracks.Local.ToObservableCollection();
        }

        private void searchButton_Click(object sender, RoutedEventArgs e)
        {
            var query = _context.Tracks.Where(word => word.Name.Contains(searchBox.Text)).ToList();
            tracksViewSource.Source = query;
        }
    }
}
