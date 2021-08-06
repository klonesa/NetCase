using AppcentNetCase.Models.Entities;
using AppcentNetCase.Models.Repository;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppcentNetCase.Application.UserOperations
{
    public class CreateUserCommand
    {
        public CreateUserModel Model { get; set; }
        private readonly IdbContext _dbContext;
        private readonly IMapper _mapper;

        public CreateUserCommand(IdbContext dbContext,IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void Handle()
        {
            var user = _dbContext.Users.SingleOrDefault(x => x.Email == Model.Email);
            if (user is not null)
                throw new InvalidOperationException("Kullanıcı zaten mevcut");

            user = _mapper.Map<User>(Model);
            _dbContext.Users.Add(user);
            _dbContext.SaveChange();
        }

        public class CreateUserModel
        {
            public string Name { get; set; }
            public string SurName { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
        }
    }
}
