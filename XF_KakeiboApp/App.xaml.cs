using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XF_KakeiboApp.Database;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace XF_KakeiboApp
{
    public partial class App : Application
    {
        static KakeiboDatabase database;

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage()) ;
        }

        public static KakeiboDatabase Database
        {
            get
            {
                if(database==null)
                {
                    database = new KakeiboDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "KakeiboSqlite.db3"));
                }
                return database;
            }

        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
