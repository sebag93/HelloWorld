using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld.Persistance
{
    public interface ISqLiteDb
    {
        SQLiteConnection GetConnection();
    }
}
