[assembly: Xamarin.Forms.Dependency(typeof(Ipuc.iOS.Implementations.Config))]

namespace Ipuc.iOS.Implementations
{
    using Ipuc.Interfaces;
    //using SQLite;
    using System;

    public class Config : IConfig
    {
        private string directoryDB;
        //private ISQLitePlatform platform;

        public string DirectoryDB
        {
            get
            {
                if (string.IsNullOrEmpty(directoryDB))
                {
                    var directory = Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                    directoryDB = System.IO.Path.Combine(directory, "..", "Library");
                }
                return directoryDB;
            }
        }

        //public ISQLitePlatform Platform
        //{
        //    get
        //    {
        //        if (platform == null)
        //        {
        //            platform = new SQLite.Net.Platform.XamarinIOS.SQLitePlatformIOS();
        //        }
        //        return platform;
        //    }
        //}
    }
}