using Application.Interfaces.FacadPatterns;
using Application.Services.TodoItem.Commands.AddToDoItem;
using Application.Services.TodoItem.Commands.EditTodoItem;
using Application.Services.TodoItem.Queries.GetTodo;
using Domain.Entites.Cart;
using EndPoint.Site.Models;
using EndPoint.Site.Models.RegisterViewModels;
using EndPoint.Site.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Drawing;

namespace EndPoint.Site.Controllers
{
   
    public class TodoController : Controller
    {
        private readonly ICartFacad CF;
        public TodoController(ICartFacad cF)
        {
            CF = cF;
        }
        #region Get ToDo
        public IActionResult Index(RequestuserDto requestuser)
        {
            var gettodo = CF.GetToDoService.Excute(requestuser).Data;
            return View(gettodo);
           
        }
        #endregion

       

        #region Create Todo
        [HttpGet]
        public IActionResult AddTodo()
        {
            ViewBag.priority = new SelectList(CF.GetPriorityService.Execute().Data, "Id", "Name");
            return View();
        }
        [HttpPost]
        public IActionResult AddTodo(AddViewModel request, IFormCollection form)
        {
            ViewData.ModelState.Values.Where(v => v.Errors.Count != 0).Count();

            if (!ModelState.IsValid)
            {
                return View(request);
            }
            if (request.HaveNofication == true)
            {

                var result = CF.AddToDoItemService.Excute(new RequestAddTodoitemDto
                {
                    Title = request.Title,
                    Description = request.Description,

                    _priorityInCarts = new List<priorityInCarts>
                    {
                        new priorityInCarts
                        {
                            Id=request.priorityId,
                        }
                    },
                    _statusInCarts = new List<statusInCarts>
                    {
                        new statusInCarts
                        {
                           Id=1,
                        }
                    },
                    HaveNofication = true,
                    NoficationDate = request.NoficationDate,
                    NoficationTime = request.NoficationTime,



                });
                return Json(result);
            }
            else
            {
                var result = CF.AddToDoItemService.Excute(new RequestAddTodoitemDto
                {
                    Title = request.Title,
                    Description = request.Title,
                    _priorityInCarts = new List<priorityInCarts>
                    {
                        new priorityInCarts
                        {
                            Id=request.priorityId,
                        }
                    },
                    _statusInCarts = new List<statusInCarts>
                    {
                        new statusInCarts
                        {
                            Id=1
                        },
                    },
                    HaveNofication = false
                });
                return Json(result);
            }
        }

        #endregion

        #region Edit Todo
        public IActionResult EditTodor(RequestUserForEditToDoService request)
        {
            var result = CF.EditToDoItemService.Execute(request);
            return Json(result);
        }
        #endregion





    }




}
