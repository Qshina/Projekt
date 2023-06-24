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



namespace Projekt.Pages
{
    /// <summary>
    /// Logika interakcji dla klasy AddProduct.xaml
    /// </summary>
    public partial class AddArtist : Page
    {
        public ObservableCollection<Artists> InitalArtist { get; } = new ObservableCollection<Artists>();
        
        public AddArtist()
        {
            InitializeComponent();
            RefreshList();
        }
        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            using MusicContext context = new MusicContext();
            var artist = await context.Artists.ToListAsync();
            Artist.ItemsSource = artist;
            await RefreshList();
        }
        private async Task RefreshList()
        {
            using MusicContext context = new MusicContext();
            var artists = await context.Artists.ToListAsync();
            InitalArtist.Clear();
            foreach (var artist in artists)
            {
                InitalArtist.Add(artist);
            }
        }


        private void Button_Click_AddArtist(object sender, RoutedEventArgs e)
        {
             
            using MusicContext context = new MusicContext();

            Artists artists = new Artists()
            {
                artist_name = ((TextBox)FindName("artist")).Text ?? "Unknown",
                First_Name = ((TextBox)FindName("first_name")).Text ?? "Unknown",
                Last_Name = ((TextBox)FindName("last_name")).Text ?? "Unknown",
                Age = int.TryParse(((TextBox)FindName("age")).Text, out int age) ? age : 0
            };

            context.Artists.Add(artists);
            context.SaveChanges();

            MessageBox.Show("Dodano");
            List<Artists> artistList = context.Artists.ToList();

            RefreshList().ContinueWith(_ =>
            {
                Application.Current.Dispatcher.Invoke(() =>
                {
                    Artist.ItemsSource = InitalArtist; 
                    ((TextBox)FindName("artist")).Clear();
                    ((TextBox)FindName("first_name")).Clear();
                    ((TextBox)FindName("last_name")).Clear();
                    ((TextBox)FindName("age")).Clear();
                });
            });


        }

        public void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            using MusicContext context = new MusicContext();
            Artists selectedArtist = Artist.SelectedItem as Artists;
            if (context.Entry(selectedArtist).State == EntityState.Detached)
            {
                context.Attach(selectedArtist);
            }
            context.Artists.Remove(selectedArtist);
            context.SaveChanges();

            MessageBox.Show("Usunięto");

            List<Artists> artistsList = context.Artists.ToList();
            RefreshList().ContinueWith(_ =>
            {
                Application.Current.Dispatcher.Invoke(() =>
                {
                    Artist.ItemsSource = InitalArtist;
                });
            });


        }


    }
}
