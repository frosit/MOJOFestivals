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
    public partial class CreateNewTicket
    {
        partial void CreateNewTicket_InitializeDataWorkspace(global::System.Collections.Generic.List<global::Microsoft.LightSwitch.IDataService> saveChangesTo)
        {
            // Write your code here.
            this.TicketProperty = new Ticket();

            if (FestivalId > 0)
            {
                Festival fest = (from p in DataWorkspace.ApplicationData.Festivals
                                 where p.Id == FestivalId
                                 select p).First();
                this.TicketProperty.Festival = fest;
            }
            else
            {
                this.ShowMessageBox("We konden niet identificeren bij welk festival het hoort.");
            }

        }

        partial void CreateNewTicket_Saved()
        {
            // Write your code here.
            this.Close(false);
            Application.Current.ShowDefaultScreen(this.TicketProperty);
        }
    }
}