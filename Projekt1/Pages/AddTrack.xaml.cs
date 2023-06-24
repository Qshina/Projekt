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
    /// Logika interakcji dla klasy AddTrack.xaml
    /// </summary>
    public partial class AddTrack : Page
    {
        public ObservableCollection<Albums> InitalAlbum { get; } = new ObservableCollection<Albums>();
        public ObservableCollection<Genres> InitalGenre { get; } = new ObservableCollection<Genres>();
        public ObservableCollection<Tracks> InitalTrack { get; } = new ObservableCollection<Tracks>();

        public AddTrack()
        {
            InitializeComponent();
            using MusicContext context = new MusicContext();
            var albums = context.Albums.ToList();
            foreach (var album in albums)
            {
                InitalAlbum.Add(album);
            }
            album_name.ItemsSource = InitalAlbum;

            var genres = context.Genres.ToList();
            foreach (var genre in genres)
            {
                InitalGenre.Add(genre);
            }
            genre_name.ItemsSource = InitalGenre;

            RefreshList();

        }
        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            using MusicContext context = new MusicContext();
            var tracks = await context.Tracks.ToListAsync();
            Track.ItemsSource = tracks;
            await RefreshList();
        }
        private async Task RefreshList()
        {
            using MusicContext context = new MusicContext();
            var tracks = await context.Tracks.ToListAsync();
            InitalTrack.Clear();
            foreach (var track in tracks)
            {
                InitalTrack.Add(track);
            }
            Track.ItemsSource = InitalTrack;
        }

        private void Button_Click_Add(object sender, RoutedEventArgs e)
        {
            using MusicContext context = new MusicContext();

            Tracks tracks = new Tracks()
            {
                title = ((TextBox)FindName("title")).Text ?? "Unknown",
                creation_year = ((DatePicker)FindName("creation_year")).SelectedDate ?? DateTime.MinValue,
                //album_NAME = int.TryParse(((ComboBox)FindName("album_name")).Text, out int albumid) ? albumid : 0,
                //genre_NAME = int.TryParse(((ComboBox)FindName("genre_name")).Text, out int genreid) ? genreid : 0
                genre_NAME = ((ComboBox)FindName("genre_name")).Text ?? "Unknown",
                album_NAME = ((ComboBox)FindName("album_name")).Text ?? "Unknown"
            };

            context.Tracks.Add(tracks);
            context.SaveChanges();

            MessageBox.Show("Dodano");
            List<Tracks> tracksList = context.Tracks.ToList();

            RefreshList().ContinueWith(_ =>
            {
                Application.Current.Dispatcher.Invoke(() =>
                {
                    Track.ItemsSource = InitalTrack;
                    ((TextBox)FindName("title")).Clear();
                    ((DatePicker)FindName("creation_year")).SelectedDate = null;
                    ((ComboBox)FindName("album_name")).SelectedIndex = 0;
                    //((ComboBox)FindName("genre_name")).SelectedIndex = 0;
                    ((ComboBox)FindName("genre_name")).SelectedItem = null;
                });
            });
        }


        public void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            using MusicContext context = new MusicContext();
            Tracks selectedTrack = Track.SelectedItem as Tracks;
            if (context.Entry(selectedTrack).State == EntityState.Detached)
            {
                context.Attach(selectedTrack);
            }
            context.Tracks.Remove(selectedTrack);
            context.SaveChanges();

            MessageBox.Show("Usunięto");

            List<Tracks> tracksList = context.Tracks.ToList();
            RefreshList().ContinueWith(_ =>
            {
                Application.Current.Dispatcher.Invoke(() =>
                {
                    Track.ItemsSource = InitalTrack;
                });
            });


        }
    }
}