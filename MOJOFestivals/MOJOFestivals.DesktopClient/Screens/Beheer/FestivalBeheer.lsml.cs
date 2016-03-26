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
    public partial class FestivalBeheer
    {
        /**
          Deze functie pakt de start datum van de geselecteerde festival en stopt het in de datums van huidige podia
         **/
        partial void setDatesFromFestival_Execute()
        {
            DateTime festivalStart = this.Festivals.SelectedItem.Start; // pak de datum
            this.Podia.SelectedItem.Van = festivalStart; // stop hem terug
            this.Podia.SelectedItem.Tot = festivalStart;
        }

        partial void setFestivalData_Execute()
        {
            DateTime festivalStart = this.Festivals.SelectedItem.Start; // pak de datum
            this.ActiviteitOpPodias.SelectedItem.Van = festivalStart;
            this.ActiviteitOpPodias.SelectedItem.Tot = festivalStart;
            this.ActiviteitOpPodias.SelectedItem.Festival = this.Festivals.SelectedItem;

        }


        // TODO remove this data validatie
        partial void FestivalBeheer_Saving(ref bool handled)
        {
            // Write your code here.

           // bool error = false; 



        }

        partial void newActiviteitOpPodium_Execute()
        {
            Application.ShowCreateNewActiviteitOpPodia(Festivals.SelectedItem.Id);

        }
    }
}