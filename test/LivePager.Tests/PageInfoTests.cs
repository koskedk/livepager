using System.Linq;
using NUnit.Framework;
using Serilog;

namespace LivePager.Tests
{
    public class PageInfoTests
    {
        [SetUp]
        public void Setup()
        {
        }


        [TestCase(10,5,2)]
        [TestCase(10,4,3)]
        [TestCase(10,3,4)]
        [TestCase(10,2,5)]
        public void should_Generate_Page_Chunks(long total,long size,long result)
        {
            var pgInfo = new PageInfo(total, size);
            pgInfo.GeneratePageChunks();
            Assert.AreEqual(result, pgInfo.PageCount);
            Log.Debug(pgInfo.ToString());
        }

        [TestCase(15,2,8)]
        [TestCase(15,3,5)]
        [TestCase(15,4,4)]
        [TestCase(15,5,3)]
        [TestCase(15,6,3)]
        public void should_Generate_Blocks(long total,long size,long result)
        {
            var pgInfo = new PageInfo(total, size);
            pgInfo.GenerateBlocks();
            Assert.True(pgInfo.Blocks.LongCount()== result);
            Log.Debug(pgInfo.ToString());
            foreach (var block in pgInfo.Blocks)
                Log.Debug(block.Print());
        }
    }
}
