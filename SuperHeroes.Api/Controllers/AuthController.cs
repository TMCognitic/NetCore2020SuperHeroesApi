using Models.Api.Global.Entities;
using Models.Api.Global.Services;
using Models.Api.Interfaces;
using SuperHeroes.Api.Infrastructure;
using SuperHeroes.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;
using System.Web.UI;
using Tools.Security.Token;

namespace SuperHeroes.Api.Controllers
{
    public class AuthController : ApiController
    {
        private readonly IAuthRepository _authRepository;
        private readonly ITokenService _tokenService;

        public AuthController()
        {
            _authRepository = ResourceLocator.Instance.AuthRepository;
            _tokenService = ResourceLocator.Instance.TokenService;
        }

        [HttpPost]
        [Route("api/auth/register")]
        public void Register([FromBody] User user)
        {
            _authRepository.Register(user);
        }

        [HttpPost]
        public HttpResponseMessage Login([FromBody] LoginInfo loginInfo)
        {
            if (!ModelState.IsValid)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            User user = _authRepository.Login(loginInfo.Email, loginInfo.Passwd);

            if(user is null)
                return Request.CreateResponse(HttpStatusCode.NoContent);

            user.Token = _tokenService.EncodeToken(user, (u) => u.ToClaims());
            return Request.CreateResponse(HttpStatusCode.OK, user);
        }
    }
}
