using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Examples.InMemory
{
    public class InMemoryDB : DbContext
    {
        private const string ConnectionString = @"Server=.\sql2017;Database=InMemoryExample1;Trusted_Connection=True";

        private bool SqlServer;

        public InMemoryDB() { }

        public InMemoryDB(DbContextOptions<InMemoryDB> options) : base(options) { }

        public InMemoryDB(DbContextOptions<InMemoryDB> options, bool sqlServer = true) : base(options)
        {
            this.SqlServer = sqlServer;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (this.SqlServer)
            {
                optionsBuilder.UseSqlServer(ConnectionString);
                base.OnConfiguring(optionsBuilder);
            }
            else
            {
                optionsBuilder.UseSqlServer(@"Server=.\sql2017;Database=EFProviders.InMemory;Trusted_Connection=True;ConnectRetryCount=0");
            }


            
        }

        public DbSet<Child> Person { get; set; }

    }
}
