using System.Data.Entity;
using System.Data.Entity.Core.Common;
using System.Data.SQLite;
using System.Data.SQLite.EF6;

public class SQLiteConfiguration : DbConfiguration
{
    /// <summary>
    /// EF6 Устаревший. с .NET 10 не работает без костылей.<br/>
    /// Вопрос. Как он запускался до этого?
    /// </summary>
    public SQLiteConfiguration()
    {
        SetProviderFactory("System.Data.SQLite", SQLiteFactory.Instance);
        SetProviderFactory("System.Data.SQLite.EF6", SQLiteProviderFactory.Instance);
        SetProviderServices("System.Data.SQLite", (DbProviderServices)SQLiteProviderFactory.Instance.GetService(typeof(DbProviderServices)));
    }
}