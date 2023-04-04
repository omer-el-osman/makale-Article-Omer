using System.ComponentModel.DataAnnotations;
using makaledeneme1.Core;

namespace makaledeneme1.CoreVeiw
{
    public class AuthorPostVeiw
    {
        //[Required(ErrorMessage = "this is required")]
        [Display(Name = "Id :")]
        public int Id { get; set; }
        [Display(Name = "UserId :")]
        //Onemliiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiii
        // ? isareti burada kullanmaiz gerekir cunku baze durum lar null olacak bu isaret null kabul eder demek 
        //bu hata icin sqlnullvalueexception: data is null. this method or property cannot be called on null values.
        public string? UserId { get; set; }
        [Display(Name = "User Name :")]
        public string? UserName { get; set; }
        [Display(Name = "Full Name :")]
        public string? FullName { get; set; }




        [Required(ErrorMessage = "this is required")]
        [Display(Name = "Category :")]
        [DataType(DataType.Text)]
        public string? PostCategory { get; set; } = "dersleri";

        [Required(ErrorMessage = "this is required")]
        [Display(Name = "Title :")]
        [DataType(DataType.Text)]
        public string? PostTitle { get; set; }

        [Required(ErrorMessage = "this is required")]
        [Display(Name = "Descriptoin :")]
        [DataType(DataType.MultilineText)]
        public string? PostDescriptoin { get; set; }

        [Required(ErrorMessage = "this is required")]
        [Display(Name = "Imge :")]
        [DataType(DataType.Upload)]
        public IFormFile PostImgeUrl { get; set; }

        /// <summary>
        /// ///////////////////////////////////////////////////////////////////////////////////////////
        /// </summary>
      

        [Display(Name = "Date :")]
        public DateTime AddedDAte { get; set; } = DateTime.Now;


        //Navigation Area
        public int AuthorId { get; set; }
        public Author author { get; set; }

        public int CategoryId { get; set; }
        public Category category { get; set; }
    }
}
