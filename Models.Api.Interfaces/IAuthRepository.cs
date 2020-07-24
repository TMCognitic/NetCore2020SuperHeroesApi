using Models.Api.Global.Entities;
using System;

namespace Models.Api.Interfaces
{
    public interface IAuthRepository
    {
        User Login(string email, string passwd);
        void Register(User user);
    }
}
