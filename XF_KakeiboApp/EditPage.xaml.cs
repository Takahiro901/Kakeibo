using System;

using Xamarin.Forms;
using XF_KakeiboApp.Models;

namespace XF_KakeiboApp
{
    public partial class EditPage : ContentPage
    {
        public EditPage(Kakeibo wItem)
        {
            InitializeComponent();

            BindingContext = wItem;
            kind.ItemsSource = MainPage.list;
            kind.SelectedIndex = wItem.HimokuPicker;
        }

        async void SaveClicked(Object sender,EventArgs e)
        {
            Kakeibo eItem = (Kakeibo)BindingContext;
            await App.Database.SaveItemAsync(eItem);
            await Navigation.PopAsync();
        }

        async void DeleteClicked(Object sender, EventArgs e)
        {
            Kakeibo eItem = (Kakeibo)BindingContext;
            await App.Database.DeleteItemAsync(eItem);
            await Navigation.PopAsync();
        }
    }
}
