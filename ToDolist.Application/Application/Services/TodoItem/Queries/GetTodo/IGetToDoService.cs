using Application.Interfaces.Context;
using Common.Dto;
using Microsoft.EntityFrameworkCore;

using tools.Common;

namespace Application.Services.TodoItem.Queries.GetTodo
{
    public interface IGetToDoService
    {
        ResultDto<ResultGetTodo> Excute(RequestuserDto requestuser);
  
    }
    
    public class GetToDoService : IGetToDoService
    {
        private readonly IDataBaseContext DB;
        public GetToDoService(IDataBaseContext dB)
        {
            DB = dB;
        }
        public ResultDto<ResultGetTodo> Excute(RequestuserDto requestuser)
        {
            int rowcount;
            var todo = DB.Carts.Include(p => p.PriorityInCarts).ThenInclude(x=>x.Priority)
                .Include(p => p.StatusInCarts).ThenInclude(x=>x.Status)
                .AsQueryable();
                
            if (!string.IsNullOrWhiteSpace(requestuser.serachkey))
            {
                todo = todo.Where(p => p.Title.Contains(requestuser.serachkey) &&
                p.Description.Contains(requestuser.serachkey));
                
            }
            var todolist = todo.ToPaged( requestuser.page, 20,out rowcount) ;

            return new ResultDto<ResultGetTodo>
            {
                Data = new ResultGetTodo
                {
                    Rows = rowcount,
                    GetToDoDtos = todolist.Select(p => new GetToDoDto
                    {
                        Id = p.Id,
                        Title = p.Title,
                        Description = p.Description,
                        Priority = p.PriorityInCarts.FirstOrDefault().Priority.Name,
                        PriorityId = p.PriorityInCarts.FirstOrDefault().Priority.Id,
                        StatusId=p.StatusInCarts.FirstOrDefault().Status.Id,
                        Status=p.StatusInCarts.FirstOrDefault().Status.Name,
                        NoficationData = p.NoficationDate,
                        NoficationTime = p.NoficationTime,

                    }).ToList(),
                },
                IsSuccess = true,

            };


        }
    }

    public class GetToDoDto
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public string Priority { get; set; }
        public long  PriorityId { get; set; }
        public long StatusId { get; set; }
        public string Status { get; set; }
        public string? NoficationData { get; set; }
        public string? NoficationTime { get; set; }
    }
    public class RequestuserDto
    {
        public string serachkey { get; set; }
        public int page { get; set; }
    }
    public class ResultGetTodo
    {
        public List<GetToDoDto> GetToDoDtos { get; set; }
        public int Rows { get; set; }
    }
}
