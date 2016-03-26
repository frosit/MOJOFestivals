/// <reference path="~/GeneratedArtifacts/viewModel.js" />

myapp.ViewFestival.Details_postRender = function (element, contentItem) {
    // Write code here.
    var name = contentItem.screen.Festival.details.getModel()[':@SummaryProperty'].property.name;
    contentItem.dataBind("screen.Festival." + name, function (value) {
        contentItem.screen.details.displayName = value;
    });
}


myapp.ViewFestival.jsTicketsResterend_postRender = function (element, contentItem) {
    function calculateTickets(tickets) {
        var total = 0;
        for (i = 0; i < tickets.length; i++) {
            total = total + tickets[i]["Aantal"];
        }
        return total;
    }

    function updateTicketsResterend() {
        var ticketsVerkocht = contentItem.screen.getTickets().then(function (result) {
            totaalVerkocht = calculateTickets(result.data);

            var totaalMsg = "";
            
            var totaalTickets = contentItem.screen.Festival.TicketsTotaal;
            if (totaalVerkocht < totaalTickets) {
                
                totaalMsg = "Er zijn nog " + String( totaalTickets - totaalVerkocht) + " ticket(s) over.";
                console.log(totaalVerkocht);
            } else {
                totaalMsg = "Helaas, we zijn uitverkocht";
            }
            

            contentItem.screen.jsTicketsResterend = totaalMsg;
            //return totaal;
        });
    }

    contentItem.dataBind("screen.jsTicketsResterend", updateTicketsResterend);

};