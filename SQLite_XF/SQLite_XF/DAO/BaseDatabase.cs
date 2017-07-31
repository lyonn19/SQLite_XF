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
        protected SQLiteAsyncConnection _dbConn;
        public BaseDatabase()
        {
            _dbConn = Xamarin.Forms.DependencyService.Get<ISqLite>().GetConnection();
        }
    }
}
