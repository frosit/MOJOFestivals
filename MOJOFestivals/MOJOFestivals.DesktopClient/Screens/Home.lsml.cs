using Microsoft.LightSwitch.Presentation.Extensions;
using Microsoft.LightSwitch.Presentation;
using Microsoft.LightSwitch.Framework.Client;
using Microsoft.LightSwitch;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System.IO;
using System.Linq;
using System;

namespace LightSwitchApplication
{
    public partial class Home
    {
        partial void KoopTicket_Execute()
        {
            if (this.Festivals.SelectedItem.Id >= 0)
            {
                Application.ShowCreateNewTicket(this.Festivals.SelectedItem.Id);
            }
            

        }

        partial void SchrijfBeoordeling_Execute()
        {

            if (this.Festivals.SelectedItem.Id >= 0)
            {
                Application.ShowCreateNewBeoordeling(this.Festivals.SelectedItem.Id);
            }

            

        }
    }
}