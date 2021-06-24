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
        public static string MyProfile
        {
            get { return Resource.MyProfile; }
        }
        public static string LogOut
        {
            get { return Resource.LogOut; }
        }
        public static string RegisterMembers
        {
            get { return Resource.RegisterMembers; }
        }
        public static string Login
        {
            get { return Resource.Login; }
        }
        public static string Register
        {
            get { return Resource.Register; }
        }

        public static string RegisterTitle
        {
            get { return Resource.RegisterTitle; }
        }

        public static string ChangeImage
        {
            get { return Resource.ChangeImage; }
        }

        public static string FirstNameLabel
        {
            get { return Resource.FirstNameLabel; }
        }

        public static string FirstNamePlaceHolder
        {
            get { return Resource.FirstNamePlaceHolder; }
        }

        public static string FirstNameValidation
        {
            get { return Resource.FirstNameValidation; }
        }

        public static string LastNameLabel
        {
            get { return Resource.LastNameLabel; }
        }

        public static string LastNamePlaceHolder
        {
            get { return Resource.LastNamePlaceHolder; }
        }

        public static string LastNameValidation
        {
            get { return Resource.LastNameValidation; }
        }

        public static string PhoneLabel
        {
            get { return Resource.PhoneLabel; }
        }

        public static string PhonePlaceHolder
        {
            get { return Resource.PhonePlaceHolder; }
        }

        public static string PhoneValidation
        {
            get { return Resource.PhoneValidation; }
        }

        public static string ConfirmLabel
        {
            get { return Resource.ConfirmLabel; }
        }

        public static string ConfirmPlaceHolder
        {
            get { return Resource.ConfirmPlaceHolder; }
        }

        public static string ConfirmValidation
        {
            get { return Resource.ConfirmValidation; }
        }

        public static string EmailValidation2
        {
            get { return Resource.EmailValidation2; }
        }

        public static string PasswordValidation2
        {
            get { return Resource.PasswordValidation2; }
        }

        public static string ConfirmValidation2
        {
            get { return Resource.ConfirmValidation2; }
        }

        public static string UserRegisteredMessage
        {
            get { return Resource.UserRegisteredMessage; }
        }

        public static string SourceImageQuestion
        {
            get { return Resource.SourceImageQuestion; }
        }

        public static string Cancel
        {
            get { return Resource.Cancel; }
        }

        public static string FromGallery
        {
            get { return Resource.FromGallery; }
        }

        public static string FromCamera
        {
            get { return Resource.FromCamera; }
        }
        public static string EMail
        {
            get { return Resource.EMail; }
        }
        public static string Password
        {
            get { return Resource.Password; }
        }
        public static string PasswordPlaceHolder
        {
            get { return Resource.PasswordPlaceHolder; }
        }
        public static string Save
        {
            get { return Resource.Save; }
        }

        public static string ChangePassword
        {
            get { return Resource.ChangePassword; }
        }

        public static string CurrentPassword
        {
            get { return Resource.CurrentPassword; }
        }

        public static string CurrentPasswordPlaceHolder
        {
            get { return Resource.CurrentPasswordPlaceHolder; }
        }

        public static string NewPassword
        {
            get { return Resource.NewPassword; }
        }

        public static string NewPasswordPlaceHolder
        {
            get { return Resource.NewPasswordPlaceHolder; }
        }

        public static string ConnectionError1
        {
            get { return Resource.ConnectionError1; }
        }

        public static string ConnectionError2
        {
            get { return Resource.ConnectionError2; }
        }

        public static string LoginError
        {
            get { return Resource.LoginError; }
        }

        public static string ChagePasswordConfirm
        {
            get { return Resource.ChagePasswordConfirm; }
        }

        public static string PasswordError
        {
            get { return Resource.PasswordError; }
        }

        public static string ErrorChangingPassword
        {
            get { return Resource.ErrorChangingPassword; }
        }
        public static string TitleMembers
        {
            get { return Resource.TitleMembers; }
        }

        public static string IdentificationMembers
        {
            get { return Resource.IdentificationMembers; }
        }
        public static string IdentificacionMembersPlaceHolder
        {
            get { return Resource.IdentificacionMembersPlaceHolder; }
        }

        public static string NameMembers
        {
            get { return Resource.NameMembers; }
        }
        public static string NameMembersPlaceholder
        {
            get { return Resource.NameMembersPlaceholder; }
        }

        public static string LastNameMembers
        {
            get { return Resource.LastNameMembers; }
        }
        public static string LastNameMembersPlaceHolder
        {
            get { return Resource.LastNameMembersPlaceHolder; }
        }

        public static string DirectionLabel
        {
            get { return Resource.DirectionLabel; }
        }
        public static string DirectionPlaceHolder
        {
            get { return Resource.DirectionPlaceHolder; }
        }

        public static string BaptizedLabel
        {
            get { return Resource.BaptizedLabel; }
        }
        public static string IdentificacionValidation
        {
            get { return Resource.IdentificacionValidation; }
        }
        public static string MembersRegisterMessage
        {
            get { return Resource.MembersRegisterMessage; }
        }
        public static string AddressValidation
        {
            get { return Resource.AddressValidation; }
        }
        public static string ListMembers
        {
            get { return Resource.ListMembers; }
        }
        public static string InformationMember
        {
            get { return Resource.InformationMember; }
        }
        public static string Update
        {
            get { return Resource.Update; }
        }
    }
}
