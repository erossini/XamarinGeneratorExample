using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace MyExpenses.Interfaces
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection();
        string DatabaseName();
        string DatabasePath();
        string FullDatabasePath();
    }
}
