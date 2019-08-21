using System;
using System.Collections.Generic;
using System.Text;

namespace Examples.InMemory
{
    public static class Commands
    {
        public static void Setup()
        {

            using (var db = new InMemoryDB())
            {
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();

                var dad = new Dad() { Name = "Tata" };

                var person = new Child() { Name = "Pawel", Dad = dad };
                db.Add(person);
                db.SaveChanges();
            }
        }
    }
}
