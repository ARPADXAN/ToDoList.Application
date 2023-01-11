using Application.Interfaces.FacadPatterns;
using Application.Services.TodoItem.Commands.AddToDoItem;
using Domain.Entites.Cart;
using EndPoint.Site.Models.RegisterViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EndPoint.Site.Controllers
{
    public class TodoController : Controller
    {
        private readonly ICartFacad CF;
        public TodoController(ICartFacad cF)
        {
            CF = cF;
        }
        public IActionResult Index()
        {
            return View();
        }


        #region Create Todo
        [HttpGet]
        public IActionResult AddTodo()
        {
            ViewBag.priority = new SelectList(CF.GetPriorityService.Execute().Data, "Id", "Name");
            return View();
        }
        [HttpPost]
        public IActionResult AddTodo(RequestAddTodoitemDto request, long priorityId, long statusId, IFormCollection form)
        {
            ViewData.ModelState.Values.Where(v => v.Errors.Count != 0).Count();

            if (!ModelState.IsValid)
            {
                return View(request);
            }
            if (request.HaveNofication==true)
            {

                var result = CF.AddToDoItemService.Excute(new RequestAddTodoitemDto
                {
                    Title = request.Title,
                    Description = request.Description,

                    _priorityInCarts  = new List<priorityInCarts>
                    {
                        new priorityInCarts
                        {
                            Id=priorityId,
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
                            Id=priorityId,
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
        public  IActionResult Creat()
        {
            return View();

        }


    }




}
