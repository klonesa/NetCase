using AppcentNetCase.Models.Repository;
using AppcentNetCase.TokenOperation;
using AppcentNetCase.TokenOperation.Model;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AppcentNetCase.Application.UserOperations
{
    public class CreateTokenCommand
    {
        public CreateTokenModel Model { get; set; }
        private readonly IdbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public CreateTokenCommand(IdbContext dbContext, IMapper mapper, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _configuration = configuration;
        }

        public Token Handle()
        {
            var user = _dbContext.Users.SingleOrDefault(x => x.Email == Model.Email && x.Password == Model.Password);
            if (user is not null)
            {
                TokenHandler handler = new TokenHandler(_configuration);
                Token token = handler.CreateAccessToken(user);

                user.RefreshToken = token.RefreshToken;
                user.RefreshTokenExpireDate = token.Expiration.AddMinutes(5);
                _dbContext.SaveChange();
                return token;
            }
            else
                //throw new InvalidOperationException("Kullanıcı Adı - Şifre Hatalı");
                return null;
        }

        public class CreateTokenModel
        {
            [Required]
            public string Email { get; set; }
            [Required]
            public string Password { get; set; }

        }
    }
}
