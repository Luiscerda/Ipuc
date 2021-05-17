namespace Ipuc.ViewModels
{
    using Services;
    using Models;
    using Xamarin.Forms;
    using System.Collections.ObjectModel;
    using System.Reflection;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class BookViewModel : BaseViewModels
    {
        #region Services
        private ApiService apiService;
        #endregion

        #region Attributes
        private Book book;
        private bool isRefreshing;
        private ContentResponse contentResponse;
        private ObservableCollection<Verse> verses;
        private string nameBook;
        #endregion

        #region Properties
        public bool IsRefreshing
        {
            get { return this.isRefreshing; }
            set { SetValue(ref this.isRefreshing, value); }
        }

        public ObservableCollection<Verse> Verses
        {
            get { return this.verses; }
            set { SetValue(ref this.verses, value); }
        }

        public string NameBook
        {
            get { return this.nameBook; }
            set { SetValue(ref this.nameBook, value); }
        }

        #endregion

        #region Constructors
        public BookViewModel(Book book)
        {
            this.apiService = new ApiService();
            this.book = book;
            this.LoadContent();
        }
        #endregion

        #region Methods
        private async void LoadContent()
        {
            var connection = await this.apiService.CheckConnection();
            if (!connection.IsSuccess)
            {
                this.IsRefreshing = false;
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    connection.Message,
                    "Accept");
                return;
            }
            var apiSecurity = Application.Current.Resources["APIBibles"].ToString();
            var response = await this.apiService.Get<ContentResponse>(
                apiSecurity,
                "/api",
                string.Format("?bible={0}&reference={1}",
                MainViewModels.GetInstance().SelectModule,
                this.book.ShortName));

            if (!response.IsSuccess)
            {
                this.IsRefreshing = false;
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    response.Message,
                    "Accept");
                return;
            }

            this.contentResponse = (ContentResponse)response.Result;
            this.IsRefreshing = false;

            var contentResult = contentResponse.Contents[0];

            var type = typeof(Verses);
            var properties = type.GetRuntimeFields();
            Bible bible = null;

            foreach (var property in properties)
            {
                bible = (Bible)property.GetValue(contentResult.Verses);
                if (bible != null)
                {
                    break;
                }
            }

            if (bible == null)
            {
                return;
            }

            type = typeof(Bible);
            properties = type.GetRuntimeFields();
            Dictionary<string, Verse> chapter = null;

            foreach (var property in properties)
            {
                if (property.Name.StartsWith("<Chapter"))
                {
                    chapter = (Dictionary<string, Verse>)property.GetValue(bible);

                    if (chapter != null)
                    {
                        break;
                    }
                }
            }

            var myVerses = chapter.Select(v => new Verse
            {
                Book = v.Value.Book,
                Chapter = v.Value.Chapter,
                Id = v.Value.Id,
                Italics = v.Value.Italics,
                Text = Regex.Replace(v.Value.Text, @"[^\w\ .@-]", ""),
                VerseNumber = v.Value.VerseNumber,
                
            });

            this.Verses = new ObservableCollection<Verse>(myVerses);
            this.NameBook = this.book.Name;
        }
        #endregion
    }
}
