using Application.Interfaces.Context;
using Common.Dto;
using Domain.Entites.Cart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.TodoItem.Commands.RemoveToDoItem
{
    public interface IRemoveToDoItemService
    {
        ResultDto Execute(long Id);
    }
    public class RemoveToDoItemService : IRemoveToDoItemService
    {
        private readonly IDataBaseContext DB;
        public RemoveToDoItemService(IDataBaseContext dB)
        {
            DB = dB;
        }

        public ResultDto Execute(long Id)
        {
            var cart = DB.Carts.Find(Id);
            if (cart == null)
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "کارت مورد نظر یافت نشد"
                };
            }
           
            DB.Carts.Remove(cart);
            DB.SaveChanges();
            return new ResultDto
            {
                IsSuccess = true,
                Message = "حذف شد",

            };
        }
    }
}
