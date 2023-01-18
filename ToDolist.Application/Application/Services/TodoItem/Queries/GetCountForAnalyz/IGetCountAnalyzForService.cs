using Application.Interfaces.Context;
using Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.TodoItem.Queries.GetCountForAnalyz
{
    public interface IGetCountAnalyzForService
    {
        ResultDto<GetCountForAnalyzDto> Excute();

    }
    public class GetCountAnalyzForService : IGetCountAnalyzForService
    {
        private readonly IDataBaseContext DB;
        public GetCountAnalyzForService(IDataBaseContext db)
        {
            DB = db;
        }
        public ResultDto<GetCountForAnalyzDto> Excute()
        {
            var CountSuspend = DB.StatusInCarts.Count(p => p.StatusId == 1);
            var CountNoStart = DB.StatusInCarts.Count(p => p.StatusId == 2);
            var CountInProgress = DB.StatusInCarts.Count(p => p.StatusId == 3);
            var CountIsCompelet = DB.StatusInCarts.Count(p => p.StatusId ==4);
            var CountGeneral = DB.PriorityInCarts.Count(p => p.PriorityId == 1);
            var Counturgent = DB.PriorityInCarts.Count(p => p.PriorityId ==2);
            var CountCritical = DB.PriorityInCarts.Count(p => p.PriorityId == 3);


        

            return new ResultDto<GetCountForAnalyzDto>
            {
                Data =
                {
                    Suspend = CountSuspend,
                    NotStart = CountNoStart,
                    Inprogress = CountInProgress,
                    Complete = CountIsCompelet,
                    General = CountGeneral,
                    Urgent = Counturgent,
                    Critical = CountCritical,
                },
                IsSuccess = true,
                Message = "",
            };
        }
    }

    public class GetCountForAnalyzDto
    {
        public int? Suspend { get; set; }
        public int? NotStart { get; set; }
        public int? Inprogress { get; set; }
        public int? Complete { get; set; }
        public int? General { get; set; }
        public int? Urgent { get; set; }
        public int? Critical { get; set; }
    }
}
