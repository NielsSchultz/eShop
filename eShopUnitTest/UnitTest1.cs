using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServiceLayer;
using System.Linq;

namespace eShopUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            // ARRANGE: Create option object with InMemoryDatabase
            var options = new DbContextOptionsBuilder<eShopContext>()
                .UseInMemoryDatabase(databaseName: "Add_writes_to_database")
                .Options;

            // ACT: Run the test against one instance of the context
            using (var context = new eShopContext(options))
            {
                var service = new eShopService(context);
                service.OpretKategori("unittest2");
            }

            // ASSERT: Use a separate instance of the context to verify correct data was saved to database
            using (var context = new eShopContext(options))
            {
                //Assert.AreEqual(1, context.Kategorier.Count());
                Assert.AreEqual("unittest2", context.Kategorier.Single().KategoriNavn);
            }
        }
    }
}
