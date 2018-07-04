using Microsoft.VisualStudio.TestTools.UnitTesting;
using SAIP_MED.DATA.Config;

namespace SAIP_MED.TEST.Test
{
    [TestClass]
    public class DocumentoTestRepository
    {
        AppDbContext Context;

        [TestMethod]
        public void TestMethod1()
        {
            using (Context = new AppDbContext())
            {
                var x = Context.Database.EnsureCreated();
                Assert.IsTrue(x);
            }
        } 
    }
}