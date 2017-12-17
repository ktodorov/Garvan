using Garvan.Data.Interfaces;
using Garvan.Database.Contexts;
using Garvan.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garvan.Data.Services
{
    public class SubscribedUserService : ISubscribedUserService
    {
        public async Task AddSubscribedUserAsync(SubscribedUser subscribedUser)
        {
            using (var garvanContext = new GarvanContext())
            {
                await garvanContext.SubscribedUsers.AddAsync(subscribedUser);
                await garvanContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<SubscribedUser>> GetAllSubscribedUsersAsync()
        {
            var subscribedUsers = new List<SubscribedUser>();
            using (var garvanContext = new GarvanContext())
            {
                subscribedUsers = await garvanContext.SubscribedUsers.ToListAsync();
            }

            return subscribedUsers;
        }

        public async Task<SubscribedUser> GetSubscribedUserByEmail(string email)
        {
            using (var garvanContext = new GarvanContext())
            {
                var subscribedUser = await garvanContext.SubscribedUsers.FirstOrDefaultAsync(su => su.Email == email);
                return subscribedUser;
            }
        }
    }
}
