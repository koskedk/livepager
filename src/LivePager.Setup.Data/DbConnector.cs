using System.Data;
using System.Linq;
using CSharpFunctionalExtensions;
using Dapper;
using LivePager.Setup.Domain;
using Microsoft.Data.SqlClient;
using Microsoft.Data.Sqlite;
using MySql.Data.MySqlClient;

namespace LivePager.Setup.Data
{
    public class DbConnector:IDbConnector
    {

        public DataSource Connect(DatabaseType databaseType, string connectionString)
        {
            var db = new DataSource(databaseType);

            IDbConnection connection;

            if (databaseType == DatabaseType.SQLite)
            {
                connection = new SqliteConnection(connectionString);
                db.Database = connection.Database;
                db.ConnectionString = connection.ConnectionString;
                return db;
            }

            if (databaseType == DatabaseType.MySQL)
            {
                connection = new MySqlConnection(connectionString);
                db.Database = connection.Database;
                db.ConnectionString = connection.ConnectionString;
                return db;
            }

            if (databaseType == DatabaseType.SQLServer)
            {
                connection = new SqlConnection(connectionString);
                db.Database = connection.Database;
                db.ConnectionString = connection.ConnectionString;
                return db;
            }
            return null;
        }


        public Result Execute(string command,DataSource dataSource)
        {
            IDbConnection connection;

            if (dataSource.DatabaseType == DatabaseType.SQLite)
            {
                connection = new SqliteConnection(dataSource.ConnectionString);
                connection.Execute(command);
                return Result.Success();
            }

            if (dataSource.DatabaseType == DatabaseType.MySQL)
            {
                connection = new MySqlConnection(dataSource.ConnectionString);
                connection.Execute(command);
                return Result.Success();
            }

            if (dataSource.DatabaseType == DatabaseType.SQLServer)
            {
                connection = new SqlConnection(dataSource.ConnectionString);
                connection.Execute(command);
                return Result.Success();
            }

            return Result.Failure("Error");
        }


    }
}
