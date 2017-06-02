using Microsoft.VisualStudio.TestTools.UnitTesting;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;

namespace Top.Framework.Core.TestBase
{
    [TestClass]
    public class TestBase
    {
        [TestMethod]
        public void CanGenerateSchema()
        {
            var cfg = new Configuration();
            cfg.Configure();

            new SchemaExport(cfg)
                .SetOutputFile("d:\\TOP_MyDDL.sql").Execute(true, true, false);
        }
    }
}
