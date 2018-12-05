using MarkIt.ViewModel;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace MarkIt
{
    public partial class App : Application
    {
        public static ProductViewModel ProductVM { get; set; }
        public static ProductDetailsViewModel ProductDetailsVM { get; set; }

        public App()
        {
            InitializeComponent();
            InitializeApplication();
            
            MainPage = new NavigationPage(new View.MainPage());          
        }
    
        private void InitializeApplication()
        {
            if (ProductVM == null) ProductVM = new ProductViewModel();
            if (ProductDetailsVM == null) ProductDetailsVM = new ProductDetailsViewModel();
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
