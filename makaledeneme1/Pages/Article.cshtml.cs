using makaledeneme1.Core;
using makaledeneme1.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace makaledeneme1.Pages
{
    public class ArticleModel : PageModel
    {
        private readonly IDataHelper<AuthorPost> dataHelperOfPost;
        public AuthorPost AuthorPost;
        public ArticleModel(makaledeneme1.Data.IDataHelper<makaledeneme1.Core.AuthorPost> dataHelperOfPost)
        {
            this.dataHelperOfPost = dataHelperOfPost;
        }

        public void OnGet()
        {

            var id = HttpContext.Request.RouteValues["id"];
            AuthorPost = dataHelperOfPost.Find(Convert.ToInt32(id));



        }
    }
}
