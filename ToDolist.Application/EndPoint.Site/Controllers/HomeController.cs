using Application.Interfaces.FacadPatterns;
using Application.Services.TodoItem.Commands.AddToDoItem;
using EndPoint.Site.Models;
using EndPoint.Site.Models.ViewModels.HomePageViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

namespace EndPoint.Site.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICartFacad CF;
        public HomeController(ILogger<HomeController> logger, ICartFacad cF)
        {
            CF = cF;
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewBag.Priority = new SelectList(CF.GetPriorityService.Execute().Data, "Id", "Name");
       
            return View();
        }
        #region Add cart 
        [HttpGet]
        public IActionResult AddToDo()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddToDo(string Title,string Description,bool haveNofication,DateTime NoficationDate,DateTime NoficationTime , long priorityId, long StatusId, IFormCollection form)
        {
            if (!ModelState.IsValid)
            {
                
                return View();
            }
            
            if (haveNofication==true)
            {
                var result = CF.AddToDoItemService.Excute(new RequestAddTodoitemDto
                {
                    Title =Title,
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
                        Id=3,
                    }                 
                },
                    HaveNofication = false,
                  
                });
                return Json(result);

            }

        }
        #endregion

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}