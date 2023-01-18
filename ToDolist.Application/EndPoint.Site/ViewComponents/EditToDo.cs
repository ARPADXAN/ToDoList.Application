using Application.Interfaces.FacadPatterns;
using Application.Services.TodoItem.Commands.AddToDoItem;
using Application.Services.TodoItem.Commands.EditTodoItem;
using EndPoint.Site.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EndPoint.Site.ViewComponents
{
    public class EditTodo:ViewComponent
    {
        private readonly ICartFacad CF;
        public EditTodo(ICartFacad cF)
        {
            CF = cF;
        }
        public IViewComponentResult Invoke()
        {
            return View(viewName: "EditToDo");
        }
    }
}
