using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ToDoList.Buissnes;
using ToDoList.Buissnes.Interfaces;
using ToDoList.DomainModels;
using ToDoList.WebApi.Models.Api;
using System.Web.Http.Cors;


namespace ToDoList.WebApi.Controllers
{
    //[RoutePrefix("api/auth")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class AuthApiController : ApiController
    {
        private IAuthManager _authManager;
        private ISessionManager _sessionManager;


        public AuthApiController(IAuthManager authManager, ISessionManager sessionManager)
        {
            _authManager = authManager;
            _sessionManager = sessionManager;
        }


        [HttpPost]
        [Route("api/users")]
        [ResponseType(typeof(RegisterUserResponse))]
        public HttpResponseMessage Register(ToDoUser user)
        {
            RegisterUserResponse response = new RegisterUserResponse();

            //trying to add new user
            if (_authManager.AddUserToDb(user))
            {
                response.SessionId  = _sessionManager.CreateSession(user);
                return Request.CreateResponse(HttpStatusCode.Created, response);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.Conflict, response);
            }
        }


        [HttpPost]
        [Route("api/login")]
        [ResponseType(typeof(LoginUserResponse))]
        public HttpResponseMessage Login(LoginUserRequest request)
        {
            LoginUserResponse response = new LoginUserResponse();
            ToDoUser tempUser = new ToDoUser();

            tempUser.email = request.email;
            tempUser.Password = request.Password;

            //validating user
            if (_authManager.ValidateUser(tempUser))
            {
                tempUser = _authManager.GetUser(tempUser.email);
                response.SessionId = _sessionManager.CreateSession(tempUser);
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, response);
            }
        }


        [HttpPost]
        [Route("api/logout")]
        [ResponseType(typeof(LogoutUserResponse))]
        public HttpResponseMessage Logout(LogoutUserRequest request)
        {
            LogoutUserResponse response = new LogoutUserResponse();

            //deleting session
            _sessionManager.DeleteSession(request.SessionId);
            return Request.CreateResponse(HttpStatusCode.OK, response);

        }

    }
}
