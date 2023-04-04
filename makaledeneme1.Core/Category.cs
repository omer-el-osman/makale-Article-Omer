using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace makaledeneme1.Core
{
    public class Category
    {
        [Required]
        [Display(Name ="Id : ")]
        public int Id { get; set; }

        [Required(ErrorMessage = "this Category of User is Required")]
        [Display(Name = "Category Name : ")]
        [MaxLength(25, ErrorMessage = "en yuksek 25 karekter"), MinLength(2, ErrorMessage = "en az 2 karekter")]
        [DataType(DataType.Text)]
        public string? Name { get; set; }

        //Navigation
        public virtual List<AuthorPost> authorPosts { get; set; }

    }
}
