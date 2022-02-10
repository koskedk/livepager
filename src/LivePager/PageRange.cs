using System.Text;

namespace LivePager
{
    public class PageRange
    {
        public long FirstPage { get; }
        public long Page  { get; }
        public long StartPage { get; }
        public long EndPage { get; }
        public long LastPage { get; private set; }

        public long TotalItems => (EndPage - StartPage) + 1;

        public PageRange(long startPage, long endPage, long page)
        {
            FirstPage = 1;
            StartPage = startPage;
            EndPage = endPage;
            Page = page;
        }

        public void UpdateLastPage(long page)
        {
            LastPage = page;
        }
        public  string Print()
        {
            var scb = new StringBuilder();
            scb.AppendLine(PrintBetween());
            scb.AppendLine($"Page {Page} of {LastPage} Items:{TotalItems}");
            for (long i = StartPage; i <= EndPage; i++)
            { scb.AppendLine($"  {i}| Record{i}");
            }

            return scb.ToString();
        }

        public  string PrintBetween()
        {
            return $"BETWEEN {StartPage} AND {EndPage}";
        }

        public override string ToString()
        {
            return $"{FirstPage}|Page {Page} of {LastPage} [{StartPage}]-[{EndPage}] |{LastPage}";
        }
    }
}
