using Models.Api.Global.Entities;
using Models.Api.Global.Services.Extensions;
using Models.Api.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using Tools.Databases;

namespace Models.Api.Global.Services
{
    public class SuperHeroesRepository : ISuperHeroesRepository
    {
        private IConnection _connection;

        public SuperHeroesRepository(IConnection connection)
        {
            _connection = connection;
        }

        public IEnumerable<SuperHero> Get(int userId)
        {
            Command command = new Command("Select Id, Name, Strength, Stamina, Intellect, Charisma From AppUser.V_Heroes Where UserId = @UserId;");
            command.AddParameter("UserId", userId);

            return _connection.ExecuteReader(command, dr => dr.ToSuperHero());
        }

        public SuperHero Get(int id, int userId)
        {
            Command command = new Command("Select Id, Name, Strength, Stamina, Intellect, Charisma From AppUser.V_Heroes Where Id = @Id And UserId = @UserId;");
            command.AddParameter("Id", id);
            command.AddParameter("UserId", userId);

            return _connection.ExecuteReader(command, dr => dr.ToSuperHero()).SingleOrDefault();
        }

        public void Insert(SuperHero superHero, int userId)
        {
            Command command = new Command("AppUser.CSP_AddHero", true);
            command.AddParameter("Name", superHero.Name);
            command.AddParameter("Strength", superHero.Strength);
            command.AddParameter("Stamina", superHero.Stamina);
            command.AddParameter("Intellect", superHero.Intellect);
            command.AddParameter("Charisma", superHero.Charisma);
            command.AddParameter("UserId", userId);

            _connection.ExecuteNonQuery(command);
        }

        public void Update(int id, SuperHero superHero, int userId)
        {
            Command command = new Command("AppUser.CSP_UpdateHero", true);            
            command.AddParameter("Id", id);
            command.AddParameter("Strength", superHero.Strength);
            command.AddParameter("Stamina", superHero.Stamina);
            command.AddParameter("Intellect", superHero.Intellect);
            command.AddParameter("Charisma", superHero.Charisma);
            command.AddParameter("UserId", userId);

            _connection.ExecuteNonQuery(command);
        }

        public void Delete(int id, int userId)
        {
            Command command = new Command("AppUser.CSP_DeleteHero", true);
            command.AddParameter("Id", id);
            command.AddParameter("UserId", userId);

            _connection.ExecuteNonQuery(command);
        }
    }
}
