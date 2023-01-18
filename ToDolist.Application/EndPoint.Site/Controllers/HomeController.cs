using Application.Interfaces.FacadPatterns;
using Application.Services.TodoItem.Commands.AddToDoItem;
using Application.Services.TodoItem.Queries.GetTodo;
using Azure.Core;
using Domain.Entites.Cart;
using EndPoint.Site.Models;
using EndPoint.Site.Models.ViewModels.HomePageViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Persistence.DataBaseContext;
using System.Diagnostics;
using static Application.Services.TodoItem.Commands.ChangeStatusToDoItem.ChangeStatusToDoService;

namespace EndPoint.Site.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICartFacad CF;
        public HomeController(ILogger<HomeController> logger, ICartFacad cF)
        {
            CF = cF;
            _logger = logger;
        }


        #region get Todo

        public IActionResult Index()
        {

            return View();
        }
        [HttpGet]
        public IActionResult index(RequestuserDto requestuser)
        {
            ViewBag.Priority = new SelectList(CF.GetPriorityService.Execute().Data, "Id", "Name");



            var gettodo = CF.GetToDoService.Excute(requestuser).Data;


            return View(gettodo);
        }
        #endregion

        [HttpPost("change-state-item/{elementId:int}/{stateId}"), Route("change-state-item/{elementId:int}/{stateId}")]
        public bool ChangeStateItem([FromRoute] long elementId, [FromRoute] string stateId)
        {
            if (stateId == "no_status")
            {
                var result = CF.ChangeStatusToDoService.Execute(new RequestForChangeStatusto
                {
                    CartId = elementId,
                    StatusId = 1,
                    IsCompelte = false,
                    DueCompelete = null,
                });
            }
            if (stateId == "status_notstart")
            {
                var result = CF.ChangeStatusToDoService.Execute(new RequestForChangeStatusto
                {
                    CartId = elementId,
                    StatusId = 2,
                    IsCompelte = false,
                    DueCompelete = null,
                });
            }
            if (stateId == "status_inprogress")
            {
                var result = CF.ChangeStatusToDoService.Execute(new RequestForChangeStatusto
                {
                    CartId = elementId,
                    StatusId = 3,
                    IsCompelte = false,
                    DueCompelete = null
                });
            }
            if (stateId == "status_compelete")
            {
                var result = CF.ChangeStatusToDoService.Execute(new RequestForChangeStatusto
                {
                    CartId = elementId,
                    StatusId = 4,
                    IsCompelte = true,
                    DueCompelete = DateTime.Now,
                });
            }



            return true;
        }

        #region Add cart 
        [HttpGet]
        public IActionResult AddToDo()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddToDo(string Title, string? Description, bool haveNofication, string? NoficationDate, string? NoficationTime, long priorityId, long StatusId, IFormCollection form)
        {
            if (!ModelState.IsValid)
            {

                return View();
            }

            if (haveNofication == true)
            {
                var result = CF.AddToDoItemService.Excute(new RequestAddTodoitemDto
                {
                    Title = Title,
                    Description = Description,
                    _priorityInCarts = new List<priorityInCarts>
                {
                    new priorityInCarts
                    {
                        Id=priorityId
                   },
                },
                    _statusInCarts = new List<statusInCarts>
                {
                    new statusInCarts {Id=1}
                },
                    HaveNofication = true,
                    NoficationDate = NoficationDate,
                    NoficationTime = NoficationTime,
                });
                return Json(result);
            }
            else
            {
                var result = CF.AddToDoItemService.Excute(new RequestAddTodoitemDto
                {
                    Title = Title,
                    Description = Description,
                    _priorityInCarts = new List<priorityInCarts>
                {
                    new priorityInCarts
                    {
                        Id=priorityId
                    },
                },
                    _statusInCarts = new List<statusInCarts>
                {
                    new statusInCarts
                    {
                        Id=1,
                    }
                },
                    HaveNofication = false,

                });
                return Json(result);

            }

        }
        #endregion



        #region Change Status
        public IActionResult ChangeStatus(RequestForChangeStatusto request)
        {
            var result = CF.ChangeStatusToDoService.Execute(request);
            return Json(request);
        }
        #endregion


        #region Delete Todo
        [Route("RemoveCart")]
        public IActionResult RemoveCart(long CartId)
        {
             var result= CF.RemoveToDoItemService.Execute(CartId);
            return Json(result);
        }
     
        #endregion

        #region Other
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        #endregion


    }
}