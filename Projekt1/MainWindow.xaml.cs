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
using Projekt;

namespace Projekt
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : NavigationWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Button_Click_ArtistPage(object sender, RoutedEventArgs e)
        {
            Navigate(new Uri("./Pages/AddArtist.xaml", UriKind.Relative));
        }
        private void Button_Click_AlbumPage(object sender, RoutedEventArgs e)
        {
            Navigate(new Uri("./Pages/AddAlbum.xaml", UriKind.Relative));
        }
        private void Button_Click_AddTrack(object sender, RoutedEventArgs e)
        {
            Navigate(new Uri("./Pages/AddTrack.xaml", UriKind.Relative));
        }
        private void Button_Click_AddGenre(object sender, RoutedEventArgs e)
        {
            Navigate(new Uri("./Pages/AddGenre.xaml", UriKind.Relative));
        }
    }
}
