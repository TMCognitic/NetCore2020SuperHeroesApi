using Models.Api.Global.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Api.Interfaces
{
    public interface ISuperHeroesRepository
    {
        IEnumerable<SuperHero> Get(int userId);
        SuperHero Get(int id, int userId);
        void Insert(SuperHero superHero, int userId);
        void Update(int id, SuperHero superHero, int userId);
        void Delete(int id, int userId);
    }
}
