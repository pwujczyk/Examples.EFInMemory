using Examples.InMemory;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace InMemoryTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        //test contains correct relation between dad and child set up in db
        public void SqlServerIntegrationTest()
        {
            using (var context = new InMemoryDB())
            {
                var service = new Service(context);
                var dad = new Dad() { Name = "Tata" };
                var person = new Child() { Name = "Pawel", Dad = dad };

                context.Add(person);
                context.SaveChanges();
            }

            using (var context = new InMemoryDB())
            {
                Assert.AreEqual("Pawel", context.Person.Last().Name);
            }
        }

        [TestMethod]
        //test doesn't contains correct relation between dad and child set up in db
        public void SqlServerIntegrationTestWithoutRelation()
        {
            using (var context = new InMemoryDB())
            {
                var service = new Service(context);
                var person = new Child() { Name = "Pawel" };

                context.Add(person);
                context.SaveChanges();
            }

            using (var context = new InMemoryDB())
            {
                Assert.AreEqual("Pawel", context.Person.Last().Name);
            }
        }

        [TestMethod]
        //test in memory -  doesn't contains correct relation between dad and child set up in db
        public void WrongSchema()
        {
            var options = new DbContextOptionsBuilder<InMemoryDB>()
              .UseInMemoryDatabase(databaseName: "Add_writes_to_database")
              .Options;

            using (var context = new InMemoryDB(options,false))
            {
                var service = new Service(context);
                var person = new Child() { Name = "Pawel" };

                context.Add(person);
                context.SaveChanges();
            }

            using (var context = new InMemoryDB(options))
            {
                Assert.AreEqual(1, context.Person.Count());
                Assert.AreEqual("Pawel", context.Person.Single().Name);
            }
        }
    }
}
