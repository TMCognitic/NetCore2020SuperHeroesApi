using Models.Api.Global.Entities;
using Models.Api.Interfaces;
using SuperHeroes.Api.Infrastructure;
using SuperHeroes.Api.Models;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SuperHeroes.Api.Controllers
{
    [AuthRequired]
    public class HeroController : ApiController
    {
        ISuperHeroesRepository _superHeroesRepository;
        public HeroController()
        {
            _superHeroesRepository = ResourceLocator.Instance.SuperHeroesRepository;
        }

        // GET: api/Hero
        public IEnumerable<SuperHero> Get()
        {
            return _superHeroesRepository.Get(this.GetUserId());
        }

        // GET: api/Hero/5
        public SuperHero Get(int id)
        {
            return _superHeroesRepository.Get(id, this.GetUserId());
        }

        // POST: api/Hero
        public HttpResponseMessage Post([FromBody]HeroForm form)
        {
            if (!ModelState.IsValid)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            _superHeroesRepository.Insert(form.ToSuperHero(), this.GetUserId());

            return Request.CreateResponse(HttpStatusCode.NoContent);
        }

        // PUT: api/Hero/5
        public HttpResponseMessage Put(int id, [FromBody] HeroForm form)
        {
            if (!ModelState.IsValid)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            _superHeroesRepository.Update(id, form.ToSuperHero(), this.GetUserId());

            return Request.CreateResponse(HttpStatusCode.NoContent);
        }

        // DELETE: api/Hero/5
        public HttpResponseMessage Delete(int id)
        {
            _superHeroesRepository.Delete(id, this.GetUserId());
            return Request.CreateResponse(HttpStatusCode.NoContent);
        }
    }
}
