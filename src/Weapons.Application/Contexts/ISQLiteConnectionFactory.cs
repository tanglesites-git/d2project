using System.Data;

namespace Weapons.Application.Contexts;

public interface ISQLiteConnectionFactory
{
    public IDbConnection GetConnection();
    public Task<IDbConnection> GetConnectionAsync();
}