using Microsoft.LightSwitch.Security.Server;
using Microsoft.LightSwitch;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using System;

namespace LightSwitchApplication
{
    public partial class ApplicationDataService
    {

        // validatie voor aanmaken activiteit tot podium, momenteel controleert hij podium + datumtijd vanaf
        partial void ActiviteitOpPodias_Validate(ActiviteitOpPodia entity, EntitySetValidationResultsBuilder results)
        {
            int currentPodiumId = entity.Podium.Id;
            DateTime currentVan = entity.Van;

            int queryResult = this.getPodiaByVan(currentPodiumId, currentVan).Count();

            if (queryResult > 0)
            {
                results.AddEntityError("De begin datum / tijd voor dit podium is al in gebruik. Kies een ander podium of tijd.");
            }
        }
    }
}