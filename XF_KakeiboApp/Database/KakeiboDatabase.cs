using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using XF_KakeiboApp.Models;
using System.Collections.ObjectModel;
using System.Linq;

namespace XF_KakeiboApp.Database
{
    public class KakeiboDatabase
    {
        readonly SQLiteAsyncConnection database;

        public KakeiboDatabase(string dbpath)
        {
            database = new SQLiteAsyncConnection(dbpath);
            database.CreateTableAsync<Kakeibo>().Wait();
        }

        public Task<List<Kakeibo>> GetItemsAsync()
        {
            return database.Table<Kakeibo>().ToListAsync();
        }

        public async Task<int> GetSumAsync()
        {
            var list = await database.QueryAsync<Kakeibo>("SELECT Price FROM Kakeibo");
            int sum = list.Sum(x => x.Price);
            return sum;
        }

        public Task<int> SaveItemAsync(Kakeibo kakeibo)
        {
            if(kakeibo.Id != 0)
            {
                return database.UpdateAsync(kakeibo);
            }
            else
            {
                return database.InsertAsync(kakeibo);
            }
        }

        public Task<int> DeleteItemAsync(Kakeibo kakeibo)
        {
            return database.DeleteAsync(kakeibo);
        }

        public Task<int> DeleteAllItemsAsync()
        {
            return database.DeleteAllAsync<Kakeibo>();
        }
    }
}
