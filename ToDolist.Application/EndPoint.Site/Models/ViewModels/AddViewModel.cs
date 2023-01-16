using Application.Services.TodoItem.Commands.AddToDoItem;
using System.ComponentModel.DataAnnotations;

namespace EndPoint.Site.Models.ViewModels
{
    public class AddViewModel
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
        public string? NoficationDate { get; set; }

        [Display(Name = " زمان اعلان")]
        public string? NoficationTime { get; set; }
        public bool IsCompelete { get; set; }
        public DateTime? DueComplete { get; set; }
        public List<priorityInCarts>? _priorityInCarts { get; set; }
        public List<statusInCarts>? _statusInCarts { get; set; }
        public long priorityId { get; set; }
        public  long statusId { get; set; }

    }
}
