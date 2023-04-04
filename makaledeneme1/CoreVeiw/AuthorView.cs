using System.ComponentModel.DataAnnotations;

namespace makaledeneme1.CoreVeiw
{
    public class AuthorView
    {

        //من اجل اضافة الصورررر Author وAuthorView هذا الصنف يكون ك وسيط بين

        [Required]
        [Display(Name = "Id :")]
        public int Id { get; set; }
        [Required]
        [Display(Name = "UserId :")]
        //Onemliiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiii
        // ? isareti burada kullanmaiz gerekir cunku baze durum lar null olacak bu isaret null kabul eder demek 
        //bu hata icin sqlnullvalueexception: data is null. this method or property cannot be called on null values.
        public string UserId { get; set; }
        [Required]
        [Display(Name = "User Name :")]
        public string UserName { get; set; }
        [Required]
        [Display(Name = "Full Name :")]
        public string FullName { get; set; }

        [Display(Name = "Imge :")]
        public IFormFile ProtfileImgeUrl { get; set; }

        [Display(Name = "Bio :")]
        public string? Bio { get; set; }
        [Display(Name = "Facebook :")]
        public string? Facebook { get; set; }
        [Display(Name = "instagram :")]
        public string? instagram { get; set; }
        [Display(Name = "Twitter :")]
        public string? twitter { get; set; }
    }
}
