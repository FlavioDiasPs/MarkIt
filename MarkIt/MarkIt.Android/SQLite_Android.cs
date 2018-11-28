using System.IO;
using MarkIt.Droid;
using MarkIt.Data.Interfaces;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLite_Android))]
namespace MarkIt.Droid
{
    public class SQLite_Android : IDependencyServiceSQLite
    {
        public SQLite_Android() { }

        public SQLite.SQLiteConnection GetConection()
        {
            var dbFile = "MarkIt.db";
            var path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);            

            return new SQLite.SQLiteConnection(Path.Combine(path, dbFile));            
        }
    }
}