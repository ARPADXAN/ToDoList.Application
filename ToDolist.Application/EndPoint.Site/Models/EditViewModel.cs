using System.ComponentModel.DataAnnotations;

namespace EndPoint.Site.Models
{
    public class EditViewModel
    {

        public long CartId { get; set; }
        [Required(ErrorMessage = "مقدار {0} را وارد کنید ")]
        [Display(Name = "عنوان")]
        [MaxLength(100, ErrorMessage = " مقدار {0} نمی تواند بیشتر از {1} باشد  ")]
        public string? Title { get; set; }

        [Display(Name = " توضیحات")]
        [MaxLength(1200, ErrorMessage = " مقدار {0} نمی تواند بیشتر از {1} باشد  ")]
        public string? Description { get; set; }

        public bool HaveNofication { get; set; }
        [Display(Name = " تاریخ اعلان")]
        public string NoficationDate { get; set; }
        [Display(Name = " زمان اعلان")]
        public string NoficationTime { get; set; }


    }
}
