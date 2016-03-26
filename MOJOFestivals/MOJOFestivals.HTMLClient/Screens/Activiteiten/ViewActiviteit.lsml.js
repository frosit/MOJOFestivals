/// <reference path="~/GeneratedArtifacts/viewModel.js" />

myapp.ViewActiviteit.Details_postRender = function (element, contentItem) {
    // Write code here.
    var name = contentItem.screen.Activiteit.details.getModel()[':@SummaryProperty'].property.name;
    contentItem.dataBind("screen.Activiteit." + name, function (value) {
        contentItem.screen.details.displayName = value;
    });
}

