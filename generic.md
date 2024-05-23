---
layout: post
title: Generic
description: Lorem ipsum dolor est
image: assets/images/pic03.jpg
nav-menu: true
---

<!----------------------------------------------MAP OF TRAVELED COUNTRIES---------------------------------------------------->
<h3>Blockquote</h3>
<blockquote>Fringilla nisl. Donec accumsan interdum nisi, quis tincidunt felis sagittis eget tempus euismod. Vestibulum ante ipsum primis in faucibus vestibulum. Blandit adipiscing eu felis iaculis volutpat ac adipiscing accumsan faucibus. Vestibulum ante ipsum primis in faucibus vestibulum. Blandit adipiscing eu felis.</blockquote>

 <!DOCTYPE html>
    <html lang="en">
        <head>
            <meta charset="UTF-8">
            <meta name="viewport" content="width=device-width, initial-scale=1.0">
            <title>My Travel Map</title>
            <link rel="stylesheet" href="https://unpkg.com/leaflet/dist/leaflet.css" />
            <style>
                #map {
                    height: 400px; /* Set the height of the map */
                    width: 100%; /* Set the width of the map */
                    margin-top: 20px;
                }
            </style>
        </head>
        <body>
            <div id="map"></div>
            <script src="https://unpkg.com/leaflet/dist/leaflet.js"></script>
            <script>
                // Initialize the map
                var map = L.map('map').setView([20, 0], 2); // Center the map at latitude 20 and longitude 0, with a zoom level of 2
                // Add OpenStreetMap tiles in English
                L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
                    attribution: '&copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors',
                    maxZoom: 18, // Set maximum zoom level
                    minZoom: 2 // Set minimum zoom level
                }).addTo(map);
                // Set maximum boundaries for the map
                var southWest = L.latLng(-90, -180); // Bottom-left corner of the map
                var northEast = L.latLng(90, 180); // Top-right corner of the map
                var bounds = L.latLngBounds(southWest, northEast); // Set the map boundaries
                map.setMaxBounds(bounds); // Apply the boundaries to the map
                map.on('drag', function() {
                    map.panInsideBounds(bounds, { animate: false }); // Keep the map within the boundaries while dragging
                });
          // Add markers for each country visited
          var countries = [
            {lat: 43.65107, lon: -79.347015, name: "Toronto, Canada"},
            {lat: 50.8503, lon: 4.3517, name: "Brussels, Belgium"},
            {lat: 60.1695, lon: 24.9354, name: "Helsinki, Finland"},
            {lat: 59.3293, lon: 18.0686, name: "Stockholm, Sweden"},
            {lat: 59.437, lon: 24.7536, name: "Tallinn, Estonia"},
            {lat: 10.2992, lon: -85.839, name: "Tamarindo, Costa Rica"},
            {lat: 12.0569, lon: -61.7481, name: "Saint George's, Grenada"},
            {lat: -33.8688, lon: 151.2093, name: "Sydney, Australia"},
            {lat: -45.0312, lon: 168.6626, name: "Queenstown, New Zealand"},
            {lat: 41.3851, lon: 2.1734, name: "Barcelona, Spain"},
            {lat: 41.2376, lon: 1.8055, name: "Sitges, Spain"},
            {lat: 41.3145, lon: 2.0635, name: "Viladecans, Spain"},
            {lat: 41.1189, lon: 1.2445, name: "Tarragona, Spain"},
            {lat: 38.7223, lon: -9.1393, name: "Lisboa, Portugal"},
            {lat: 41.1496, lon: -8.6109, name: "Porto, Portugal"},
            {lat: 38.8029, lon: -9.3817, name: "Sintra, Portugal"},
            {lat: 38.697, lon: -9.4215, name: "Cascais, Portugal"},
            {lat: 42.3154, lon: 1.5968, name: "La Molina, Spain"},
            {lat: 30.422, lon: -9.5595, name: "Agadir, Morocco"},
            {lat: 31.6295, lon: -7.9811, name: "Marrakech, Morocco"},
            {lat: 69.6496, lon: 18.956, name: "Tromso, Norway"},
            {lat: 55.6761, lon: 12.5683, name: "Copenhagen, Denmark"},
            {lat: 43.7102, lon: 7.262, name: "Nice, France"},
            {lat: 43.7384, lon: 7.4246, name: "Monte Carlo, Monaco"},
            {lat: 46.2044, lon: 6.1432, name: "Geneva, Switzerland"},
            {lat: 45.9237, lon: 6.8694, name: "Mont Chamonix, France"},
            {lat: 53.3498, lon: -6.2603, name: "Dublin, Ireland"},
            {lat: 53.0027, lon: -9.2896, name: "Cliffs of Moher, Lislorkan North, Ireland"},
            {lat: 53.2707, lon: -9.0568, name: "Galway, Ireland"},
            {lat: 55.2409, lon: -6.5117, name: "Giants Causeway, Northern Ireland"},
            {lat: 55.2407, lon: -6.3665, name: "Dark Hedges, Northern Ireland"},
            {lat: 54.5973, lon: -5.9301, name: "Belfast, Northern Ireland (UK)"},
            {lat: 51.5074, lon: -0.1278, name: "London, England (UK)"},
            {lat: 40.8518, lon: 14.2681, name: "Naples, Italy"},
            {lat: 40.6755, lon: 14.7209, name: "Vietri sul Mare, Italy (Amalfi Coast)"},
            {lat: 40.6826, lon: 14.7681, name: "Salerno, Italy (Amalfi coast)"},
            {lat: 40.746, lon: 14.4984, name: "Pompeii, Italy"},
            {lat: 40.8211, lon: 14.4283, name: "Mount Vesuvius, Italy"},
            {lat: 41.9028, lon: 12.4964, name: "Rome, Italy"},
            {lat: 41.9029, lon: 12.4534, name: "Vatican City, Vatican"},
            {lat: 31.95, lon: 35.9333, name: "Amman, Jordan"},
            {lat: 30.3285, lon: 35.4444, name: "Petra, Jordan"},
            {lat: 31.5, lon: 35.3333, name: "Dead Sea, Jordan"},
            {lat: 34.772, lon: 32.4293, name: "Paphos, Cyprus"},
            {lat: 34.8824, lon: 33.4914, name: "Blue Lagoon, Cyprus"},
            {lat: 40.6401, lon: 22.9444, name: "Thessaloniki"},
            {lat: 30.2672, lon: -97.7431, name: "Austin, Texas"},
            {lat: 40.7128, lon: -74.0060, name: "New York City, New York"},
            {lat: 39.7392, lon: -104.9903, name: "Denver, Colorado"},
            {lat: 37.7749, lon: -122.4194, name: "San Francisco, California"},
            {lat: 25.7617, lon: -80.1918, name: "Miami, Florida"},
            {lat: 35.7884, lon: -83.5319, name: "Dollywood, Tennessee"}
            // Add more countries here
          ];
          countries.forEach(function(country) {
            L.marker([country.lat, country.lon]).addTo(map)
            .bindPopup(country.name)
            .openPopup();
        });
    </script>
</body>
</html>


