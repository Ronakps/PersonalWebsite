<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>About Ronak Shah</title>
    <link rel="stylesheet" href="https://unpkg.com/leaflet/dist/leaflet.css" />
    <style>
        body {
            font-family: Arial, sans-serif;
            margin: 20px;
        }
        .section {
            margin-bottom: 40px;
            /* Remove text-align: center to prevent centering all section text */
        }
        .title {
            font-size: 24px;
            font-weight: bold;
            text-align: center; /* Centering only the title */
        }
        .subtitle {
            font-size: 16px;
            margin-bottom: 20px;
            text-align: center; /* Centering only the subtitle */
        }
        .social-links {
            text-align: center; /* Centering social links */
        }
        .social-links img {
            width: 40px;
            height: 40px;
            margin: 0 10px;
            border-radius: 50%;
        }
        .photo {
            border-radius: 50%;
            width: 200px;
            height: 200px;
            object-fit: cover;
            display: block;
            margin: 20px auto 0; /* Move the photo down */
            padding-top: 20px; /* Adjust padding to move the image content down within the frame */
        }
        .intro {
            font-size: 18px;
            margin-top: 20px; /* Ensure there's space between the photo and the intro text */
            margin-bottom: 20px;
        }
        .about-subsection {
            text-align: left;
            margin: 20px auto;
            max-width: 900px;
        }
        .about-subsection h3 {
            font-size: 20px;
            margin-top: 20px;
        }
        table {
            width: 100%;
            border-collapse: collapse;
            margin-bottom: 20px;
        }
        table, th, td {
            border: 1px solid black;
        }
        th, td {
            padding: 10px;
            text-align: left;
        }
        /* Specific styles for About Me section */
        #about-me {
            text-align: left;
            margin: 20px 0;
        }
        #about-me .about-subsection {
            text-align: left;
            margin: 0;
        }

        /* Updated styles for circle frames and photos */
        .skills-list img {
            border-radius: 50%;
            width: 80px; /* Decreased size */
            height: 80px; /* Decreased size */
            object-fit: cover;
        }

        /* Adjusted layout for computer skills and coding skills */
        .skills-list {
            list-style: none;
            padding: 0;
            display: flex;
            flex-wrap: wrap;
            justify-content: center;
        }

        .skills-list li {
            margin: 10px;
            text-align: center;
            width: calc(50% - 20px); /* 50% width with margin */
            flex-basis: calc(50% - 20px); /* 50% flex basis with margin */
        }

        /* Updated styles for skill categories */
        .skill-category {
            margin: 20px;
            width: 50%; /* Half width */
            flex-basis: 50%; /* Half flex basis */
        }
    </style>        
</head>

