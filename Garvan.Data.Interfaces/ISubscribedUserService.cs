using Garvan.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Garvan.Data.Interfaces
{
    public interface ISubscribedUserService
    {
        Task<IEnumerable<SubscribedUser>> GetAllSubscribedUsersAsync();

        Task<SubscribedUser> GetSubscribedUserByEmail(string email);

        Task AddSubscribedUserAsync(SubscribedUser subscribedUser);
    }
}
