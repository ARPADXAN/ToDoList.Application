using Application.Services.TodoItem.Commands.AddToDoItem;
using Application.Services.TodoItem.Commands.ChangeStatusToDoItem;
using Application.Services.TodoItem.Commands.EditTodoItem;
using Application.Services.TodoItem.Commands.RemoveToDoItem;
using Application.Services.TodoItem.Queries.GetCountForAnalyz;
using Application.Services.TodoItem.Queries.GetPriority;
using Application.Services.TodoItem.Queries.GetStatus;
using Application.Services.TodoItem.Queries.GetTodo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.FacadPatterns
{
    public interface ICartFacad
    {
        AddToDoItemService AddToDoItemService { get; }
        ChangeStatusToDoService ChangeStatusToDoService { get; }
        EditToDoItemService EditToDoItemService { get; }
        RemoveToDoItemService RemoveToDoItemService { get; }
        IGetPriorityService GetPriorityService { get; }
        IGetStatusService GetStatusService { get; }
        IGetToDoService GetToDoService { get; }
        IGetCountAnalyzForService GetCountAnalyzForService { get; }

    }
}
