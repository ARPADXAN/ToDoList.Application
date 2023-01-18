using Application.Services.TodoItem.Commands.EditTodoItem;

namespace EndPoint.Site.Services
{
    public interface TodoSevice
    {
        bool EditToDo(RequestUserForEditToDoService forEditToDoService);
    }
}
