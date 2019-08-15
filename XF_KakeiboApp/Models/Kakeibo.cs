using System;
using System.ComponentModel;
using SQLite;
namespace XF_KakeiboApp.Models
{
    public class Kakeibo : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Himoku { get; set; }
        public int HimokuPicker { get; set; }
        public string Memo { get; set; }
        public int Price { get; set; }

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
    }
}
