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
    /// Interaction logic for MusicCatalogPage.xaml
    /// </summary>
    public partial class MusicCatalogPage : Page
    {
        private readonly ChinookContext _context = new ChinookContext();
        private CollectionViewSource catalogViewSource;
        public MusicCatalogPage()
        {
            InitializeComponent();
            catalogViewSource = (CollectionViewSource)FindResource(nameof(catalogViewSource));

            _context.Artists.Load();
            _context.Albums.Load();
            _context.Tracks.Load();

            catalogViewSource.Source = _context.Artists.Local.ToObservableCollection();
        }

        private void searchButton_Click(object sender, RoutedEventArgs e)
        {
            var query =
                from art in _context.Artists
                where art.Name.Contains(searchBox.Text)
                group art by art.Name.ToUpper().Substring(0, 1) into newGroup
                select new
                {
                    Index = newGroup.Key,
                    ArtCount = newGroup.Count().ToString(),
                    art = newGroup.ToList<Artist>()
                };
            catalogListView.ItemsSource = query.ToList();
        }
    }
}
