
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MarkIt.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ContactView : ContentPage, INotifyPropertyChanged
	{
        public ContactView()
		{
			InitializeComponent ();                  
        }

        private void SendEmail(object sender, System.EventArgs e)
        {
            DisplayAlert("Obrigado pelo contato!!", "Recebemos sua mensagem, em breve entraremos em contato", "OK");
        }
    }
}