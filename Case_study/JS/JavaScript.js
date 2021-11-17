function CallLogicApp(jsonData) {
    var source = document.getElementById("source").jsonData.source;
    var destination = document.getElementById("destination").jsonData.destination;
    var Airplane = document.getElementById("Airplane").jsonData.Airplane;
    var departure = document.getElementById("departure").jsonData.departure;
    var type = document.getElementById("type").jsonData.type;
    var price = document.getElementById("price").jsonData.price;
    console.log(source);
        var bookingconfirmation =
        {
            source: source,
            destination=destination,
            Airplane=Airplane,
            departure=departure,
            type=type,
            price=price
        };
    var url = "https://prod-61.eastus.logic.azure.com:443/workflows/0b75b563b00d4bbeb3241ae2f3ebc250/triggers/manual/paths/invoke?api-version=2016-10-01&sp=%2Ftriggers%2Fmanual%2Frun&sv=1.0&sig=YTOHgOIVIGGWORRW0IMOLc51FA3aWs6E5cyqFnmS_CA";
        var http = new XMLHttpRequest();
        http.open('POST', url, true);
        //Send the proper header information along with the request
        http.setRequestHeader('Content-type', 'application/x-www-form-urlencoded');
        http.onreadystatechange = function () {//Call a function when the state changes.
            if (http.readyState == 4 && http.status == 200) {
                alert(http.responseText);
            }
        }
            http.send(JSON.stringify(bookingconfirmation));
    