using System;
using System.Collections.Generic;
using System.Linq;

namespace LivePager
{
   public class PageInfo
    {
        public long TotalRecords { get; }
        public long PageSize { get; }
        public long PageCount  { get; private set; }
        public List<PageRange> Blocks { get; private set;} = new List<PageRange>();


        private PageInfo()
        {
        }
        public PageInfo(long totalRecords, long pageSize)
        {
            TotalRecords = totalRecords;
            PageSize = pageSize;
        }

        public void GeneratePageChunks()
        {
            PageCount = (long)Math.Round(((double)TotalRecords / PageSize), MidpointRounding.ToPositiveInfinity);
        }

        public void GenerateBlocks()
        {
            GeneratePageChunks();
            List<PageRange> ranges = new List<PageRange>();
            for (long i = 0; i < PageCount; i++)
            {
                long page  = i + 1;
                long start = (PageSize * i) + 1;
                long potentialEnd = start + PageSize - 1;
                long end = potentialEnd > TotalRecords ? TotalRecords : potentialEnd;
                ranges.Add(new PageRange(start, end, page));
            }

            long lastPage = ranges.Max(r => r.Page);
            ranges.ForEach(r => r.UpdateLastPage(lastPage));
            Blocks = ranges;
        }

        public override string ToString()
        {
            return $"Total:{TotalRecords},Pages:{PageCount} each SizeOf:{PageSize}";
        }
    }
}
