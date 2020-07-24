using Models.Api.Global.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Models.Api.Global.Services.Extensions
{
    internal static class DataRecordExtensions
    {
        internal static User ToUser(this IDataRecord record)
        {
            return new User() { Id = (int)record["Id"], LastName = (string)record["LastName"], FirstName = (string)record["FirstName"], Email = (string)record["Email"], IsAdmin = (bool)record["IsAdmin"] };
        }

        internal static SuperHero ToSuperHero(this IDataRecord record)
        {
            return new SuperHero() { Id = (int)record["Id"], Name = (string)record["Name"], Strength = (int)record["Strength"], Stamina = (int)record["Stamina"], Intellect = (int)record["Intellect"], Charisma = (int)record["Charisma"] };
        }
    }
}
