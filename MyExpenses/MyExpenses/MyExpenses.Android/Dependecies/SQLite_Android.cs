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
using Xamarin.Forms;
using MyExpenses.Droid.Dependecies;
using MyExpenses.Interfaces;
using SQLite;

[assembly: Dependency(typeof(SQLite_Android))]
namespace MyExpenses.Droid.Dependecies
{
    public class SQLite_Android : ISQLite
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SQLite_Android"/> class.
        /// </summary>
        public SQLite_Android() { }

        /// <summary>
        /// Databases the name.
        /// </summary>
        /// <returns>The name.</returns>
        public string DatabaseName()
        {
            return "handyman.db3";
        }

        /// <summary>
        /// Path this instance.
        /// </summary>
        public string DatabasePath()
        {
            string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            return documentsPath;
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
            var conn = new SQLiteConnection(FullDatabasePath());

            // Return the database connection
            return conn;
        }
    }
}