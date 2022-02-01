using System.Collections.Generic;

namespace LivePager.Setup.Domain
{
    public class DataSource
    {
        public DatabaseType DatabaseType { get; }
        public string Server { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public string Database { get; set; }
        public string ConnectionString { get; set; }
        public List<DataStore> Stores { get; set; } = new List<DataStore>();

        public DataSource(DatabaseType databaseType)
        {
            DatabaseType = databaseType;
        }
    }
}
