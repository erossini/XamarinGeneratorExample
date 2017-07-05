using MyExpenses.iOS.Dependencies;
using MyExpenses.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;
using System.Text;
using SQLite;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLite_iOS))]
namespace MyExpenses.iOS.Dependencies
{
    public class SQLite_iOS : ISQLite
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SQLite_iOS"/> class.
        /// </summary>
        public SQLite_iOS() { }

        /// <summary>
        /// Databases the name.
        /// </summary>
        /// <returns>The name.</returns>
        public string DatabaseName()
        {
            return "MyExpenses.db3";
        }

        /// <summary>
        /// Path this instance.
        /// </summary>
        public string DatabasePath()
        {
            return Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        }

        /// <summary>
        /// Databases the path.
        /// </summary>
        /// <returns>The path.</returns>
        public string FullDatabasePath()
        {
            // Documents folder
            var path = Path.Combine(DatabasePath(), DatabaseName());
            return path;
        }

        /// <summary>
        /// Gets the connection.
        /// </summary>
        /// <returns></returns>
        public SQLiteConnection GetConnection()
        {
            // Create the connection
            var conn = new SQLiteConnection(FullDatabasePath(),
                                            SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create | SQLiteOpenFlags.FullMutex,
                                            true);

            // Return the database connection
            return conn;
        }
    }
}