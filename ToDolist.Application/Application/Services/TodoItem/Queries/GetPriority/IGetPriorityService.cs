using Application.Interfaces.Context;
using Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.TodoItem.Queries.GetPriority
{
    public interface IGetPriorityService
    {
        ResultDto<List<PriorityDto>> Execute();

    }
    public class GetPriorityService : IGetPriorityService
    {
        private readonly IDataBaseContext DB;
        public GetPriorityService(IDataBaseContext dB)
        {
            DB = dB;
        }

        public ResultDto<List<PriorityDto>> Execute()
        {
            var priority = DB.Priorities.ToList().Select(p => new PriorityDto
            {
                Id = p.Id,
                Name = p.Name,
            }).ToList();
            return new ResultDto<List<PriorityDto>>
            {
                Data = priority,
                IsSuccess = true,
            };
        }
    }

    public class PriorityDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
    }
}
