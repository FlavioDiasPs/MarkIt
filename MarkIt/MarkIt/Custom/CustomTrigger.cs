using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MarkIt.Custom
{
    public class DeselectListViewItemAction : TriggerAction<ListView>
    {
        protected override void Invoke(ListView sender)
        {
            sender.SelectedItem = null;
        }
    }
}
