/// <reference path="~/GeneratedArtifacts/viewModel.js" />

myapp.ViewBeoordeling.Details_postRender = function (element, contentItem) {
    // Write code here.
    var name = contentItem.screen.Beoordeling.details.getModel()[':@SummaryProperty'].property.name;
    contentItem.dataBind("screen.Beoordeling." + name, function (value) {
        contentItem.screen.details.displayName = value;
    });
}

