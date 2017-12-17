using AutoMapper;
using Garvan.Entities;
using Garvan.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Garvan.Web.Configuration
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap<SubscribedUser, SubscribedUserDto>();
            CreateMap<SubscribedUserDto, SubscribedUser>();
        }
    }
}
