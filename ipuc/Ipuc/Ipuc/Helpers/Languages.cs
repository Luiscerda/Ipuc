namespace Ipuc.Helpers
{
    using Ipuc.Interfaces;
    using Xamarin.Forms;
    using Resource;
    public class Languages
    {
        static Languages()
        {
            var ci = DependencyService.Get<ILocalize>().GetCurrentCultureInfo();
            Resource.Culture = ci;
        }

        public static string Accept
        {
            get { return Resource.Accept; }
        }
        public static string EmailValidator
        {
            get { return Resource.EmailValidator; }
        }
        public static string Error
        {
            get { return Resource.Error; }
        }
        public static string EmailPlaceHolder
        {
            get { return Resource.EmailPlaceHolder; }
        }
        public static string Rememberme
        {
            get { return Resource.Rememberme; }
        }

    }
}
