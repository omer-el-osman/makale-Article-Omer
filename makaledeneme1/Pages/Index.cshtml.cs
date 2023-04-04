using makaledeneme1.Core;
using makaledeneme1.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace makaledeneme1.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IDataHelper<Core.Category> dataHelperOfCategory;
        private readonly IDataHelper<AuthorPost> dataHelperOfPost;

        public IndexModel(
            makaledeneme1.Data.IDataHelper<makaledeneme1.Core.Category> dataHelperOfCategory,
            makaledeneme1.Data.IDataHelper<makaledeneme1.Core.AuthorPost> dataHelperOfPost,
            ILogger<IndexModel> logger

            )
        {
            this.dataHelperOfCategory = dataHelperOfCategory;
            this.dataHelperOfPost = dataHelperOfPost;
            _logger = logger;
        }

        //OnGet demki loading yaparken bu saydayi calisitr
        public void OnGet(string LoadState, string CategoryName,string search,int id)
        {
            GetAllCoategory();
            //bu form calisirken LoadState ve Category gondermemiz lazim
            if (LoadState == null || LoadState == "all")
            {
                GetallPosts();
            }
            else if (LoadState == "ByCategory")
            {
                GetDataByCategory(CategoryName);
            }
            else if (LoadState == "Search")
            {
                GetDataSearch(search);
            }
            else if (LoadState == "Next")
            {
                GetNestDAta(id);
            }
            else if (LoadState == "Prev")
            {
                GetNestDAta(id-6);
            }

        }
        public List<makaledeneme1.Core.AuthorPost> MyListOfallPosts { get; set; }
        public void GetallPosts()
        {
            MyListOfallPosts = dataHelperOfPost.getAllData();
          
        }



        public List<makaledeneme1.Core.Category> MyListOfallCotegory { get; set; }
        public void GetAllCoategory()
        {
            MyListOfallCotegory = dataHelperOfCategory.getAllData();
          
        }


        public void GetDataByCategory(string CategoryName)
        {
            MyListOfallPosts= dataHelperOfPost.getAllData().Where(x => x.PostCategory == CategoryName).Take(6).ToList();
          
        }

        public void GetDataSearch(string SearchItem)
        {
            MyListOfallPosts = dataHelperOfPost.search(SearchItem);

        }

        public void GetNestDAta(int id)
        {
            MyListOfallPosts = dataHelperOfPost.getAllData().Where(x=>x.Id>id).Take(6).ToList();

        }

    }
}