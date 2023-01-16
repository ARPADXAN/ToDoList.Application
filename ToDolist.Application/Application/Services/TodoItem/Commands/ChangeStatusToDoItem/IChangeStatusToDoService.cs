using Application.Interfaces.Context;
using Common.Dto;
using Domain.Entites.Cart;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static Application.Services.TodoItem.Commands.ChangeStatusToDoItem.ChangeStatusToDoService;

namespace Application.Services.TodoItem.Commands.ChangeStatusToDoItem
{
    public interface IChangeStatusToDoService
    {
        ResultDto Execute(RequestForChangeStatusto request);
    }
    public class ChangeStatusToDoService : IChangeStatusToDoService
    {
        private readonly IDataBaseContext DB;
        public ChangeStatusToDoService(IDataBaseContext dB)
        {
            DB = dB;
        }
        public ResultDto Execute(RequestForChangeStatusto request)
        {
            var cartforstatus = DB.StatusInCarts.FirstOrDefault(Q => Q.CartId == request.CartId);
            var cartforduecompelete = DB.Carts.Find(request.CartId);

            if (cartforstatus == null)
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "کارت مورد نظر یافت نشد"
                };
            }
            if (cartforduecompelete == null)
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "کارت مورد نظر یافت نشد"
                };
            }
            cartforstatus.StatusId = request.StatusId;
            cartforduecompelete.DueComplete = request.DueCompelete;
            cartforduecompelete.IsCompelete = request.IsCompelte;
            DB.SaveChanges();

            return new ResultDto
            {
                IsSuccess = true,
                Message = "",
            };

        }
        public class RequestForChangeStatusto
        {
            public long CartId { get; set; }
            public long StatusId { get; set; }
            public bool IsCompelte { get; set; }
            public DateTime? DueCompelete { get; set; }
        }
    }
}
