using System;
using System.Collections.Generic;
using Xamarin.Forms;
using XF_KakeiboApp.Models;

namespace XF_KakeiboApp
{
    public partial class MainPage : ContentPage
    {
        public static List<string> list = new List<string>
        {
            "食費",
            "生活費"
        };


        public MainPage()
        {
            InitializeComponent();

            kind.ItemsSource = list;
            kind.SelectedIndex = 0;
        }

        protected override async void OnAppearing()
        {
            listview.ItemsSource = await App.Database.GetItemsAsync();
        }

        async void AddClicked(object sender, EventArgs e)
        {
             var item = new Kakeibo 
            { 
                Date = date.Date, 
                Himoku = (string)kind.SelectedItem,
                HimokuPicker = kind.SelectedIndex, 
                Memo = memo.Text, 
                Price = price.Text 
            };
            await App.Database.SaveItemAsync(item);
            listview.ItemsSource = await App.Database.GetItemsAsync();
            kind.SelectedItem = null;
            memo.Text = "";
            price.Text = "";
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