<body>
    <!-- Section 1 -->
    <div class="section">
        <div class="title">Ronak Shah</div>
        <div class="subtitle">Student, Adventurer, Traveler, Yogi</div>
        <div class="social-links">
            <a href="https://www.linkedin.com/in/ronakps/"><img src="Photos/LinkedIn.png" alt="LinkedIn"></a>
        </div>
    </div>

    <!-- Section 2 -->
    <div class="section">
        <img src="Photos/Headshot.jpeg" alt="Headshot" class="photo">
        <div class="intro">
            I currently attend the University of Texas at Austin where I major in Management Information Systems and minor in Finance. Now, looking toward my professional career, I have a deep passion for leveraging data to drive meaningful business insights and solutions. My academic background in MIS combined coding, data analytics, and business strategy. That coupled with my experience in using SQL and Python, has equipped me with the skills to adapt to new technologies and methodologies. I thrive on the challenge of working with innovative technologies like artificial intelligence and machine learning, and I am particularly excited about using these tools to enhance customer experiences. Additionally, my experience in collaborating with cross-functional teams to analyze and improve processes has reinforced my desire to be at the forefront of technological advancements that solve real-world problems.
        </div>
        <p>You can view my resume <a href="Photos/RonakShahResume.pdf" target="_blank">here</a>.</p>
    </div>

    <!-- Section 3 -->
    <div class="section">
        <div class="title">About Me</div>
        <html lang="en">
            <head>
                <meta charset="UTF-8">
                <meta name="viewport" content="width=device-width, initial-scale=1.0">
                <title>About Ronak Shah</title>
                <style>
                    body {
                        font-family: Arial, sans-serif;
                        margin: 20px;
                    }
                    .section {
                        margin-bottom: 40px;
                        /* Remove text-align: center to prevent centering all section text */
                    }
                    .title {
                        font-size: 24px;
                        font-weight: bold;
                        text-align: center; /* Centering only the title */
                        text-decoration: underline; /* Underline the title */
                    }
                    .subtitle {
                        font-size: 16px;
                        margin-bottom: 20px;
                        text-align: center; /* Centering only the subtitle */
                    }
                    .social-links {
                        text-align: center; /* Centering social links */
                    }
                    .social-links img {
                        width: 40px;
                        height: 40px;
                        margin: 0 10px;
                        border-radius: 50%;
                    }
                    .photo {
                        border-radius: 50%;
                        width: 200px;
                        height: 200px;
                        object-fit: cover;
                        display: block;
                        margin: 0 auto 20px;
                    }
                    .intro {
                        font-size: 18px;
                        margin-bottom: 20px;
                    }
                    .about-subsection {
                        text-align: left;
                        margin: 20px auto;
                        max-width: 900px;
                    }
                    .about-subsection h3 {
                        font-size: 20px;
                        margin-top: 20px;
                    }
                    .skills-section {
                        display: flex;
                        flex-wrap: wrap;
                        justify-content: center;
                    }
                    .skill-category {
                        margin: 20px;
                    }
                    .skills-list {
                        list-style: none;
                        padding: 0;
                        display: flex;
                        flex-wrap: wrap;
                        justify-content: center;
                    }
                    .skills-list li {
                        margin: 10px;
                        text-align: center;
                        width: 18%; /* Adjusting width to fit 6 items per row */
                    }
                    .skills-list img {
                        border-radius: 50%;
                        width: 120px; /* Increased size */
                        height: 120px; /* Increased size */
                        object-fit: cover;
                    }
                    .skill-category h3 {
                        text-align: center; /* Center the category headers */
                    }
                </style>
            </head>            
            <body>
                <div class="about-subsection">
                    <div class="skills-section">
                        <div class="skill-category">
                            <h3>Computer Skills</h3>
                            <ul class="skills-list">
                                <!-- Computer Skills -->
                                <li><img src="Photos/MSExcel.png" alt="MS Excel"><br>MS Excel</li>
                                <li><img src="Photos/MSPowerPoint.png" alt="MS PowerPoint"><br>MS PowerPoint</li>
                                <li><img src="Photos/MSPowerAutomate.jpeg" alt="MS Automate"><br>MS Automate</li>
                                <li><img src="Photos/GSuite.jpeg" alt="Google Suite"><br>Google Suite</li>
                                <li><img src="Photos/Tableau.png" alt="Tableau"><br>Tableau</li>
                                <li><img src="Photos/PowerBI.png" alt="PowerBI"><br>PowerBI</li>
                                <li><img src="Photos/Talentlms.png" alt="Talentlms"><br>Talentlms</li>
                                <li><img src="Photos/WEKA.jpeg" alt="WEKA"><br>WEKA</li>
                                <li><img src="Photos/WIX.png" alt="Wix"><br>Wix</li>
                                <li><img src="Photos/VS.jpeg" alt="Visual Studio"><br>Visual Studio</li>
                                <li><img src="Photos/JIRA.png" alt="Jira"><br>Jira</li>
                            </ul>
                        </div>
                        <div class="skill-category">
                            <h3>Coding Skills</h3>
                            <ul class="skills-list">
                                <!-- Coding Skills -->
                                <li><img src="Photos/github.png" alt="Github"><br>Github</li>
                                <li><img src="Photos/python.png" alt="Python"><br>Python</li>
                                <li><img src="Photos/sql.jpeg" alt="SQL"><br>SQL</li>
                                <li><img src="Photos/csharp.jpeg" alt="C#"><br>C#</li>
                                <li><img src="Photos/r.jpeg" alt="R"><br>R</li>
                                <li><img src="Photos/html.png" alt="HTML"><br>HTML</li>
                                <li><img src="Photos/dotnet.png" alt=".NET"><br>.NET</li>
                                <li><img src="Photos/aspdotnet.jpeg" alt=".ASP.NET"><br>.ASP.NET</li>
                                <li><img src="Photos/css.png" alt="CSS"><br>CSS</li>
                                <li><img src="Photos/mvc.png" alt="MVC"><br>MVC</li>
                            </ul>
                        </div>
                    </div>
                </div>
            </body>
            </html>
        
        <html lang="en">
        <head>
            <meta charset="UTF-8">
            <meta name="viewport" content="width=device-width, initial-scale=1.0">
            <title>Relevant Coursework</title>
            <style>
                body {
                    font-family: Arial, sans-serif;
                    margin: 20px;
                }
                .about-subsection {
                    text-align: left;
                    margin: 20px auto;
                    max-width: 900px;
                }
                table {
                    width: 100%;
                    border-collapse: collapse;
                    margin-bottom: 20px;
                }
                th, td {
                    border: 1px solid black;
                    padding: 10px;
                    text-align: left;
                    vertical-align: top;
                }
                th {
                    background-color: #f2f2f2;
                }
                td ul {
                    margin: 0;
                    padding-left: 20px;
                }
                td.description {
                    width: 60%;
                }
                td.course, td.skills {
                    width: 20%;
                }
            </style>
        </head>
        <body>
            <div class="about-subsection">
                <h3>Relevant Coursework</h3>
                <table>
                    <tr>
                        <th>Course</th>
                        <th>Description</th>
                        <th>Skills Utilized</th>
                    </tr>
                    <tr>
                        <td class="course">Introduction to Data Science</td>
                        <td class="description">
                            <ul>
                                <li>An introduction to the principles and practice of data science for business applications.</li>
                                <li>Explore tidying, summarizing, and visualizing data; statistical computing in R; linear regression; introduction to predictive modeling and out-of-sample model validation.</li>
                                <li>Uncertainty quantification using resampling methods.</li>
                                <li>Basic probability models, including the normal and binomial distributions; and statistical hypothesis testing.</li>
                            </ul>
                        </td>
                        <td class="skills">R</td>
                    </tr>
                    <tr>
                        <td class="course">Introduction to Decision Science</td>
                        <td class="description">
                            <ul>
                                <li>Examine modeling of business problems using methods from decision analysis, simulation and optimization.</li>
                            </ul>
                        </td>
                        <td class="skills">Microsoft Excel</td>
                    </tr>
                    <tr>
                        <td class="course">Data Science for Business Applications</td>
                        <td class="description">
                            <ul>
                                <li>Examine data science for business applications at the intermediate level.</li>
                                <li>Explore building and validating predictive models; advanced regression modeling, including an in-depth treatment of regression; models for binary outcomes; and causal inference.</li>
                            </ul>
                        </td>
                        <td class="skills">R</td>
                    </tr>
                    <tr>
                        <td class="course">Database Management</td>
                        <td class="description">
                            <ul>
                                <li>Beginning and intermediate topics in data modeling for relational database management systems.</li>
                            </ul>
                        </td>
                        <td class="skills">SQL, SQL Developer</td>
                    </tr>
                    <tr>
                        <td class="course">Operations Management</td>
                        <td class="description">
                            <ul>
                                <li>The operations or production function and the skills required for analyzing and solving related problems.</li>
                            </ul>
                        </td>
                        <td class="skills">Microsoft PowerPoint</td>
                    </tr>
                    <tr>
                        <td class="course">Introduction to Programming / Problem Solving</td>
                        <td class="description">
                            <ul>
                                <li>Programming skills for creating easy-to-maintain systems for business applications.</li>
                                <li>Object-oriented and structured methodologies with Python.</li>
                            </ul>
                        </td>
                        <td class="skills">Python, Spyder</td>
                    </tr>
                    <tr>
                        <td class="course">Web Application Development</td>
                        <td class="description">
                            <ul>
                                <li>Concepts and practices of information systems.</li>
                                <li>Advanced programming techniques used to generate menu-driven applications.</li>
                            </ul>
                        </td>
                        <td class="skills">C#, HTML, CSS, Github, Visual Studio, Lucid Chart</td>
                    </tr>
                    <tr>
                        <td class="course">Predictive Analytics / Data Mining</td>
                        <td class="description">
                            <ul>
                                <li>Introduction to data mining problems and tools to enhance managerial decision making at all levels of the organization.</li>
                                <li>Discuss scenarios, including the use of data mining to support customer relationship management (CRM) decisions, decisions in the entertainment industry, financial trading, and even professional sports teams.</li>
                            </ul>
                        </td>
                        <td class="skills">WEKA, Microsoft Excel</td>
                    </tr>
                    <tr>
                        <td class="course">Strategic Information Technology Management</td>
                        <td class="description">
                            <ul>
                                <li>Designed to develop an understanding and appreciation for the role of information technology in the context of a firm's strategy.</li>
                                <li>Explores the impact of information technology on the economy and business performance, the emergence of electronic business applications and organizational and market transformation, and the nature of technology-driven business models and strategies.</li>
                            </ul>
                        </td>
                        <td class="skills">Microsoft PowerPoint, Roadmapping, Executive Summary</td>
                    </tr>
                    <tr>
                        <td class="course">Golf</td>
                        <td class="description">
                            <ul>
                                <li>Learned and attempted to master the game of golf.</li>
                            </ul>
                        </td>
                        <td class="skills">Drivers, Woods, Hybrids, Irons, Wedges, Putter</td>
                    </tr>
                </table>
            </div>
        </body>
        </html>
        
        <div class="about-subsection">
            <h3>Activities</h3>
            <p>I love to explore different parts of life whenever I have free time. This includes...</p>
            <ul>
                <li>Triathlons and marathons. I have run the Austin Half-Marathon in February 2024 and currently training for a half Iron-Man triathlon (70.3 miles)</li>
                <li>Traveling to new places around the world. I love to road trip and explore in the area that I am in. This includes participating in the culture, the nightlife, and trying out the food</li>
                <li>Any adrenaline activities. Whether finding new underground cliff diving spots in Austin or going skydiving in the rural areas of New Zealand</li>
                <li>Practicing yoga and meditation. I help my friends and family find inner peace during stressful times; for example during final exam season.</li>
                <li>Professional and Collegiate sports such as basketball, football, golf, soccer, pickleball, baseball.</li>
            </ul>
        </div>
        
        <html lang="en">
            <head>
                <meta charset="UTF-8">
                <meta name="viewport" content="width=device-width, initial-scale=1.0">
                <title>My Sports Teams</title>
                <style>
                    body {
                        font-family: Arial, sans-serif;
                        margin: 20px;
                    }
                    .about-subsection {
                        margin: 20px auto;
                        max-width: 900px;
                        text-align: center;
                    }
                    .team-container {
                        display: flex;
                        flex-wrap: wrap;
                        justify-content: center;
                    }
                    .team-item {
                        margin: 10px;
                    }
                    .team-item img {
                        border-radius: 50%;
                        width: 150px;
                        height: 150px;
                        object-fit: cover;
                    }
                    .team-name {
                        margin-top: 5px;
                        text-align: center;
                    }
                </style>
            </head>
            <body>
                <div class="about-subsection">
                    <h3>My Sports Teams</h3>
                    <div class="team-container">
                        <div class="team-item">
                            <img src="Photos/cowboys.png" alt="NFL Team">
                            <p class="team-name">NFL: Dallas Cowboys</p>
                        </div>
                        <div class="team-item">
                            <img src="Photos/mavs.jpeg" alt="NBA Team">
                            <p class="team-name">NBA: Dallas Mavericks</p>
                        </div>
                        <div class="team-item">
                            <img src="Photos/rangers.png" alt="MLB Team">
                            <p class="team-name">MLB: Texas Rangers</p>
                        </div>
                        <div class="team-item">
                            <img src="Photos/stars.png" alt="NHL Team">
                            <p class="team-name">NHL: Dallas Stars</p>
                        </div>
                        <div class="team-item">
                            <img src="Photos/longhorns.png" alt="NCAA Sport Teams">
                            <p class="team-name">NCAA Sports: Texas Longhorns (Hook 'em)</p>
                        </div>
                        <div class="team-item">
                            <img src="Photos/wings.png" alt="WNBA Team">
                            <p class="team-name">WNBA: Dallas Wings</p>
                        </div>
                        <div class="team-item">
                            <img src="Photos/pga.png" alt="PGA Tour Players">
                            <p class="team-name">PGA Tour: Rory McIlroy & Jordan Speith</p>
                        </div>
                        <div class="team-item">
                            <img src="Photos/barca.png" alt="LaLiga Team">
                            <p class="team-name">LaLiga: FC Barcelona</p>
                        </div>
                        <div class="team-item">
                            <img src="Photos/chelsea.png" alt="Premier League Team">
                            <p class="team-name">Premier League: Chelsea F.C.</p>
                        </div>
                    </div>
                </div>
            </body>
        </html>
    </div>
</div>
            


<html>
    <head>
        <style>
            /* CSS to remove space between bullet point and first word */
            ul {
                list-style-position: inside;
            }
        </style>
    </head>
    <body>
        <div class="about-subsection">
            <h3>Random Facts</h3>
            <ul>
                <li>Traveled to 31 countries and 4 continents (North America, Europe, Asia, Africa)</li>
                <li>Ran a half marathon in 2 hours & 3 minutes</li>
                <li>Read Outliers by Malcolm Gladwell 3 times</li>
                <li>Watched Interstellar by Christopher Nolan 8 times</li>
                <li>Watched all 12 movies directed by Christopher Nolan</li>
            </ul>
        </div>
    </body>
</html>


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


<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Education and Certification Section</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            margin: 20px;
        }
        .section {
            max-width: 900px;
            margin: 20px auto;
            text-align: left;
        }
        .section h2 {
            text-align: center;
            font-size: 24px;
            margin-bottom: 20px;
        }
        .item {
            display: flex;
            align-items: center;
            margin-bottom: 20px;
        }
        .text {
            flex: 1;
            padding-right: 10px; /* Reduced padding to bring text closer to the image */
        }
        .image img {
            border: 2px solid #ccc;
            border-radius: 8px;
            width: 200px; /* Adjust width */
            height: 200px; /* Adjust height to make it square */
            object-fit: cover; /* Ensure the entire image is shown */
            display: block;
            margin: 10px 0;
        }
    </style>
