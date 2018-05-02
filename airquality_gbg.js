var xmlhttp = new XMLHttpRequest();
var url = "http://data.goteborg.se/AirQualityService/v1.0/LatestMeasurement/9309174e-34a2-4ccf-98f5-d0e33772dc7b?format=json";

xmlhttp.onreadystatechange = function() {
  if (this.readyState == 4 && this.status == 200) {
      var AirQuality = JSON.parse(this.responseText);
      document.getElementById("json").innerHTML = AirQuality["AirQuality"]["TotalIndex"];
      var heat = L.heatLayer([
            [56.044, 12.71, AirQuality["AirQuality"]["TotalIndex"]*10]
         ], {radius: 120, gradient: {0.2: 'yellow', 0.6: 'orange', 0.9: 'red'}}).addTo(mymap);
  }
};
xmlhttp.open("GET", url, true);
xmlhttp.send();
