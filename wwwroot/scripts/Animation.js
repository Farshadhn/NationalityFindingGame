function StartAnimation(dotnet, id, time) {
    var indexer = "#" + id;
    var indexed = $(indexer);
    indexed.animate({
        top: "65vh"
    }, time, function () {
        indexed.css("top", 0);

        dotnet.invokeMethodAsync('NextFacePhoto');
    });
}
function stopAnimation(dotnet, id) {
    var indexer = "#" + id;
    var indexed = $(indexer);
    indexed.stop();
    indexed.css("top", 0);

    dotnet.invokeMethodAsync('NextFacePhoto');
}