/// <reference path="~/GeneratedArtifacts/viewModel.js" />

myapp.ViewTicket.Details_postRender = function (element, contentItem) {
    // Write code here.
    var name = contentItem.screen.Ticket.details.getModel()[':@SummaryProperty'].property.name;
    contentItem.dataBind("screen.Ticket." + name, function (value) {
        contentItem.screen.details.displayName = value;
    });
}

