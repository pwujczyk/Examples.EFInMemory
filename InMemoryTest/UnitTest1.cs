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
        public void SqlServerIntegrationTest()
        {
            using (var context = new InMemoryDB())
            {
                var service = new Service(context);
                var dad = new Dad() { Name = "Tata" };
                var person = new Child() { Name = "Pawel2", Dad = dad };

                context.Add(person);
                context.SaveChanges();
            }

            // Use a separate instance of the context to verify correct data was saved to database
            using (var context = new InMemoryDB())
            {
                Assert.AreEqual("Pawel", context.Person.Last().Name);
            }
        }

        [TestMethod]
        public void TestMethod1()
        {
            var options = new DbContextOptionsBuilder<InMemoryDB>()
              .UseInMemoryDatabase(databaseName: "Add_writes_to_database")
              .Options;

            // Run the test against one instance of the context
            using (var context = new InMemoryDB(options,false))
            {
                var service = new Service(context);
                var person = new Child() { Name = "Pawel2" };

                context.Add(person);
                context.SaveChanges();
            }

            // Use a separate instance of the context to verify correct data was saved to database
            using (var context = new InMemoryDB(options))
            {
                Assert.AreEqual(1, context.Person.Count());
                Assert.AreEqual("Pawel", context.Person.Single().Name);
            }
        }



    }
}
