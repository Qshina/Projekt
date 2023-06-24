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
using System.Windows.Controls.Primitives;
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
    /// Logika interakcji dla klasy AddGenre.xaml
    /// </summary>
    public partial class AddGenre : Page
    {
        public ObservableCollection<Genres> InitalGenre { get; } = new ObservableCollection<Genres>();

        public AddGenre()
        {
            InitializeComponent();
            RefreshList();
        }
        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            using MusicContext context = new MusicContext();
            var genres = await context.Genres.ToListAsync();
            Genre.ItemsSource = genres;
            await RefreshList();
        }
        private async Task RefreshList()
        {
            using MusicContext context = new MusicContext();
            var genres = await context.Genres.ToListAsync();
            InitalGenre.Clear();
            foreach (var genre in genres)
            {
                InitalGenre.Add(genre);
            }
            Genre.ItemsSource = InitalGenre;
        }

        private void Button_Click_Add(object sender, RoutedEventArgs e)
        {

            using MusicContext context = new MusicContext();

            Genres genres = new Genres()
            {
                genre = ((TextBox)FindName("genre")).Text ?? "Unknown"
            };

            context.Genres.Add(genres);
            context.SaveChanges(); 

            MessageBox.Show("Dodano");
            List<Genres> tracksList = context.Genres.ToList();

            RefreshList().ContinueWith(_ =>
            {
                Application.Current.Dispatcher.Invoke(() =>
                {
                    Genre.ItemsSource = InitalGenre;
                    ((TextBox)FindName("genre")).Clear();
                });
            });

        }
        public void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            using MusicContext context = new MusicContext();
            Genres selectedGenre = Genre.SelectedItem as Genres;
            if (context.Entry(selectedGenre).State == EntityState.Detached)
            {
                context.Attach(selectedGenre);
            }
            context.Genres.Remove(selectedGenre);
            context.SaveChanges();

            MessageBox.Show("Usunięto");

            List<Genres> genresList = context.Genres.ToList();
            RefreshList().ContinueWith(_ =>
            {
                Application.Current.Dispatcher.Invoke(() =>
                {
                    Genre.ItemsSource = InitalGenre;
                });
            });


        }
    }
}
