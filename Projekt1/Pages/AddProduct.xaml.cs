using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using Microsoft.EntityFrameworkCore;
using Projekt.Model;


// ADD PRODUCT //
namespace Projekt.Pages
{
    /// <summary>
    /// Logika interakcji dla klasy AddProduct.xaml
    /// </summary>
    public partial class AddProduct : System.Windows.Controls.Page
    {

        public AddProduct()
        {
            InitializeComponent();
        }

        private void Button_Click_AddProduct(object sender, RoutedEventArgs e)
        {
             
            using MusicContext context = new MusicContext();

            Artists artists = new Artists()
            {
                artist_name = ((TextBox)FindName("Artist")).Text ?? "Unknown"
            };

            context.Artists.Add(artists);
            context.SaveChanges();

            Genres genres = new Genres()
            {
                genre = ((TextBox)FindName("Genre")).Text ?? "Unknown"
            };

            context.Genres.Add(genres);
            context.SaveChanges(); // wywala błąd

            Albums albums = new Albums()
            {
                album_name = ((TextBox)FindName("Album")).Text ?? "Empty",
            };

            context.Albums.Add(albums);
            context.SaveChanges(); 

            Tracks tracks = new Tracks()
            {
                title = ((TextBox)FindName("Title")).Text ?? "Unknown",
                creation_year = int.TryParse(((TextBox)FindName("Year")).Text, out int year) ? year : 0,
                id_album = albums.id_album
            };

            context.Artists.Add(artists);
            context.Genres.Add(genres);
            context.Tracks.Add(tracks);
            context.SaveChanges();
            

        }

        
    }
}
