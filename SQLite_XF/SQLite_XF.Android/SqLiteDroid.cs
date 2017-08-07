using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;
using SQLite_XF.DependencyService;
using SQLite_XF.Droid;
using Xamarin.Forms;
using Environment = System.Environment;

[assembly: Dependency(typeof(SqliteService))]
namespace SQLite_XF.Droid
{
    public class SqliteService : ISqLite
    {
        public SqliteService()
        {
        }

        #region ISQLite implementation in Android

        public SQLiteAsyncConnection GetConnection()
        {
            const string sqliteFilename = "myapp.db3";
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal); // Documents folder
            //const string documentsPath = "/storage/emulated/legacy/Android/data/com.redactiva.redactivaapp/files";
            var path = Path.Combine(documentsPath, sqliteFilename);
            // This is where we copy in the prepopulated database
            Console.WriteLine(path);
            if (!File.Exists(path))
            {
                #region For Existing DB
                //var s = Forms.Context.Resources.OpenRawResource(Resource.Raw.myapp);  // RESOURCE NAME ###
                //create a write stream
                //var writeStream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write);
                //write to the stream
                //ReadWriteStream(s, writeStream);
                #endregion
                #region For New DB
                //File.Create(path);
                #endregion
            }
            //var plat = new SQLitePlatformAndroid();
            var conn = new SQLiteAsyncConnection(path);
            // Return the database connection 
            return conn;

        }
        #endregion


        /// <summary>
        /// Helper method to get the database out of /raw/ and into the user filesystem
        /// </summary>
        /// <param name="readStream"></param>
        /// <param name="writeStream"></param>
        void ReadWriteStream(Stream readStream, Stream writeStream)
        {
            const int length = 256;
            var buffer = new byte[length];
            var bytesRead = readStream.Read(buffer, 0, length);
            // write the required bytes
            while (bytesRead > 0)
            {
                writeStream.Write(buffer, 0, bytesRead);
                bytesRead = readStream.Read(buffer, 0, length);
            }
            readStream.Close();
            writeStream.Close();
        }
    }
}