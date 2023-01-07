using Application.Interfaces.Context;
using Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.TodoItem.Queries.GetStatus
{
    public interface IGetStatusService
    {
        ResultDto<List<StatusDto>> Execute();
    }
    public class GetStatusService : IGetStatusService
    {
        private readonly IDataBaseContext DB;

        public GetStatusService(IDataBaseContext dB)
        {
            DB = dB;
        }

        public ResultDto<List<StatusDto>> Execute()
        {
            var status = DB.Statuses.ToList().Select(p => new StatusDto
            {
                Id = p.Id,
                Name = p.Name,
            }).ToList();
            return new ResultDto<List<StatusDto>>
            {
                Data = status,
                IsSuccess = true,
            };
        }
        
        
    }

    public class StatusDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
    }
}
