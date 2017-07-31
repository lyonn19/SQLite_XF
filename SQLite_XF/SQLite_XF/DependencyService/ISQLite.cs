using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace SQLite_XF.DependencyService
{
    public interface ISqLite
    {
        SQLiteAsyncConnection GetConnection();
    }
}
