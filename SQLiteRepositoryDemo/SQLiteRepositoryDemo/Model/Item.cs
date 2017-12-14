using SQLite;
using SQLiteRepository.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace SQLiteRepositoryDemo.Model
{
    // IDbModel contains ID INT AUTOINCREMENT PK 
    public class Item : IDbModel<Item>
    {
        [Indexed]
        public Guid ExternalId { get; set; }
        public string Description { get; set; }
        public bool Checked { get; set; }

        public override Expression<Func<Item, bool>> Compare(Item other)
        {
            return item => item.ExternalId == other.ExternalId;
        }
    }
}
