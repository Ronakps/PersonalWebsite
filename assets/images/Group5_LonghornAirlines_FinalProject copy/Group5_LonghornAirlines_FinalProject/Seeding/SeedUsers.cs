
using Group5_LonghornAirlines_FinalProject.DAL;
using Group5_LonghornAirlines_FinalProject.Models;
using Group5_LonghornAirlines_FinalProject.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Group5_LonghornAirlines_FinalProject.Seeding
{

    public static class SeedUsers
    {
        public async static Task<IdentityResult> SeedAllUsers(UserManager<AppUser> userManager, AppDbContext context)
        {
            //Create a list of AddUserModels
            List<AddUserModel> AllUsers = new List<AddUserModel>();


            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the
                    //IdentityUser base class
                    UserName = "cbaker@freserve.co.uk",
                    Email = "cbaker@freserve.co.uk",
                    PhoneNumber = "4695571146",

                    // Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Christopher",
                    LastName = "Baker",
                    MiddleInitial = "L.",
                    DateOfBirth = DateTime.Parse("1949-11-23 00:00:00"),
                    Street = "1245 Lake Anchorage Blvd.",
                    City = "Dallas",
                    Zip = "75001",
                    State = "TX",
                    AdvantageNumber = 5001,
                    ActiveStatus = true,
                    Miles = 0
                },
                Password = "hello123",
                RoleName = "Customer"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the
                    //IdentityUser base class
                    UserName = "banker@longhorn.net",
                    Email = "banker@longhorn.net",
                    PhoneNumber = "4692678873",

                    // Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Michelle",
                    LastName = "Banks",
                    MiddleInitial = "nan",
                    DateOfBirth = DateTime.Parse("1962-11-27 00:00:00"),
                    Street = "1300 Tall Pine Lane",
                    City = "Dallas",
                    Zip = "75002",
                    State = "TX",
                    AdvantageNumber = 5002,
                    ActiveStatus = true,
                    Miles = 0
                },
                Password = "potato",
                RoleName = "Customer"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the
                    //IdentityUser base class
                    UserName = "franco@aoll.com",
                    Email = "franco@aoll.com",
                    PhoneNumber = "2815659699",

                    // Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Franco",
                    LastName = "Broccolo",
                    MiddleInitial = "V",
                    DateOfBirth = DateTime.Parse("1992-10-11 00:00:00"),
                    Street = "62 Browning Road",
                    City = "Houston",
                    Zip = "77003",
                    State = "TX",
                    AdvantageNumber = 5003,
                    ActiveStatus = true,
                    Miles = 0
                },
                Password = "painting",
                RoleName = "Customer"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the
                    //IdentityUser base class
                    UserName = "wchang@gogle.com",
                    Email = "wchang@gogle.com",
                    PhoneNumber = "5125943222",

                    // Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Wendy",
                    LastName = "Chang",
                    MiddleInitial = "L",
                    DateOfBirth = DateTime.Parse("1997-05-16 00:00:00"),
                    Street = "202 Bellmont Hall",
                    City = "Austin",
                    Zip = "78719",
                    State = "TX",
                    AdvantageNumber = 5004,
                    ActiveStatus = true,
                    Miles = 0
                },
                Password = "texas2000",
                RoleName = "Customer"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the
                    //IdentityUser base class
                    UserName = "limchou@yoho.com",
                    Email = "limchou@yoho.com",
                    PhoneNumber = "8137724599",

                    // Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Lim",
                    LastName = "Chou",
                    MiddleInitial = "nan",
                    DateOfBirth = DateTime.Parse("1970-04-06 00:00:00"),
                    Street = "1600 Teresa Lane",
                    City = "Fort Meyers",
                    Zip = "33917",
                    State = "FL",
                    AdvantageNumber = 5005,
                    ActiveStatus = true,
                    Miles = 0
                },
                Password = "Anchorage",
                RoleName = "Customer"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the
                    //IdentityUser base class
                    UserName = "shdixon@utx.edu",
                    Email = "shdixon@utx.edu",
                    PhoneNumber = "2052643255",

                    // Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Shan",
                    LastName = "Dixon",
                    MiddleInitial = "D",
                    DateOfBirth = DateTime.Parse("1984-01-12 00:00:00"),
                    Street = "234 Holston Circle",
                    City = "Sheffield",
                    Zip = "35662",
                    State = "AL",
                    AdvantageNumber = 5006,
                    ActiveStatus = true,
                    Miles = 0
                },
                Password = "pepperoni",
                RoleName = "Customer"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the
                    //IdentityUser base class
                    UserName = "j.b.evans@aheca.org",
                    Email = "j.b.evans@aheca.org",
                    PhoneNumber = "5122565834",

                    // Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Jim Bob",
                    LastName = "Evans",
                    MiddleInitial = "nan",
                    DateOfBirth = DateTime.Parse("1959-09-09 00:00:00"),
                    Street = "506 Farrell Circle",
                    City = "Austin",
                    Zip = "78705",
                    State = "TX",
                    AdvantageNumber = 5007,
                    ActiveStatus = true,
                    Miles = 0
                },
                Password = "longhorns",
                RoleName = "Customer"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the
                    //IdentityUser base class
                    UserName = "feeley@longhorn.org",
                    Email = "feeley@longhorn.org",
                    PhoneNumber = "9152556749",

                    // Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Lou Ann",
                    LastName = "Feeley",
                    MiddleInitial = "K",
                    DateOfBirth = DateTime.Parse("2002-01-12 00:00:00"),
                    Street = "600 S 8th Street W",
                    City = "El Paso",
                    Zip = "79901",
                    State = "TX",
                    AdvantageNumber = 5008,
                    ActiveStatus = true,
                    Miles = 0
                },
                Password = "aggies",
                RoleName = "Customer"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the
                    //IdentityUser base class
                    UserName = "tfreeley@minnetonka.ci.us",
                    Email = "tfreeley@minnetonka.ci.us",
                    PhoneNumber = "6123255687",

                    // Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Tesa",
                    LastName = "Freeley",
                    MiddleInitial = "P",
                    DateOfBirth = DateTime.Parse("1991-02-04 00:00:00"),
                    Street = "4448 Fairview Ave.",
                    City = "Minnetonka",
                    Zip = "55343",
                    State = "MN",
                    AdvantageNumber = 5009,
                    ActiveStatus = true,
                    Miles = 0
                },
                Password = "raiders",
                RoleName = "Customer"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the
                    //IdentityUser base class
                    UserName = "mgarcia@gogle.com",
                    Email = "mgarcia@gogle.com",
                    PhoneNumber = "4696593544",

                    // Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Margaret",
                    LastName = "Garcia",
                    MiddleInitial = "L",
                    DateOfBirth = DateTime.Parse("1991-10-02 00:00:00"),
                    Street = "594 Longview",
                    City = "Dallas",
                    Zip = "75043",
                    State = "TX",
                    AdvantageNumber = 5010,
                    ActiveStatus = true,
                    Miles = 0
                },
                Password = "mustangs",
                RoleName = "Customer"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the
                    //IdentityUser base class
                    UserName = "chaley@thug.com",
                    Email = "chaley@thug.com",
                    PhoneNumber = "4698475583",

                    // Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Charles",
                    LastName = "Haley",
                    MiddleInitial = "E",
                    DateOfBirth = DateTime.Parse("1974-07-10 00:00:00"),
                    Street = "One Cowboy Pkwy",
                    City = "Dallas",
                    Zip = "75032",
                    State = "TX",
                    AdvantageNumber = 5011,
                    ActiveStatus = true,
                    Miles = 0
                },
                Password = "onetime",
                RoleName = "Customer"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the
                    //IdentityUser base class
                    UserName = "jeffh@sonic.com",
                    Email = "jeffh@sonic.com",
                    PhoneNumber = "4696978613",

                    // Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Jeffrey",
                    LastName = "Hampton",
                    MiddleInitial = "T.",
                    DateOfBirth = DateTime.Parse("2014-03-10 00:00:00"),
                    Street = "337 38th St.",
                    City = "Dallas",
                    Zip = "75209",
                    State = "TX",
                    AdvantageNumber = 5012,
                    ActiveStatus = true,
                    Miles = 0
                },
                Password = "hampton1",
                RoleName = "Customer"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the
                    //IdentityUser base class
                    UserName = "wjhearniii@umich.org",
                    Email = "wjhearniii@umich.org",
                    PhoneNumber = "2818965621",

                    // Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "John",
                    LastName = "Hearn",
                    MiddleInitial = "B",
                    DateOfBirth = DateTime.Parse("1950-08-05 00:00:00"),
                    Street = "4225 North First",
                    City = "Houston",
                    Zip = "77010",
                    State = "TX",
                    AdvantageNumber = 5013,
                    ActiveStatus = true,
                    Miles = 0
                },
                Password = "jhearn22",
                RoleName = "Customer"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the
                    //IdentityUser base class
                    UserName = "ahick@yaho.com",
                    Email = "ahick@yaho.com",
                    PhoneNumber = "2815788965",

                    // Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Anthony",
                    LastName = "Hicks",
                    MiddleInitial = "J",
                    DateOfBirth = DateTime.Parse("2005-12-08 00:00:00"),
                    Street = "32 NE Garden Ln., Ste 910",
                    City = "Houston",
                    Zip = "77012",
                    State = "TX",
                    AdvantageNumber = 5014,
                    ActiveStatus = true,
                    Miles = 0
                },
                Password = "hickhickup",
                RoleName = "Customer"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the
                    //IdentityUser base class
                    UserName = "ingram@jack.com",
                    Email = "ingram@jack.com",
                    PhoneNumber = "5124678821",

                    // Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Brad",
                    LastName = "Ingram",
                    MiddleInitial = "S.",
                    DateOfBirth = DateTime.Parse("2016-09-05 00:00:00"),
                    Street = "6548 La Posada Ct.",
                    City = "Austin",
                    Zip = "78613",
                    State = "TX",
                    AdvantageNumber = 5015,
                    ActiveStatus = true,
                    Miles = 0
                },
                Password = "ingram2015",
                RoleName = "Customer"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the
                    //IdentityUser base class
                    UserName = "toddj@yourmom.com",
                    Email = "toddj@yourmom.com",
                    PhoneNumber = "9154653365",

                    // Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Todd",
                    LastName = "Jacobs",
                    MiddleInitial = "L.",
                    DateOfBirth = DateTime.Parse("1999-01-20 00:00:00"),
                    Street = "4564 Elm St.",
                    City = "El Paso",
                    Zip = "79991",
                    State = "TX",
                    AdvantageNumber = 5016,
                    ActiveStatus = true,
                    Miles = 0
                },
                Password = "toddy25",
                RoleName = "Customer"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the
                    //IdentityUser base class
                    UserName = "thequeen@aska.net",
                    Email = "thequeen@aska.net",
                    PhoneNumber = "9159457399",

                    // Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Victoria",
                    LastName = "Lawrence",
                    MiddleInitial = "M.",
                    DateOfBirth = DateTime.Parse("2000-04-14 00:00:00"),
                    Street = "6639 Butterfly Ln.",
                    City = "El Paso",
                    Zip = "79930",
                    State = "TX",
                    AdvantageNumber = 5017,
                    ActiveStatus = true,
                    Miles = 0
                },
                Password = "something",
                RoleName = "Customer"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the
                    //IdentityUser base class
                    UserName = "linebacker@gogle.com",
                    Email = "linebacker@gogle.com",
                    PhoneNumber = "5122449976",

                    // Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Erik",
                    LastName = "Lineback",
                    MiddleInitial = "W",
                    DateOfBirth = DateTime.Parse("2013-12-02 00:00:00"),
                    Street = "1300 Netherland St",
                    City = "Austin",
                    Zip = "78613",
                    State = "TX",
                    AdvantageNumber = 5018,
                    ActiveStatus = true,
                    Miles = 0
                },
                Password = "Password1",
                RoleName = "Customer"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the
                    //IdentityUser base class
                    UserName = "elowe@netscare.net",
                    Email = "elowe@netscare.net",
                    PhoneNumber = "4695344627",

                    // Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Ernest",
                    LastName = "Lowe",
                    MiddleInitial = "S",
                    DateOfBirth = DateTime.Parse("1977-12-07 00:00:00"),
                    Street = "3201 Pine Drive",
                    City = "Dallas",
                    Zip = "75039",
                    State = "TX",
                    AdvantageNumber = 5019,
                    ActiveStatus = true,
                    Miles = 0
                },
                Password = "aclfest2017",
                RoleName = "Customer"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the
                    //IdentityUser base class
                    UserName = "cluce@gogle.com",
                    Email = "cluce@gogle.com",
                    PhoneNumber = "5126983548",

                    // Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Chuck",
                    LastName = "Luce",
                    MiddleInitial = "B",
                    DateOfBirth = DateTime.Parse("1949-03-16 00:00:00"),
                    Street = "2345 Rolling Clouds",
                    City = "Austin",
                    Zip = "78712",
                    State = "TX",
                    AdvantageNumber = 5020,
                    ActiveStatus = true,
                    Miles = 0
                },
                Password = "nothinggood",
                RoleName = "Customer"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the
                    //IdentityUser base class
                    UserName = "t.jacobs@longhornairlines.neet",
                    Email = "t.jacobs@longhornairlines.neet",
                    PhoneNumber = "4694653365",

                    // Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Todd",
                    LastName = "Jacobs",
                    MiddleInitial = "L",
                    Street = "4564 Elm St.",
                    City = "Dallas",
                    Zip = "75032",
                    State = "TX",
                    ActiveStatus = true
                },
                Password = "society",
                RoleName = "Agent"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the
                    //IdentityUser base class
                    UserName = "e.rice@longhornairlines.neet",
                    Email = "e.rice@longhornairlines.neet",
                    PhoneNumber = "4693876657",

                    // Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Eryn",
                    LastName = "Rice",
                    MiddleInitial = "M",
                    Street = "3405 Rio Grande",
                    City = "Dallas",
                    Zip = "75043",
                    State = "TX",
                    ActiveStatus = true
                },
                Password = "ricearoni",
                RoleName = "Manager"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the
                    //IdentityUser base class
                    UserName = "a.taylor@longhornairlines.neet",
                    Email = "a.taylor@longhornairlines.neet",
                    PhoneNumber = "4694748452",

                    // Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Allison",
                    LastName = "Taylor",
                    MiddleInitial = "R",
                    Street = "467 Nueces St.",
                    City = "Dallas",
                    Zip = "75206",
                    State = "TX",
                    ActiveStatus = true
                },
                Password = "nostalgic",
                RoleName = "Agent"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the
                    //IdentityUser base class
                    UserName = "m.sheffield@longhornairlines.neet",
                    Email = "m.sheffield@longhornairlines.neet",
                    PhoneNumber = "4695479167",

                    // Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Martin",
                    LastName = "Sheffield",
                    MiddleInitial = "J",
                    Street = "3886 Avenue A",
                    City = "Dallas",
                    Zip = "75032",
                    State = "TX",
                    ActiveStatus = true
                },
                Password = "longhorns",
                RoleName = "Agent"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the
                    //IdentityUser base class
                    UserName = "j.macleod@longhornairlines.neet",
                    Email = "j.macleod@longhornairlines.neet",
                    PhoneNumber = "2814748138",

                    // Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Jennifer",
                    LastName = "MacLeod",
                    MiddleInitial = "D",
                    Street = "2504 Far West Blvd.",
                    City = "Houston",
                    Zip = "77001",
                    State = "TX",
                    ActiveStatus = true
                },
                Password = "smitty",
                RoleName = "Agent"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the
                    //IdentityUser base class
                    UserName = "j.tanner@longhornairlines.neet",
                    Email = "j.tanner@longhornairlines.neet",
                    PhoneNumber = "5124590929",

                    // Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Jeremy",
                    LastName = "Tanner",
                    MiddleInitial = "S",
                    Street = "4347 Almstead",
                    City = "Austin",
                    Zip = "78705",
                    State = "TX",
                    ActiveStatus = true
                },
                Password = "tanman",
                RoleName = "Agent"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the
                    //IdentityUser base class
                    UserName = "e.stuart@longhornairlines.neet",
                    Email = "e.stuart@longhornairlines.neet",
                    PhoneNumber = "5128178335",

                    // Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Eric",
                    LastName = "Stuart",
                    MiddleInitial = "F",
                    Street = "5576 Toro Ring",
                    City = "Austin",
                    Zip = "78710",
                    State = "TX",
                    ActiveStatus = true
                },
                Password = "stewboy",
                RoleName = "Agent"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the
                    //IdentityUser base class
                    UserName = "c.miller@longhornairlines.neet",
                    Email = "c.miller@longhornairlines.neet",
                    PhoneNumber = "9157458615",

                    // Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Charles",
                    LastName = "Miller",
                    MiddleInitial = "R",
                    Street = "8962 Main St.",
                    City = "El Paso",
                    Zip = "79901",
                    State = "TX",
                    ActiveStatus = true
                },
                Password = "squirrel",
                RoleName = "Agent"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the
                    //IdentityUser base class
                    UserName = "r.taylor@longhornairlines.neet",
                    Email = "r.taylor@longhornairlines.neet",
                    PhoneNumber = "2814512631",

                    // Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Rachel",
                    LastName = "Taylor",
                    MiddleInitial = "O",
                    Street = "345 Longview Dr.",
                    City = "Houston",
                    Zip = "77002",
                    State = "TX",
                    ActiveStatus = true
                },
                Password = "swansong",
                RoleName = "Manager"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the
                    //IdentityUser base class
                    UserName = "v.lawrence@longhornairlines.neet",
                    Email = "v.lawrence@longhornairlines.neet",
                    PhoneNumber = "2819457399",

                    // Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Victoria",
                    LastName = "Lawrence",
                    MiddleInitial = "Y",
                    Street = "6639 Butterfly Ln.",
                    City = "Houston",
                    Zip = "77003",
                    State = "TX",
                    ActiveStatus = true
                },
                Password = "lottery",
                RoleName = "Agent"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the
                    //IdentityUser base class
                    UserName = "a.rogers@longhornairlines.neet",
                    Email = "a.rogers@longhornairlines.neet",
                    PhoneNumber = "4698752943",

                    // Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Allen",
                    LastName = "Rogers",
                    MiddleInitial = "H",
                    Street = "4965 Oak Hill",
                    City = "Dallas",
                    Zip = "75043",
                    State = "TX",
                    ActiveStatus = true
                },
                Password = "evanescent",
                RoleName = "Manager"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the
                    //IdentityUser base class
                    UserName = "e.markham@longhornairlines.neet",
                    Email = "e.markham@longhornairlines.neet",
                    PhoneNumber = "5124579845",

                    // Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Elizabeth",
                    LastName = "Markham",
                    MiddleInitial = "K",
                    Street = "7861 Chevy Chase",
                    City = "Austin",
                    Zip = "78712",
                    State = "TX",
                    ActiveStatus = true
                },
                Password = "monty3",
                RoleName = "Agent"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the
                    //IdentityUser base class
                    UserName = "s.saunders@longhornairlines.neet",
                    Email = "s.saunders@longhornairlines.neet",
                    PhoneNumber = "5123497810",

                    // Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Sarah",
                    LastName = "Saunders",
                    MiddleInitial = "M",
                    Street = "332 Avenue C",
                    City = "Austin",
                    Zip = "78613",
                    State = "TX",
                    ActiveStatus = true
                },
                Password = "rankmary",
                RoleName = "Agent"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the
                    //IdentityUser base class
                    UserName = "w.sewell@longhornairlines.neet",
                    Email = "w.sewell@longhornairlines.neet",
                    PhoneNumber = "5124510084",

                    // Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "William",
                    LastName = "Sewell",
                    MiddleInitial = "G",
                    Street = "2365 51st St.",
                    City = "Austin",
                    Zip = "78705",
                    State = "TX",
                    ActiveStatus = true
                },
                Password = "walkamile",
                RoleName = "Manager"
            });

            //create flag to help with errors
            String errorFlag = "Start";

            //create an identity result
            IdentityResult result = new IdentityResult();
            //call the method to seed the user
            try
            {
                foreach (AddUserModel aum in AllUsers)
                {
                    errorFlag = aum.User.Email;
                    // Took Utilities.AddUser from Relational Data Demo -> this is "Utilities/AddUser.cs"
                    result = await Utilities.AddUser.AddUserWithRoleAsync(aum, userManager, context);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("There was a problem adding the user with email: "
                    + errorFlag, ex);
            }

            return result;

        }
    }
}
