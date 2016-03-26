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
        partial void ActiviteitOpPodias_Validate(ActiviteitOpPodia entity, EntitySetValidationResultsBuilder results)
        {
            int currentPodiumId = entity.Podium.Id;
            DateTime currentVan = entity.Van;

            int queryResult = this.getPodiaByVan(currentPodiumId, currentVan).Count();

            if (queryResult > 0)
            {
                results.AddEntityError("your screwed bro " + currentPodiumId + " " + queryResult);
            }
        }
    }
}