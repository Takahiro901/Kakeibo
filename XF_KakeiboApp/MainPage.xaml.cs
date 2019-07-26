using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using XF_KakeiboApp.Models;

namespace XF_KakeiboApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        async void Handle_Appearing(object sender, EventArgs e)
        {
            mainPageViewModel.Kakeibos = await App.Database.GetItemsAsync();
            await mainPageViewModel.SumSet();
        }

        async void listviewTapped(object sender, ItemTappedEventArgs e)
        {
            var wItem = (Kakeibo)e.Item;
            await Navigation.PushAsync(new EditPage(wItem));
        }
    }
}
