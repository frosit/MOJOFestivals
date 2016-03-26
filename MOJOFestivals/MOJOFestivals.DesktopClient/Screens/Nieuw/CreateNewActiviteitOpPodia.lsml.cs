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
    public partial class CreateNewActiviteitOpPodia
    {
        partial void CreateNewActiviteitOpPodia_InitializeDataWorkspace(global::System.Collections.Generic.List<global::Microsoft.LightSwitch.IDataService> saveChangesTo)
        {

            this.ActiviteitOpPodiaProperty = new ActiviteitOpPodia();
            if (FestivalId > 0)
            {
                Festival fest = (from p in DataWorkspace.ApplicationData.Festivals
                                 where p.Id == FestivalId
                                 select p).First();
                this.ActiviteitOpPodiaProperty.Festival = fest;
                this.ActiviteitOpPodiaProperty.Van = fest.Start;
                this.ActiviteitOpPodiaProperty.Tot = fest.Start;
            } else
            {
                this.ShowMessageBox("We konden niet identificeren bij welk festival het hoort.");
            }

           
        }

        partial void CreateNewActiviteitOpPodia_Saved()
        {
            // Write your code here.
            this.Close(false);
            Application.Current.ShowDefaultScreen(this.ActiviteitOpPodiaProperty);
        }
    }
}