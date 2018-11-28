using SQLite;

namespace MarkIt.Data.Interfaces
{
    public interface IDependencyServiceSQLite
    {
        SQLiteConnection GetConection();
    }
}
