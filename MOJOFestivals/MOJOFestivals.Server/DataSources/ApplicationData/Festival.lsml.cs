using Microsoft.LightSwitch;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using System;

namespace LightSwitchApplication
{
    public partial class Festival
    {
        partial void TicketsResterend_Compute(ref string result)
        {
            int totaal = this.Tickets.Sum(h => h.Aantal);
            int resterend = this.TicketsTotaal - totaal;

            if(resterend > 0)
            {
                result = "Er zijn nog " + Convert.ToString(resterend) + " ticket(s) over.";
            }
            else
            {
                result = "Helaas, we zijn uitverkocht.";
            }
        }

        partial void TotaalBeoordelingen_Compute(ref int result)
        {
            result = this.Beoordelingen.Count();

        }

        partial void GemiddeldeBeoordeling_Compute(ref decimal result)
        {
            decimal totaalAantal = this.Beoordelingen.Count();
            decimal totaal = this.Beoordelingen.Sum(h => Convert.ToDecimal(h.Score));
            if (totaal + totaalAantal > 1)
            {
                result = totaal / totaalAantal;
            }
            else
            {
                result = 0;
            }

        }
    }
}