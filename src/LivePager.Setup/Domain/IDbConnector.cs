using System.Collections.Generic;
using CSharpFunctionalExtensions;

namespace LivePager.Setup.Domain
{
    public interface IDbConnector
    {
        DataSource Connect(DatabaseType databaseType, string connectionString);
        Result Execute(string command,DataSource dataSource);
        // Result<T> Query<T>(string query, DataSource dataSource);
    }
}
