using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
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
            await SumSet();
        }

        async Task SumSet()
        {
            var sum = await App.Database.GetSumAsync();
            Sum.Text = sum.ToString();
        }

        async void AddClicked(object sender, EventArgs e)
        {
            var item = new Kakeibo
            {
                Date = date.Date,
                Himoku = (string)kind.SelectedItem,
                HimokuPicker = kind.SelectedIndex,
                Memo = memo.Text,
                Price = int.Parse(price.Text), 
            };
            await App.Database.SaveItemAsync(item);
            mainPageViewModel.Kakeibos = await App.Database.GetItemsAsync();
            kind.SelectedItem = null;
            memo.Text = "";
            price.Text = "";

            await SumSet();
        }

        async void listviewTapped(object sender, ItemTappedEventArgs e)
        {
            var wItem = (Kakeibo)e.Item;
            await Navigation.PushAsync(new EditPage(wItem));
        }

        async void AllDel(object sender, EventArgs e)
        {
            await App.Database.DeleteAllItemsAsync();
            listview.ItemsSource = await App.Database.GetItemsAsync();
        }
    }
}
