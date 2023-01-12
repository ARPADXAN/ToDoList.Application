using Application.Services.TodoItem.Queries.GetPriority;
using Application.Services.TodoItem.Queries.GetStatus;
using Application.Services.TodoItem.Queries.GetTodo;

namespace EndPoint.Site.Models.ViewModels.HomePageViewModel
{
    public class HomepageViewModel
    {
       public List<GetToDoDto> TodoLister { get; set; } 
    }
}
