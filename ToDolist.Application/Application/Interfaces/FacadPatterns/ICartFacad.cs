using Application.Services.TodoItem.Commands.AddToDoItem;
using Application.Services.TodoItem.Queries.GetPriority;
using Application.Services.TodoItem.Queries.GetStatus;
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
        IGetPriorityService GetPriorityService { get; }
        IGetStatusService GetStatusService { get; }
    }
}
