using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Examples.InMemory
{
    public class Service
    {
        private readonly InMemoryDB memory;

        public Service(InMemoryDB db)
        {
            this.memory = db;
        }
         
       // public void Add(string name)
       // {
       //     var person = new Child() { Name = name };
       //     memory.Add(person);
       //     memory.SaveChanges();
       //}

        public List<Child> Get()
        {
            var r=memory.Person.ToList();
            return r;
        }
    }
}
