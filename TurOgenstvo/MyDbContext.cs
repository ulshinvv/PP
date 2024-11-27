using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurOgenstvo.model;

namespace TurOgenstvo
{
    internal class MyDbContext: DbContext
    {
        public string connectionString = @"Data Source=VOVA; Initial Catalog=ttt3t; Integrated Security=true;";

        public DbSet<Тур> Тур {  get; set; }
        public DbSet<Тип_Тура> Тип_Тура { get; set; }
        public DbSet<Тур_Тип_Тура> Тур_Тип_Тура { get; set; }
        public DbSet<Клиент> Клиент { get; set; }
        public DbSet<Договор> Договор { get; set; }
        public DbSet<Отель> Отель { get; set; }
        public DbSet<Тип_Питания> Тип_Питания { get; set; }

    }
}
