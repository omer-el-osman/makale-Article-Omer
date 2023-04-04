using makaledeneme1.Core;
using makaledeneme1.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace makaledeneme1.Pages
{
    public class AllUsersModel : PageModel
    {
    
        private readonly IDataHelper<Core.Author> dataHelperOfPost;

        public AllUsersModel(
            makaledeneme1.Data.IDataHelper<makaledeneme1.Core.Author> dataHelperOfPost
            )
        {
            this.dataHelperOfPost = dataHelperOfPost;
        }

        //OnGet demki loading yaparken bu saydayi calisitr
        public void OnGet(string LoadState,string search,int id)
        {
         
            //bu form calisirken LoadState ve Category gondermemiz lazim
            if (LoadState == null || LoadState == "all")
            {
                GetallAuthor();
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
        public List<makaledeneme1.Core.Author> MyListOfAuthor{ get; set; }
        public void GetallAuthor()
        {
            MyListOfAuthor = dataHelperOfPost.getAllData().Take(6).ToList();
          
        }


        public void GetDataSearch(string SearchItem)
        {
            MyListOfAuthor = dataHelperOfPost.search(SearchItem);

        }

        public void GetNestDAta(int id)
        {
            MyListOfAuthor = dataHelperOfPost.getAllData().Where(x=>x.Id>id).Take(6).ToList();

        }
    }
}
