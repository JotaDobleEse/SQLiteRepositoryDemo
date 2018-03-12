using SQLiteRepositoryDemo.Model;
using SQLiteRepositoryDemo.Services.SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteRepositoryDemo.Helpers
{
    public static class InitializeDb
    {
        public static Task Initialize(DemoContext context)
        {
            return context.Items.InsertRangeAsync(new Item[]
            {
                new Item()
                {
                    ExternalId = Guid.NewGuid(),
                    Description = "Item 1",
                    Checked = false
                },
                new Item()
                {
                    ExternalId = Guid.NewGuid(),
                    Description = "Item 2",
                    Checked = false
                },
                new Item()
                {
                    ExternalId = Guid.NewGuid(),
                    Description = "Item 3",
                    Checked = true
                },
                new Item()
                {
                    ExternalId = Guid.NewGuid(),
                    Description = "Item 4",
                    Checked = true
                },
                new Item()
                {
                    ExternalId = Guid.NewGuid(),
                    Description = "Item 5",
                    Checked = false
                }
            });
        }
    }
}
