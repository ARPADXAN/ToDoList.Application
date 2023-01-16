using Application.Interfaces.FacadPatterns;
using Application.Services.TodoItem.Commands.AddToDoItem;
using EndPoint.Site.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EndPoint.Site.ViewComponents
{
    public class AddTodo:ViewComponent
    {
        private readonly ICartFacad CF;
        public AddTodo(ICartFacad cF)
        {
            CF = cF;
        }
        public IViewComponentResult Invoke(RequestAddTodoitemDto request)
        {
            return View(viewName: "AddTodo");
        }
    }
}
