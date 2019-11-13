using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sanalogi.Models.Data
{
    public class SanalogiDbContext : DbContext
    {
        public SanalogiDbContext(DbContextOptions<SanalogiDbContext> options) : base(options)
        {

        }
        public SanalogiDbContext()
        {

        }

        public static bool isMigration = true;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (isMigration)
            {
                optionsBuilder.UseSqlite("Data Source=Sanalogi.db");
            }
        }
        public DbSet<InvoiceModel> Invoices { get; set; }
    }
}
