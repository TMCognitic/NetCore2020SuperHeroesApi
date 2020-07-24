using Models.Api.Global.Entities;
using SuperHeroes.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Claims;
using System.Web;
using System.Web.Http;
using System.Web.UI;

namespace SuperHeroes.Api.Infrastructure
{
    internal static class Extensions
    {
        internal static IEnumerable<Claim> ToClaims(this User user)
        {
            yield return new Claim("Id", user.Id.ToString());
            yield return new Claim("LastName", user.LastName);            
            yield return new Claim("FirstName", user.FirstName);            
            yield return new Claim("Email", user.Email);            
            yield return new Claim("IsAdmin", user.IsAdmin.ToString());
        }

        internal static int GetUserId(this ApiController controller)
        {
            if (controller.GetType().GetCustomAttribute<AuthRequiredAttribute>() is null)
                throw new InvalidOperationException("For use the 'GetUserId' method, the controller must be have the 'AuthRequired' attribute!");

            return (int)controller.RequestContext.RouteData.Values["UserId"];
        }

        internal static SuperHero ToSuperHero(this HeroForm form)
        {            
            return new SuperHero() { Name = form.Name, Strength = form.Strength, Stamina = form.Stamina, Intellect = form.Intellect, Charisma = form.Charisma };
        }
    }
}