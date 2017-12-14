using SQLite;
using SQLiteRepository.Helpers;
using SQLiteRepositoryDemo.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteRepositoryDemo.Services.SQLite.Repository
{
    public class ItemRepository : SQLiteRepository.Services.SqliteRepository<Item>
    {
        public ItemRepository(AsyncLock mutex, SQLiteAsyncConnection sqliteConnection) : base(mutex, sqliteConnection)
        {
        }

        public async Task<List<Item>> GetCheckedItems()
        {
            using (await _mutex.LockAsync().ConfigureAwait(false))
            {
                return await Table.Where(item => item.Checked).ToListAsync();
            }
        }
    }
}
