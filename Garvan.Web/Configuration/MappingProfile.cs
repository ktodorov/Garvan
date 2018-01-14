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
            CreateMap<SubscribedUser, SubscribedUserDto>();
            CreateMap<SubscribedUserDto, SubscribedUser>();

            CreateMap<EmailToSend, EmailToSendDto>();
            CreateMap<EmailToSendDto, EmailToSend>();
        }
    }
}
