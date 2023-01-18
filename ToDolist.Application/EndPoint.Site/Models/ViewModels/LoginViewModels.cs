using System.ComponentModel.DataAnnotations;

namespace EndPoint.Site.Models.ViewModels
{
    public class LoginViewModels
    {

        [Display(Name = "ایمیل")]
        [MinLength(6, ErrorMessage = " مقدار {0} نمی تواند کمتر از {1} باشد  ")]
        [MaxLength(50, ErrorMessage = " مقدار {0} نمی تواند بیشتر از {1} باشد  ")]
        [DataType(DataType.EmailAddress)]
        public string? Email{ get; set; }

        [Required(ErrorMessage = "مقدار {0} را وارد کنید ")]
        [Display(Name = "تلفن همراه")]
        [MaxLength(50, ErrorMessage = " مقدار {0} نمی تواند بیشتر از {1} باشد  ")]
        [DataType(DataType.PhoneNumber)]
        public string Mobile { get; set; }

        [Required(ErrorMessage = "مقدار {0} را وارد کنید ")]
        [Display(Name = "تلفن همراه")]
        [MinLength(6, ErrorMessage = " مقدار {0} نمی تواند بیشتر از {1} باشد  ")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = " مرا به یاد آور")]
        public bool IsPerssitence { get; set; }
        public string? ReturnUrl { get; set; }
        public string? Meessage { get; set; }
    }
}
