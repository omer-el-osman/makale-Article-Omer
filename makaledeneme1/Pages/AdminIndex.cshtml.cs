using makaledeneme1.Core;
using makaledeneme1.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Mail;
using System.Security.Claims;

namespace makaledeneme1.Pages
{

    [Authorize]//sadece gisir yapan
    public class AdminIndexModel : PageModel
    {
        public AdminIndexModel(makaledeneme1.Data.IDataHelper<makaledeneme1.Core.AuthorPost> dataHelper)
        {
            DataHelper = dataHelper;
        }
        public int AllPost { get; set; }
        public int PostLastMonth { get; set; }
        public int PostThisYear { get; set; }
        public IDataHelper<AuthorPost> DataHelper { get; }

        public void OnGet()
        {
            var dateM = DateTime.Now.AddMonths(-1);
            var dateY = DateTime.Now.AddYears(-1);

            var Userid = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            AllPost = DataHelper.getDataByUser(Userid).Count();
            PostLastMonth = DataHelper.getDataByUser(Userid).Where(x => x.AddedDAte >= dateM).Count();
            PostThisYear = DataHelper.getDataByUser(Userid).Where(x => x.AddedDAte >= dateY).Count();



        }
    }
}
