using Microsoft.AspNetCore.Identity;
using Group5_LonghornAirlines_FinalProject.DAL;
using Group5_LonghornAirlines_FinalProject.Models;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Group5_LonghornAirlines_FinalProject.Utilities
{
    public static class GenerateNextAdvantageNumber
    {
        public static async Task<Int32> GetNextAdvantageNumber(AppDbContext _context, UserManager<AppUser> userManager)
        {
            const Int32 START_NUMBER = 5000;
            Int32 intMaxAdvNumber;

            // Retrieve all user IDs from the database
            var userIds = _context.Users.Select(u => u.Id).ToList();

            // Use UserManager to check roles for each user
            var customerUserIds = new List<string>();
            foreach (var userId in userIds)
            {
                var user = await userManager.FindByIdAsync(userId);
                if (await userManager.IsInRoleAsync(user, "Customer"))
                {
                    customerUserIds.Add(userId);
                }
            }

            // Fetch only the users that are customers
            var customerUsers = _context.Users
                .Where(u => customerUserIds.Contains(u.Id))
                .ToList();

            if (customerUsers.Count == 0)
            {
                intMaxAdvNumber = START_NUMBER;
            }
            else
            {
                intMaxAdvNumber = customerUsers.Max(u => u.AdvantageNumber ?? START_NUMBER);
            }

            if (intMaxAdvNumber < START_NUMBER)
            {
                intMaxAdvNumber = START_NUMBER;
            }

            return intMaxAdvNumber + 1;
        }
    }
}
