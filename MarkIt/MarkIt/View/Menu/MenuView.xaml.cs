using MarkIt.App_Code;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MarkIt.View.Menu
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MenuView : ContentPage
	{
        public ListView ListView { get { return lstMenu; } }
        public MenuView()
        {
            InitializeComponent();

            var menuItems = new ObservableCollection<OpcoesMenu>
            {
                new OpcoesMenu
                {
                    Descricao = "Home",
                    Icone = "Home.png",
                    TargetType = typeof(MainPage)
                },
                new OpcoesMenu
                {
                    Descricao = "About",
                    Icone = "Home.png",
                    TargetType = typeof(AboutView)
                },
                new OpcoesMenu
                {
                    Descricao = "Contact",
                    Icone = "Home.png",
                    TargetType = typeof(ContactView)
                }
            };
            lstMenu.ItemsSource = menuItems;
        }
    }
}