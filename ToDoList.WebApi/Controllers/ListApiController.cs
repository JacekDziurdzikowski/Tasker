using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ToDoList.Buissnes.Interfaces;
using ToDoList.DomainModels;
using ToDoList.WebApi.Models.Api.list;
using System.Web.Http.Cors;

namespace ToDoList.WebApi.Controllers
{
    [RoutePrefix("api/todolists")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ListApiController : ApiController
    {
        private IListManager _listManager;
        private ITaskManager _taskManager;
        private ISessionManager _sessionManager;



        public ListApiController(IListManager listManager, ISessionManager sessionManager, ITaskManager taskManager)
        {
            _listManager = listManager;
            _sessionManager = sessionManager;
            _taskManager = taskManager;
        }

        [HttpPost]
        [Route()]
        [ResponseType(typeof(CreateListResponse))]
        public HttpResponseMessage CreateList (CreateListRequest request)
        {
            var response = new CreateListResponse();
            var tempList = new ToDoList.DomainModels.ToDoList();
            int tempUserId = _sessionManager.GetSession(request.SessionId).User.ToDoUserId;
            tempList.ListName = request.ListName;
            tempList.UserId = tempUserId;

            if (_sessionManager.IsActive(request.SessionId))
            {
                _listManager.AddListToDatabase(tempList);
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.Conflict, response);
            }


        }


        [HttpPut]
        [Route("{id}")]
        [ResponseType(typeof(UpdateListResponse))]
        public HttpResponseMessage UpdateList (UpdateListRequest request, int id)
        {
            var response = new UpdateListResponse();

            if (_sessionManager.IsActive(request.SessionId))
            {
                _listManager.AddListToDatabase(request.List);
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.Conflict, response);
            }
        }



        [HttpDelete]
        [Route("{id}")]
        [ResponseType(typeof(DeleteListResponse))]
        public HttpResponseMessage DeleteList (DeleteListRequest request, int id)
        {
            var response = new DeleteListResponse();

            if (_sessionManager.IsActive(request.SessionId))
            {
                _listManager.DeleteList(id);
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.Conflict, response);
            }
        }


        [HttpGet]
        [Route()]
        [ResponseType(typeof(GetListsResponse))]
        public HttpResponseMessage GetLists(int sessionId)
        {
            var response = new GetListsResponse();

            if (_sessionManager.IsActive(sessionId))
            {
                response.Lists = _listManager.GetLists(sessionId);
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.Conflict, response);
            }
        }


        [HttpGet]
        [Route("{id}")]
        [ResponseType(typeof(GetListResponse))]
        public HttpResponseMessage GetList(int sessionId, int id)
        {
            var response = new GetListResponse();

            if (_sessionManager.IsActive(sessionId))
            {
                response.Tasks = _taskManager.GetTasks(id);

                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.Unauthorized, response);
            }
        }


        [HttpPost]
        [Route("{todolistid}/tasks")]
        [ResponseType(typeof(CreateTaskResponse))]
        public HttpResponseMessage CreateTask(CreateTaskRequest request, int todolistid)
        {
            var response = new CreateTaskResponse();

            if (_sessionManager.IsActive(request.SessionId))
            {
                _taskManager.AddTaskToDatabase(request.Task);
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.Conflict, response);
            }
        }


        [HttpPut]
        [Route("{todolistid}/tasks/{taskid}")]
        [ResponseType(typeof(UpdateTaskResponse))]
        public HttpResponseMessage UpdateTask(UpdateTaskRequest request, int todolistid, int taskid)
        {
            var response = new UpdateTaskResponse();

            if (_sessionManager.IsActive(request.SessionId))
            {
                _taskManager.AddTaskToDatabase(request.Task);
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.Conflict, response);
            }
        }


        [HttpDelete]
        [Route("{todolistid}/tasks/{taskid}")]
        [ResponseType(typeof(DeleteTaskResponse))]
        public HttpResponseMessage DeleteTask(DeleteTaskRequest request, int todolistid, int taskid)
        {
            var response = new DeleteTaskResponse();

            if (_sessionManager.IsActive(request.SessionId))
            {
                _taskManager.DeleteTask(taskid);
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.Conflict, response);
            }
        }

        [HttpGet]
        [Route("{todolistid}/tasks/{taskid}")]
        [ResponseType(typeof(GetTaskResponse))]
        public HttpResponseMessage GetTask(GetTaskRequest request, int todolistid, int taskid)
        {
            var response = new GetTaskResponse();

            if (_sessionManager.IsActive(request.SessionId))
            {
                response.Task = _taskManager.GetTask(taskid);
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.Conflict, response);
            }
        }


        //[HttpOptions]
        //[Route("{id}")]
        //public HttpResponseMessage OptionsRequest(int id)
        //{

        //    return Request.CreateResponse(HttpStatusCode.OK);

        //}
    }
}
