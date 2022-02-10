using LivePager.Setup.Domain;
using NUnit.Framework;
using Serilog;

namespace LivePager.Setup.Data.Tests
{
    [TestFixture]
    public class DbConnectorTest
    {
        private IDbConnector _dbConnector;

        [SetUp]
        public void Setup()
        {
            _dbConnector = new DbConnector();
        }

        [Test]
        public void should_Connect()
        {
            var db = _dbConnector.Connect(DatabaseType.SQLite, TestInitializer.ConnectionString);
            Assert.NotNull(db);
            Log.Debug(db.ConnectionString);
        }

        [Test]
        public void should_Execute()
        {
            var result = _dbConnector.Execute("",null);
            Assert.That(result.IsSuccess);
        }

        [Test]
        public void should_Query()
        {
            // var result = _dbConnector.Query<string>("",null);
            // Assert.That(result.IsSuccess);
            // Assert.That(string.IsNullOrEmpty(result.Value));
        }
    }
}
