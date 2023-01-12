using Application.Interfaces.Context;
using Application.Interfaces.FacadPatterns;
using Application.Services.TodoItem.Commands.AddToDoItem;
using Application.Services.TodoItem.Queries.GetPriority;
using Application.Services.TodoItem.Queries.GetStatus;
using Application.Services.TodoItem.Queries.GetTodo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.TodoItem.FacadPattern
{
    public class CartFacad : ICartFacad
    {
        private readonly IDataBaseContext DB;
        public CartFacad(IDataBaseContext dB)
        {
            DB = dB;
        }

        #region AddToDoItem
        private AddToDoItemService addToDoItemService;
        public AddToDoItemService AddToDoItemService
        {
            get
            {
                return addToDoItemService = addToDoItemService ?? new AddToDoItemService(DB);
            }
        }
        #endregion


        #region GetPriority
        private IGetPriorityService getPriorityService;
        public IGetPriorityService GetPriorityService
        {
            get
            {
                return getPriorityService = getPriorityService ?? new GetPriorityService(DB);
            }
        }
        #endregion


        #region Get status
        private IGetStatusService getStatusService;
        public IGetStatusService GetStatusService
        {
            get
            {
                return getStatusService = getStatusService ?? new GetStatusService(DB);
            }
        }

        #endregion

        #region Get ToDo
        private IGetToDoService getToDoService;
        public IGetToDoService GetToDoService
        {
            get
            {
                return getToDoService = getToDoService ?? new GetToDoService(DB);
            }
        }

        #endregion

    }
}
