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

namespace PROG2500_A2_Chinook
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {            
            InitializeComponent();
            mainFrame.NavigationService.Navigate(new Pages.Home_Page());
            
        }

        private void Home_Button_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.NavigationService.Navigate(new Pages.Home_Page());
        }

        private void Albums_Button_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.NavigationService.Navigate(new Pages.Albums_Page());
        }

        private void Artists_Button_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.NavigationService.Navigate(new Pages.Artists_Page());
        }

        private void Tracks_Button_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.NavigationService.Navigate(new Pages.Tracks_Page());
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Catalog_Button_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.NavigationService.Navigate(new Pages.MusicCatalogPage());
        }

        private void Orders_Button_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.NavigationService.Navigate(new Pages.CustomerOrdersPage());
        }
    }
}
