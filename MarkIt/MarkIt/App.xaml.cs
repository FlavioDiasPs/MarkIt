using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace MarkIt
{
    public partial class App : Application
    {
        //#region ViewModels
        //public static AlunoViewModel AlunoVM { get; set; }
        //public static UsuarioViewModel UsuarioVM { get; set; }
        //#endregion

        public App()
        {
            InitializeComponent();
            //InitializeApplication();

            MainPage = new NavigationPage(new View.MainPage()); // { BindingContext = App.UsuarioVM }
        }

        //private void InitializeApplication()
        //{
        //    if (AlunoVM == null) AlunoVM = new AlunoViewModel();
        //    if (UsuarioVM == null) UsuarioVM = new UsuarioViewModel();
        //}

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
