using AppcentNetCase.Models.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static AppcentNetCase.Application.UserOperations.CreateUserCommand;

namespace AppcentNetCase.Common
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {

            CreateMap<CreateUserModel, User>();
        }
    }
}
