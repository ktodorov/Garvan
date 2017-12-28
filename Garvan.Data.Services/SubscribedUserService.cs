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
        public readonly GarvanContext _garvanContext;

        public SubscribedUserService(GarvanContext garvanContext)
        {
            _garvanContext = garvanContext;
        }

        public async Task AddSubscribedUserAsync(SubscribedUser subscribedUser)
        {
            await _garvanContext.SubscribedUsers.AddAsync(subscribedUser);
            await _garvanContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<SubscribedUser>> GetAllSubscribedUsersAsync()
        {
            var subscribedUsers = new List<SubscribedUser>();
            subscribedUsers = await _garvanContext.SubscribedUsers.ToListAsync();

            return subscribedUsers;
        }

        public async Task<SubscribedUser> GetSubscribedUserByEmail(string email)
        {
            var subscribedUser = await _garvanContext.SubscribedUsers.FirstOrDefaultAsync(su => su.Email == email);
            return subscribedUser;
        }
    }
}
