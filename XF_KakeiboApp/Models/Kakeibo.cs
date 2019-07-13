using System;
using SQLite;
namespace XF_KakeiboApp.Models
{
    public class Kakeibo
    {
        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Himoku { get; set; }
        public int HimokuPicker { get; set; }
        public string Memo { get; set; }
        public int Price { get; set; }
    }
}
