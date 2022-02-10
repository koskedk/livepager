using NUnit.Framework;
using Serilog;

namespace LivePager.Shared.Tests
{
    [TestFixture]
    public class CustomTests
    {
        [Test]
        public void should_ensure_string_Ends_With_Value()
        {
            string a = "A";
            Assert.AreEqual("A-", a.HasToEndWith("-"));
        }

        [Test]
        public void should_get_Os_Folder_Format()
        {
            var dir = TestContext.CurrentContext.WorkDirectory.ToOsStyle();
            Assert.False(string.IsNullOrWhiteSpace(dir));
            Log.Debug(dir);
        }
    }
}
