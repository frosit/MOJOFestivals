using Microsoft.LightSwitch;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using System;

namespace LightSwitchApplication
{
    public partial class Ticket
    {
        partial void TotaalBedrag_Compute(ref decimal result)
        {
            decimal festivalPrijs = this.Festival.Prijs;
            decimal totaal = this.Aantal * festivalPrijs;
            result = totaal;

        }
    }
}