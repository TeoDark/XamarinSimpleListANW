using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;
using XamarinSimpleListANW.Models;
using XamarinSimpleListANW.Data;

namespace XamarinSimpleListANW.Pages
{
    public class ListViewPage : ContentPage
    {
        List<Repository> repositories = new List<Repository>();
        ListView listView = new ListView();
        ActivityIndicator indicator = new ActivityIndicator();

        public ListViewPage()
        {
            SetStateOfIndicator(true);

            PrepareListView();

            Content = new AbsoluteLayout()
            {
                Children =
                {
                    {listView, new Rectangle(0, 0, 1, 1), AbsoluteLayoutFlags.All},
                    {indicator, new Rectangle(0.5, 0.5, 0.1, 0.1), AbsoluteLayoutFlags.All}
                }
            };

            GetRepositoriesListFromGitHub();
        }

        private void PrepareListView()
        {
            listView.ItemsSource = repositories;
            listView.ItemTemplate = new DataTemplate(typeof(TextCell));
            DataTemplate dataTemplate = new DataTemplate(typeof(TextCell));
            dataTemplate.SetBinding(TextCell.TextProperty, new Binding("name"));
            listView.ItemTemplate = dataTemplate;
            listView.ItemTapped += OnListViewCellTap;
        }

        private async void GetRepositoriesListFromGitHub()
        {
            try
            {
                Uri repositoriesSourceUri = Constants.gitHubRepositoryUri;
                string json = await Downloader.DownloadStringFrom(repositoriesSourceUri);
                var response = JsonParser.ParseJson(json, typeof(List<Repository>));
                repositories = response as List<Repository>;
                listView.ItemsSource = repositories; // not implementing INotifyPropertyChanged today
            }
            catch(Exception ex)
            {
                await DisplayAlert("Error",ex.Message,"Ohh");
            }
            SetStateOfIndicator(false);
        }

        private void SetStateOfIndicator(bool state)
        {
            indicator.IsRunning = state;
            indicator.IsVisible = state;
        }

        private void OnListViewCellTap(object sender, ItemTappedEventArgs e)
        {
            listView.SelectedItem = null;
            Navigation.PushAsync(new DetailViewPage(e.Item as Repository));
        }
    }
}
