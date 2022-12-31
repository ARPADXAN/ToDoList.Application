using System.ComponentModel.DataAnnotations;

namespace EndPoint.Site.Models.ViewModels
{
    public class RegisterViewModels
    {
        [Required(ErrorMessage = "مقدار {0} را وارد کنید ")]
        [Display(Name = "نام")]
        [MaxLength(20, ErrorMessage = " مقدار {0} نمی تواند بیشتر از {1} باشد  ")]
        public string FirstName { get; set; }


        [Required(ErrorMessage = "مقدار {0} را وارد کنید ")]
        [Display(Name = "نام خانوادگی")]
        [MaxLength(40, ErrorMessage = " مقدار {0} نمی تواند بیشتر از {1} باشد  ")]
        public string LastName { get; set; }


        [Required(ErrorMessage = "مقدار {0} را وارد کنید ")]
        [Display(Name = "ایمیل")]
        [MinLength(6, ErrorMessage = " مقدار {0} نمی تواند کمتر از {1} باشد  ")]
        [EmailAddress(ErrorMessage = "فرمت ورودی {0} صحیح نیست ")]
        public string Email { get; set; }


        [Required(ErrorMessage = "مقدار {0} را وارد کنید ")]
        [Display(Name = "تلفن همراه")]
        [MaxLength(20, ErrorMessage = " مقدار {0} نمی تواند بیشتر از {1} باشد  ")]
        [Phone(ErrorMessage = "فرمت ورودی {0} صحیح نیست ")]
        public string Mobile { get; set; }


        [Required(ErrorMessage = "مقدار {0} را وارد کنید ")]
        [Display(Name = "کلمه عبور")]
        [MinLength(6,ErrorMessage = "مقدار {0} نمی تواند کمتر از {1} باشد")]
        [MaxLength(50, ErrorMessage = " مقدار {0} نمی تواند بیشتر از {1} باشد  ")]
        public string Password { get; set; }


        [Required(ErrorMessage = "مقدار {0} را وارد کنید ")]
        [Display(Name = "تکرار کلمه عبور")]
        [Compare("Password",ErrorMessage ="تکرار کلمه عبور صحیح نیست")]
        public string ConfirmPassword { get; set; }


    }
}
