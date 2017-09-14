using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SQLite_XF.DependencyService;

namespace SQLite_XF.DAO
{
    public class BaseDatabase
    {
        protected SQLiteAsyncConnection DbConn;
        public BaseDatabase()
        {
            DbConn = Xamarin.Forms.DependencyService.Get<ISqLite>().GetConnection();
        }
    }
}
