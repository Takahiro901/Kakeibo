using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Xamarin.Forms;
using XF_KakeiboApp.Models;

namespace XF_KakeiboApp
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public MainPageViewModel()
        {
            
        }

        public List<string> Kindlist { get { return Kind.list; } }

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
    }
}
