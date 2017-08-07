using System;
using System.IO;
using SQLite;
using SQLite_XF.DependencyService;
using SQLite_XF.iOS;
using Xamarin.Forms;

[assembly: Dependency(typeof(SqliteService))]
namespace SQLite_XF.iOS
{
    public class SqliteService : ISqLite
    {
        public SqliteService()
        {
        }
        #region ISQLite implementation in iOS

        public SQLiteAsyncConnection GetConnection()
        {
            const string sqliteFilename = "myapp.db3";
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal); // Documents folder
            var libraryPath = Path.Combine(documentsPath, "..", "Library"); // Library folder
            //const string libraryPath = "/Users/fermovalcan/Library/Developer/";
            var path = Path.Combine(libraryPath, sqliteFilename);

            // This is where we copy in the prepopulated database
            Console.WriteLine(path);
            if (!File.Exists(path))
            {
                #region For Existing

                File.Copy(sqliteFilename, path);

                #endregion

                #region For New DB

                //File.Create(path);

                #endregion
            }

            //var plat = new SQLitePlatformIOS();
            var conn = new SQLiteAsyncConnection(path);

            // Return the database connection 
            return conn;
        }

        #endregion
    }
}