</head>
<body>
    <!-- Education Section -->
    <div class="section">
        <h2>Education</h2>
        <div class="item">
            <div class="text">
                <h3>University of Texas at Austin</h3>
                <p><strong>Field of Study:</strong> Management Information Systems & Finance</p>
                <p><strong>Location:</strong> Austin, Texas</p>
            </div>
            <div class="image">
                <img src="Photos/UT Campus.jpeg" alt="University of Texas at Austin">
            </div>
        </div>

        <div class="item">
            <div class="text">
                <h3>Universitat de Barcelona</h3>
                <p><strong>Field of Study:</strong> Business, Finance, & Liberal Arts</p>
                <p><strong>Location:</strong> Barcelona, Spain</p>
            </div>
            <div class="image">
                <img src="Photos/universitat de barcelona.jpeg" alt="Universitat de Barcelona">
            </div>
        </div>
    </div>

    <!-- Certification Section -->
    <div class="section">
        <h2>Certifications</h2>

        <!-- Certification 1 -->
        <div class="item">
            <div class="text">
                <h3>Data Driven Product Management</h3>
                <p><strong>Certification Description:</strong></p>
                <p>Learn the difference between product and marketing analytics, and why product analytics and the insight they provide are critical to making important product decisions. Drew reviews popular product analytics software tools—including AI solutions—and introduces you to the main tools and processes product managers use to analyze product data. Learn how to maintain a data-driven strategy, recognize key product analytics to measure, how to make data-driven business cases, and explore some advanced analytics considerations for product managers and their organizations.</p>
                <p>View my notes <a href="Photos/Certification For Recrutiment/Notes/Data Driven Product Management Notes.pdf" target="_blank">here!</a>.</p>
            </div>
            <div class="image">
                <img src="Photos/Certification For Recrutiment/Data Driven Product Management.pdf" alt="Data Driven Product Management">
            </div>
        </div>

        <!-- Certification 2 -->
        <div class="item">
            <div class="text">
                <h3>Product-Strategy Micro Certification</h3>
                <p><strong>Certification Description:</strong></p>
                <p>In this course, you'll delve into the crucial realm of Product Strategy, where you'll uncover the essential steps for crafting a successful product. You'll learn how to define clear goals and the methods needed to achieve them, encompassing key elements such as Product Vision, Insights, Challenges, Approaches, and Accountability. By the end of the course, you'll understand how Product Strategy provides direction and focus, aligning with broader business strategies while effectively meeting customer needs and setting you apart from competitors. Through six major steps—Market Analysis, Customer Analytics, Product Vision and Mission, Objectives and Key Results (OKRs), Product Roadmap, and Prioritization—you'll gain the knowledge and skills necessary to develop an impactful Product Strategy.</p>
                <p>View my notes <a href="Photos/Certification For Recrutiment/Notes/Product-Strategy Micro Certification.pdf" target="_blank">here!</a>.</p>
            </div>
            <div class="image">
                <img src="Photos/Certification For Recrutiment/certificate-of-completion-for-product-strategy-microcertification.pdf" alt="Product-Strategy Micro Certification">
            </div>
        </div>
    </div>

</body>
</html>
