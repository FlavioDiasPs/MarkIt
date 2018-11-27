using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MarkIt.Styles.Dictionaries
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ButtonDic : ResourceDictionary
    {
		public ButtonDic ()
		{
			InitializeComponent ();
		}
	}
}