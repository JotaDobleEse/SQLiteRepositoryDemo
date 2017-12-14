using SQLiteRepository.Helpers;
using SQLiteRepository.Services;
using SQLiteRepositoryDemo.Services.SQLite.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteRepositoryDemo.Services.SQLite
{
    public class DemoContext : SQLiteContext
    {
        #region Repositories
        public ItemRepository Items { get; private set; }
        #endregion

        public override string DbName => "demo.db3";
        public override string BackupFolder => "SQLiteDemo";
        
        public DemoContext(ISQLiteProvider iSQLiteProvider) : base(iSQLiteProvider)
        {
            Items = new ItemRepository(Mutex, SQLiteConnection);
        }

        public override async Task DeleteDatabase()
        {
            await Items.DropTable();
        }
    }
}
