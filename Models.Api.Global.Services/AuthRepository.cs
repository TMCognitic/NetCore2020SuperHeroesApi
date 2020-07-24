using Models.Api.Global.Entities;
using Models.Api.Global.Services.Extensions;
using Models.Api.Interfaces;
using System;
using System.Data.SqlClient;
using System.Linq;
using Tools.Databases;

namespace Models.Api.Global.Services
{
    public class AuthRepository : IAuthRepository
    {
        public IConnection _connection;

        public AuthRepository(IConnection connection)
        {
            _connection = connection;
        }

        public User Login(string email, string passwd)
        {
            Command command = new Command("AppUser.CSP_Login", true);
            command.AddParameter("Email", email);
            command.AddParameter("Passwd", passwd);

            return _connection.ExecuteReader(command, dr => dr.ToUser()).SingleOrDefault();
        }

        public void Register(User user)
        {
            Command command = new Command("AppUser.CSP_Register", true);
            command.AddParameter("LastName", user.LastName);
            command.AddParameter("FirstName", user.FirstName);
            command.AddParameter("Email", user.Email);
            command.AddParameter("Passwd", user.Passwd);

            _connection.ExecuteNonQuery(command);
        }
    }
}
