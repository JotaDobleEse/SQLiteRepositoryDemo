using SQLite;
using SQLiteRepository.Helpers;
using SQLiteRepositoryDemo.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteRepositoryDemo.Services.SQLite.Repository
{
    public class ItemRepository : SQLiteRepository.Services.SQLiteRepository<Item>
    {
        public ItemRepository(AsyncLock mutex, SQLiteAsyncConnection sqliteConnection) : base(mutex, sqliteConnection)
        {
        }

        public async Task<List<Item>> GetCheckedItems()
        {
            using (await Mutex.LockAsync().ConfigureAwait(false))
            {
                return await Table.Where(item => item.Checked).ToListAsync();
            }
        }
    }
}
