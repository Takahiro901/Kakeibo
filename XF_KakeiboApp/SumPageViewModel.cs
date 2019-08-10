using System.Collections.ObjectModel;
using XF_KakeiboApp.Models;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;

namespace XF_KakeiboApp
{
    public class SumPageViewModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        public SumPageViewModel()
        {
            
        }

        public async Task GetSumAsync()
        {
            var data = await App.Database.GetItemsAsync();
            var data2 = data.GroupBy(x => x.Himoku)
                              .Select(x => new GroupSumKakeibo { Himoku = x.Key, Sum = x.Sum(y => y.Price) });
            Items = new ObservableCollection<GroupSumKakeibo>(data2);
        }

        private ObservableCollection<GroupSumKakeibo> items;
        public ObservableCollection<GroupSumKakeibo> Items
        {
            get { return items; }
            set
            {
                if (items != value)
                {
                    items = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Items)));
                }
            }
        }
    }
}
