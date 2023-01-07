using Application.Interfaces.Context;
using Common.Dto;
using Domain.Entites.Cart;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.TodoItem.Commands.AddToDoItem
{
    public interface IAddToDoItemService
    {
        ResultDto<ResultAddCartDto> Excute(RequestAddTodoitemDto request);
    }
    public class AddToDoItemService : IAddToDoItemService
    {
        private readonly IDataBaseContext DB;
        public AddToDoItemService(IDataBaseContext db)
        {
            DB = db;
        }
        public ResultDto<ResultAddCartDto> Excute(RequestAddTodoitemDto request)
        {
            Cart cart = new Cart()
            {
                Title = request.Title,
                Description = request.Description,
                HaveNofication = request.HaveNofication,
                NoficationTime = request.NoficationTime,
                NoficationDate = request.NoficationDate,
            };
            List<PriorityInCarts> prioritylist = new List<PriorityInCarts>();
            foreach (var item in request._priorityInCarts)
            {
                var findPriority = DB.Priorities.Find(item.Id);
                prioritylist.Add(new PriorityInCarts
                {
                    Priority = findPriority,
                    PriorityId = findPriority.Id,
                    Cart = cart,
                    CartId = cart.Id,
                });
            };
            List<StatusInCarts> statuslist = new List<StatusInCarts>();
            foreach (var item in request._statusInCarts)
            {
                var findStatus = DB.Statuses.Find(item.Id);
                statuslist.Add(new StatusInCarts
                {
                    Status = findStatus,
                    StatusId = findStatus.Id,
                    Cart = cart,
                    CartId = cart.Id,

                });
            }
            cart.PriorityInCarts = prioritylist;
            cart.StatusInCarts = statuslist;
            DB.Carts.Add(cart);
            DB.SaveChanges();

            #region Savechange true
            var AddCart = DB.SaveChanges();
            if (AddCart > 0)
            {
                return new ResultDto<ResultAddCartDto>()
                {
                    Data = new ResultAddCartDto
                    {
                        CartId = cart.Id,
                    },
                    IsSuccess = true,
                    Message = "ثبت وظیفه شما انجام شد امیدوار به موفقیت آن هستیم"
                };

            }
            #endregion

            #region save change false
            return new ResultDto<ResultAddCartDto>()
            {
                Data = new ResultAddCartDto
                {
                    CartId = 0,
                },
                IsSuccess = false,
                Message = "ثبت وظیفه شما با موفقیت انجام نشد"
            };

            #endregion


        }
    }

    public class RequestAddTodoitemDto
    {
        [Required(ErrorMessage = "مقدار {0} را وارد کنید ")]
        [Display(Name = "عنوان")]
        [MaxLength(100, ErrorMessage = " مقدار {0} نمی تواند بیشتر از {1} باشد  ")]
        public string Title { get; set; }

        [Display(Name = " توضیحات")]
        [MaxLength(1200, ErrorMessage = " مقدار {0} نمی تواند بیشتر از {1} باشد  ")]
        public string Description { get; set; }

        public bool HaveNofication { get; set; }

        [Display(Name = " تاریخ اعلان")]
        public DateTime? NoficationDate { get; set; }

        [Display(Name = " زمان اعلان")]
        public DateTime? NoficationTime { get; set; }
        public bool IsCompelete { get; set; }
        public DateTime? DueComplete { get; set; }
        public int PriorityInCartsId { get; set; }
        public int StatusInCartsId { get; set; }
        public List<priorityInCarts> _priorityInCarts { get; set; }
        public List<statusInCarts> _statusInCarts { get; set; }

    }
    public class priorityInCarts
    {
        public long Id { get; set; }
    }
    public class statusInCarts
    {
        public long Id { get; set; }

    }
    public class ResultAddCartDto
    {
        public long CartId { get; set; }
    }
}
