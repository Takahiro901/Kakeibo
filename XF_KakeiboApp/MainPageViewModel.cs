﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using XF_KakeiboApp.Models;

namespace XF_KakeiboApp
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public MainPageViewModel()
        {
            SelectDelLetter = "選択削除";

            Add = new Command(async () =>
            {
                var item = new Kakeibo
                {
                    Date = this.Date,
                    Himoku = (string)this.SelectedItem,
                    HimokuPicker = this.Index,
                    Memo = this.Text,
                    Price = this.Price,
                };
                await App.Database.SaveItemAsync(item);
                this.Kakeibos = await App.Database.GetItemsAsync();
                this.SelectedItem = null;
                this.Text = "";
                this.Price = 0;

                await SumSet();
            });

            AllDel = new Command(async () =>
            {
                await App.Database.DeleteAllItemsAsync();
                Kakeibos = await App.Database.GetItemsAsync();
                await SumSet();
            });

            EditMode = new Command(() =>
            {
                this.IsEditMode = !this.IsEditMode;                

                if (this.IsEditMode)
                {
                    foreach (var item in Kakeibos)
                    {
                        item.IsEditMode = this.IsEditMode;
                    }
                    SelectDelLetter = "戻る";
                }
                else
                {
                    foreach (var item in Kakeibos)
                    {
                        item.IsEditMode = this.IsEditMode;
                        item.IsChecked = false;
                    }
                    SelectDelLetter = "選択削除";
                }
            });

            Date = DateTime.Now;
        }


        //メソッド
        public async Task SumSet()
        {
            var sum = await App.Database.GetSumAsync();
            SumPrice = sum.ToString();
        }



        //プロパティ
        public Command Add { get;}

        public Command AllDel { get; }

        public Command EditMode { get; }

        public List<string> Kindlist { get { return Kind.list; } }

        private ObservableCollection<Kakeibo> _kakeibos;
        public ObservableCollection<Kakeibo> Kakeibos
        {
            get { return _kakeibos; }
            set
            {
                if (_kakeibos != value)
                {
                    _kakeibos = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Kakeibos)));
                }
            }
        }

        private int index;
        public int Index
        {
            get { return index; }
            set
            {
                if(index != value)
                {
                    index = value;
                    PropertyChanged?.Invoke(this,new PropertyChangedEventArgs(nameof(Index)));
                }
            }
        }

        private object selectedItem;
        public object SelectedItem
        {
            get { return selectedItem; }
            set
            {
                if (selectedItem != value)
                {
                    selectedItem = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedItem)));
                }
            }
        }

        private DateTime date;
        public DateTime Date
        {
            get { return date; }
            set
            {
                if (date != value)
                {
                    date = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Date)));
                }
            }
        }

        private string text;
        public string Text
        {
            get { return text; }
            set
            {
                if (text != value)
                {
                    text = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Text)));
                }
            }
        }

        private int price;
        public int Price
        {
            get { return price; }
            set
            {
                if (price != value)
                {
                    price = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Price)));
                }
            }
        }

        private bool selected;
        public bool Selected
        {
            get { return selected; }
            set
            {
                if (selected != value)
                {
                    selected = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Selected)));
                }
            }
        }

        private string sumPrice;
        public string SumPrice
        {
            get { return sumPrice; }
            set
            {
                if (sumPrice != value)
                {
                    sumPrice = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SumPrice)));
                }
            }
        }

        private bool isEditMode;
        public bool IsEditMode
        {
            get { return isEditMode; }
            set
            {
                if (isEditMode != value)
                {
                    isEditMode = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsEditMode)));
                }
            }
        }

        private string selectDelLetter;
        public string SelectDelLetter
        {
            get { return selectDelLetter; }
            set
            {
                if (selectDelLetter != value)
                {
                    selectDelLetter = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectDelLetter)));
                }
            }
        }
    }
}
