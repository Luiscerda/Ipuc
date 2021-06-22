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
        private SQLiteConnection connection;
        public DataAccess()
        {
            var config = DependencyService.Get<IConfig>();
            this.connection = new SQLiteConnection(Path.Combine(config.DirectoryDB, "Ipuc.db3"));
            connection.CreateTable<UserLocal>();
        }
        //public static SQLiteConnection GetConnection()
        //{
        //    if (connection == null)
        //    {
        //        var config = DependencyService.Get<IConfig>();
        //        this.connection = new SQLiteConnection(Path.Combine(config.DirectoryDB, "Ipuc.db3"));
        //        connection.CreateTable<UserLocal>();
        //    }
        //    return connection;
        //}

        public void Insert<T>(T model)
        {
            this.connection.Insert(model);
        }
        public void Update<T>(T model)
        {
            this.connection.Update(model);
        }
        public void Delete<T>(T model)
        {
            this.connection.Delete(model);
        }
        //public UserLocal First()
        //{
        //    return connection.Table<UserLocal>().FirstOrDefault();
        //}
        public List<UserLocal> GetList()
        {
            return this.connection.Table<UserLocal>().ToList();
        }

        public UserLocal Find(int pk)
        {
            return connection.Table<UserLocal>().FirstOrDefault(m => m.UserId == pk);
        }

        public void Dispose()
        {
            connection.Dispose();
        }

    }
}
