/// <reference path="~/GeneratedArtifacts/viewModel.js" />

myapp.ViewFestival.Details_postRender = function (element, contentItem) {
    // Write code here.
    var name = contentItem.screen.Festival.details.getModel()[':@SummaryProperty'].property.name;
    contentItem.dataBind("screen.Festival." + name, function (value) {
        contentItem.screen.details.displayName = value;
    });
}


myapp.ViewFestival.TicketsResterend_postRender = function (element, contentItem) {
    // Write code here.

};