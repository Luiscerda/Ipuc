using Ipuc.Interfaces;
using Xamarin.Forms;

[assembly: Dependency(typeof(Ipuc.Droid.Implementations.Config))]
namespace Ipuc.Droid.Implementations
{
   
    public class Config : IConfig
    {
        private string directoryDB;

        public string DirectoryDB
        {
            get
            {
                if (string.IsNullOrEmpty(directoryDB))
                {
                    var directorio = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                    directoryDB = directorio;
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
        //            platform = new SQLite.Net.Platform.XamarinAndroid.SQLitePlatformAndroid();
        //        }
        //        return platform;
        //    }
        //}
    }
}