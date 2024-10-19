using System.Data;
using System.Data.SQLite;
using Weapons.Application.Contexts;

namespace Weapons.Infrastructure;

public class SQLiteConnectionFactory : ISQLiteConnectionFactory
{
    private readonly string _connectionString;

    public SQLiteConnectionFactory(string connectionString)
    {
        _connectionString = connectionString;
    }

    public IDbConnection GetConnection()
    {
        var connection = new SQLiteConnection(_connectionString);
        connection.Open();
        return connection;
    }

    public async Task<IDbConnection> GetConnectionAsync()
    {
        var connection = new SQLiteConnection(_connectionString);
        await connection.OpenAsync();
        return connection;
    }
}