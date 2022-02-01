using NUnit.Framework;
using Serilog;

namespace LivePager.Shared.Tests
{
    [TestFixture]
    public class CustomTests
    {
        [Test]
        public void should_ensure_string_Ends()
        {
            string a = "A";
            Assert.AreEqual("A-", a.HasToEndWith("-"));
        }

        [Test]
        public void should_change_To_OsPath()
        {
            var dir = TestContext.CurrentContext.WorkDirectory.ToOsStyle();
            Assert.False(string.IsNullOrWhiteSpace(dir));
            Log.Debug(dir);
        }
    }
}
