using Application.Interfaces.Context;
using Common.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.TodoItem.Commands.EditTodoItem
{
    public interface IEditToDoItemService
    {
        ResultDto Execute(RequestUserForEditToDoService request);
    }
    public class EditToDoItemService : IEditToDoItemService
    {
        private readonly IDataBaseContext DB;
        public EditToDoItemService(IDataBaseContext dB)
        {
            DB = dB;
        }

        public ResultDto Execute(RequestUserForEditToDoService request)
        {
            var cart = DB.Carts.Find(request.CartId);
            if (cart == null)
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "کارت مورد نظرت یافت نشد"
                };
            }
            cart.Title = request.Title;
            cart.Description = request.Description;
            DB.SaveChanges();
            return new ResultDto
            {
                IsSuccess = true,
                Message = "کارت مورد نظرت با موفقیت ویرایش شد"
            };
        }
    }

    public class RequestUserForEditToDoService
    {
        public long CartId { get; set; }
        [Required(ErrorMessage = "مقدار {0} را وارد کنید ")]
        [Display(Name = "عنوان")]
        [MaxLength(100, ErrorMessage = " مقدار {0} نمی تواند بیشتر از {1} باشد  ")]
        public string? Title { get; set; }
        [Display(Name = " توضیحات")]
        [MaxLength(1200, ErrorMessage = " مقدار {0} نمی تواند بیشتر از {1} باشد  ")]
        public string? Description { get; set; }

      
    }
}
