using Ipuc.Interfaces;
using Ipuc.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using Xamarin.Forms;

namespace Ipuc.Helpers
{
    //using Interfaces;
    //using Models;

    //using System;
    //using System.Collections.Generic;
    //using System.IO;
    //using System.Linq;
    //using Xamarin.Forms;

    public class DataAccess : IDisposable
    {
        private static SQLiteConnection connection;
        public DataAccess()
        {
            GetConnection();

        }
        public static SQLiteConnection GetConnection()
        {
            if (connection == null)
            {
                var config = DependencyService.Get<IConfig>();
                connection = new SQLiteConnection(Path.Combine(config.DirectoryDB, "Ipuc.db3"));
                connection.CreateTable<UserLocal>();
            }
            return connection;
        }

        public void Insert<T>(T model)
        {
            connection.Insert(model);
        }
        //public void Update<T>(T model)
        //{
        //    connection.Update(model);
        //}
        public void Delete<T>(T model)
        {
            connection.Delete(model);
        }
        //public UserLocal First()
        //{
        //    return connection.Table<UserLocal>().FirstOrDefault();
        //}
        public List<UserLocal> GetList()
        {
            return connection.Table<UserLocal>().ToList();
        }

        //public UserLocal Find(int pk)
        //{
        //    return connection.Table<UserLocal>().FirstOrDefault(m => m.GetHashCode() == pk);
        //}

        public void Dispose()
        {
            connection.Dispose();
        }

    }
}
