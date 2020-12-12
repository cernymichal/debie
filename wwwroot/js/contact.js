var mapOptions = {
    center: [40.7069, -74.0123],
    zoom: 12,
};

var map = new L.map("contact-map", mapOptions);

var layer = new L.TileLayer(
    "http://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png",
    {
        attribution:
            "Map data &copy; <a href='https://www.openstreetmap.org/'>OpenStreetMap</a> contributors, <a href='https://creativecommons.org/licenses/by-sa/2.0/'>CC-BY-SA</a>",
    }
).addTo(map);

var marker = L.marker([40.7069, -74.0123]).addTo(map);

marker.bindPopup("<b>You can find us here!</b>").openPopup();
