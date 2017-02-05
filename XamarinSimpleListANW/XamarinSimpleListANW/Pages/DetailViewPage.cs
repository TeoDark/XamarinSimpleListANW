using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;
using XamarinSimpleListANW.Data;

namespace XamarinSimpleListANW.Pages
{

    public class DetailViewPage : ContentPage
    {
        Repository repository;
        Font font = Font.SystemFontOfSize(NamedSize.Medium);
        double fontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label));

        Label name = new Label() { Text = "Repository name:", FontAttributes = FontAttributes.Bold };
        Label authorLogin = new Label() { Text = "Author login :", FontAttributes = FontAttributes.Bold };
        Label html = new Label() { Text = "URL:", FontAttributes = FontAttributes.Bold };
        Label watchers = new Label() { Text = "Watchers:", FontAttributes = FontAttributes.Bold };

        Label nameValue = new Label() { };
        Label authorLoginValue = new Label() { };
        Label htmlValue = new Label() { };
        Label watchersValue = new Label() { };

        public DetailViewPage(Repository repo)
        {
            repository = repo;

            name.FontSize = fontSize;
            nameValue.FontSize = fontSize;
            authorLogin.FontSize = fontSize;
            authorLoginValue.FontSize = fontSize;
            html.FontSize = fontSize;
            htmlValue.FontSize = fontSize;
            watchers.FontSize = fontSize;
            watchersValue.FontSize = fontSize;

            nameValue.Text = repo.name;
            authorLoginValue.Text = repo.owner.login;
            htmlValue.Text = repo.html_url;
            watchersValue.Text = repo.watchers_count.ToString();

            Content = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                Children =
                {
                    new StackLayout {Children = {name,nameValue}, Orientation = StackOrientation.Horizontal },
                    new StackLayout {Children = {authorLogin, authorLoginValue}, Orientation = StackOrientation.Horizontal },
                    new StackLayout {Children = {html, htmlValue}, Orientation = StackOrientation.Horizontal },
                    new StackLayout {Children = {watchers, watchersValue}, Orientation = StackOrientation.Horizontal }
                }
            };
        }
    }
}
