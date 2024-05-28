---
layout: post
title: About Me
description: My personal life
image: false
nav-menu: true
---

<!----------------------------------------------MAP OF TRAVELED COUNTRIES---------------------------------------------------->
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>My Travel Map</title>
    <link rel="stylesheet" href="https://unpkg.com/leaflet/dist/leaflet.css" />
    <style>
        #map {
            height: 500px; /* Adjust as needed */
            width: 100%;
        }
    </style>
</head>
<body>
    <h3>My Travel Map</h3>
    <blockquote>Below is a visualization I coded using HTML about all the cities I have traveled to. Traveled to 31 countries and 4 continents (North America, Europe, Asia, Africa)</blockquote>
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
            {lat: 34.0522, lon: -118.2437, name: "Los Angeles, California"},
            {lat: 32.7157, lon: -117.1611, name: "San Diego, California"},
            {lat: 25.7617, lon: -80.1918, name: "Miami, Florida"},
            {lat: 35.7884, lon: -83.5319, name: "Dollywood, Tennessee"}
        ];
        countries.forEach(function(country) {
            var marker = L.marker([country.lat, country.lon]).addTo(map);
            marker.bindPopup(country.name);
        });
    </script>
</body>
</html>

<hr class="major" />

<!----------------------------------------------My Activities / FUN FACTS ---------------------------------------------------->
<div class="row">
    <div class="6u 12u$(small)">
        <h3>Activities</h3>
        <p>I love exploring nature and life whenever I have free time including...</p>
        <ul>
            <li>Triathlons and marathons. I have run the Austin Half-Marathon in February 2024 and currently training for a half Iron-Man triathlon (70.3 miles).</li>
            <li>Traveling to new places around the world. I love to road trip and explore in the area that I am in. This includes participating in the culture, the nightlife, and trying out the food.</li>
            <li>Any adrenaline activities. Whether finding new underground cliff diving spots in Austin or going skydiving in the rural areas of New Zealand.</li>
            <li>Practicing yoga and meditation. I help my friends and family find inner peace during stressful times; for example during final exam season.</li>
            <li>Professional and Collegiate sports such as basketball, football, golf, soccer, pickleball, baseball.</li>
        </ul>
    </div>
    <div class="6u 12u$(small)">
        <h3>Fun Facts</h3>
        <p>Some interesting things about me...</p>
		<ul>
            <li>Ran a half marathon in 2 hours & 3 minutes (I love strava)</li>
            <li>Read Outliers by Malcolm Gladwell 3 times</li>
            <li>Watched Interstellar by Christopher Nolan 8 times</li>
            <li>Whitewater rafted & Kayaked 7 days straight in West Virginia</li>
            <li>Ate chipotle everyday for 84 days straight(12 weeks)</li>
            <li>Watched all 12 movies directed by Christopher Nolan</li>
		</ul>
    </div>
</div>

<hr class="major" />

<!----------------------------------------------My sports teams---------------------------------------------------->
<h3>My Sport Teams</h3>
<div class="box alt">
    <div class="row 50% uniform">
        <!-- First Row -->
        <div class="2u"><span class="image fit"><img src="assets/images/SportTeam/chelsea.jpeg" alt="" alt="" style="width: 200px; height: 200px;"/></span></div>
        <div class="2u"><span class="image fit"><img src="assets/images/SportTeam/cowboys.jpeg" alt="" style="width: 200px; height: 200px;"/></span></div>
        <div class="2u"><span class="image fit"><img src="assets/images/SportTeam/fcbarca.png" alt="" style="width: 200px; height: 200px;"/></span></div>
        <div class="2u"><span class="image fit"><img src="assets/images/SportTeam/longhorns.png" alt="" style="width: 200px; height: 200px;"/></span></div>
        <div class="2u"><span class="image fit"><img src="assets/images/SportTeam/mavs.png" alt="" style="width: 200px; height: 200px;"/></span></div>
        <div class="2u$"><span class="image fit"><img src="assets/images/SportTeam/pga.jpeg" alt="" style="width: 200px; height: 200px;"/></span></div>
        <!-- Break -->
        <!-- Second Row -->
        <div class="2u"><span class="image fit"><img src="assets/images/SportTeam/stars.png" alt="" style="width: 200px; height: 200px;"/></span></div>
        <div class="2u"><span class="image fit"><img src="assets/images/SportTeam/wings.png" alt="" style="width: 200px; height: 200px;"/></span></div>
        <div class="2u"><span class="image fit"><img src="assets/images/SportTeam/rangers.png" alt="" style="width: 200px; height: 200px;"/></span></div>
        <div class="2u"><span class="image fit"><img src="assets/images/SportTeam/intermiami.jpeg" alt="" style="width: 200px; height: 200px;"/></span></div>
        <div class="2u"><span class="image fit"><img src="assets/images/SportTeam/gujarat.png" alt="" style="width: 200px; height: 200px;" /></span></div>
        <div class="2u$"><span class="image fit"><img src="assets/images/SportTeam/tennis.png" alt="" style="width: 200px; height: 200px;"/></span></div>
    </div>
        <!-- Text block spanning the width of the photos -->
    <div class="row uniform">
        <div class="12u">
            <p>My favorite sports teams span across various leagues and include some of the most iconic names in sports. In the NFL, I root for the Dallas Cowboys (hoping we win a Super Bowl one day), while in the NBA, I support the Dallas Mavericks, home to star player Luka Dončić. For baseball, I follow the Texas Rangers, and in the NHL, I'm a fan of the Dallas Stars. My college sports allegiance lies with the Texas Longhorns (Hook 'em!), and in the WNBA, I root for the Dallas Wings. Additionally, I follow golf stars Rory McIlroy and Jordan Spieth, support FC Barcelona in LaLiga, Chelsea F.C. in the Premier League, Inter Miami in the MLS, and the Gujarat Titans in the IPL, with tennis legend Rafael Nadal rounding out my favorite athletes. I absolutely love sports so very open to talk about any and all sports.</p>
        </div>
    </div>
</div>
