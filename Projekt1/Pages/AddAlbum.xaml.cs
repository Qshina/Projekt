using Microsoft.EntityFrameworkCore;
using Projekt.Model;
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

namespace Projekt.Pages
{
    /// <summary>
    /// Logika interakcji dla klasy AddAlbum.xaml
    /// </summary>
    public partial class AddAlbum : Page
    {
        public ObservableCollection<Albums> InitalAlbum { get; } = new ObservableCollection<Albums>();
        public ObservableCollection<Artists> InitalArtist { get; } = new ObservableCollection<Artists>();

        public AddAlbum()
        {
            InitializeComponent();
            using MusicContext context = new MusicContext();
            var artists = context.Artists.ToList();
            foreach (var artist in artists)
            {
                InitalArtist.Add(artist);
            }
            artist_name.ItemsSource = InitalArtist;

            RefreshList();

        }
        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            using MusicContext context = new MusicContext();
            var albums = await context.Albums.ToListAsync();
            Album.ItemsSource = albums;
            await RefreshList();
        }
        private async Task RefreshList()
        {
            using MusicContext context = new MusicContext();
            var albums = await context.Albums.ToListAsync();
            InitalAlbum.Clear();
            foreach (var album in albums)
            {
                InitalAlbum.Add(album);
            }
            Album.ItemsSource = InitalAlbum;
        }

        private void Button_Click_Add(object sender, RoutedEventArgs e)
        {
            using MusicContext context = new MusicContext();

            Albums albums = new Albums()
            {
                album_name = ((TextBox)FindName("album")).Text ?? "Unknown",
                release_date = ((DatePicker)FindName("release_date")).SelectedDate ?? DateTime.MinValue,
                //artist_NAME = int.TryParse(((ComboBox)FindName("artist_name")).Text, out int artistid) ? artistid : 0
                artist_NAME = ((ComboBox)FindName("artist_name")).Text ?? "Unknown"
            };

            context.Albums.Add(albums);
            context.SaveChanges();

            MessageBox.Show("Dodano");
            List<Albums> albumsList = context.Albums.ToList();

            RefreshList().ContinueWith(_ =>
            {
                Application.Current.Dispatcher.Invoke(() =>
                {
                    Album.ItemsSource = InitalAlbum;
                    ((TextBox)FindName("album")).Clear();
                    ((DatePicker)FindName("release_date")).SelectedDate = null;
                    ((ComboBox)FindName("artist_name")).SelectedItem = null;
                });
            });
        }


        public void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            using MusicContext context = new MusicContext();
            Albums selectedAlbum = Album.SelectedItem as Albums;
            if (context.Entry(selectedAlbum).State == EntityState.Detached)
            {
                context.Attach(selectedAlbum);
            }
            context.Albums.Remove(selectedAlbum);
            context.SaveChanges();

            MessageBox.Show("Usunięto");

            List<Albums> albumsList = context.Albums.ToList();
            RefreshList().ContinueWith(_ =>
            {
                Application.Current.Dispatcher.Invoke(() =>
                {
                    Album.ItemsSource = InitalAlbum;
                });
            });


        }


    }
}
