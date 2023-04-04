using makaledeneme1.Core;
using makaledeneme1.CoreVeiw;
using makaledeneme1.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
//onemliiiiiii
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;

namespace makaledeneme1.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IDataHelper<Author> dataHelper;
        private readonly IWebHostEnvironment webHost;
        private readonly IAuthorizationService authorizationService;
        private readonly Code.FilesHelper filesHelper;
        private int PageItme;
        public AuthorController(IDataHelper<Author> dataHelper,
            IWebHostEnvironment webHost,
            IAuthorizationService authorizationService
            )
        {
            this.dataHelper = dataHelper;
            this.webHost = webHost;
            this.authorizationService = authorizationService;
            this.filesHelper = new Code.FilesHelper(this.webHost);//burada bir hata cikti ise bu hatanin cozumu FileHelper classinde ikinci constracter yapmamiz gerekir
            PageItme = 5;
        }

        [Authorize("Admin")]

        // GET: AuthorController
        public ActionResult Index(int? id)
        {
            if (id == 0 || id == null)
            {
                //take birinci elemanleri almak icin burada ilk 5 eleman aldik
                return View(dataHelper.getAllData().Take(PageItme));

            }
            else
            {
                var data = dataHelper.getAllData().Where(x => x.Id > id).Take(PageItme);
                return View(data);

            }
        }
        ///oneliiiiiiiiiiiiiiiiiiiii <summary>
        /// detaylis kismi ve create kismi silecegiz 
        /// cunku create register yaparken create gerceklestiriyor ama register den fullname da alacagiz
        /// 
        [Authorize("Admin")]

        public ActionResult search(string searchItem)
        {
            if (searchItem == null)
            {
                return View("Index", dataHelper.getAllData());

            }
            else
            {
                return View("Index", dataHelper.search(searchItem));

            }
        }
        [Authorize]

        // GET: AuthorController/Edit/5
        public ActionResult Edit(int id)
        {
            var Author = dataHelper.Find(id);
            AuthorView authorView = new AuthorView
            {
                Id = Author.Id,
                UserId = Author.UserId,
                FullName = Author.FullName,
                Bio = Author.Bio,
                Facebook = Author.Facebook,
                instagram = Author.instagram,
                twitter = Author.twitter,
                UserName = Author.UserName,
               
            };
            return View(authorView);
        }

        // POST: AuthorController/Edit/5

        /// Onemliiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiii
        /// Http Calistirmak icin Edit.csHtlm de form de enctype Calistirmamiz gerekir 
     
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]

        public ActionResult Edit(int id, AuthorView collection)
        {
            try
            {
                var Author = new Author
                {
                    Id = collection.Id,
                    UserId = collection.UserId,
                    FullName = collection.FullName,
                    Bio = collection.Bio,
                    Facebook = collection.Facebook,
                    instagram = collection.instagram,
                    twitter = collection.twitter,
                    UserName = collection.UserName,
                    ProtfileImgeUrl = filesHelper.UploadFile(collection.ProtfileImgeUrl, "wwwroot\\imges")
                };
                 var r= dataHelper.Edit(id, Author);
                if (r == 1)
                {
                    var result = authorizationService.AuthorizeAsync(User, "Admin");
                    if (result.Result.Succeeded)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        return RedirectToAction("/AdminIndex");
                    }
                   

                }
                else
                {
                    return View();

                }
            }
            //"Could not find a part of the path 'C:\\Users\\hosse\\Source\\Repos\\makaledeneme1\\makaledeneme1\\imges\\ 165155.png'."}
            catch (Exception ex)
            {
                return View();
            }
        }
        [Authorize("Admin")]

        // GET: AuthorController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AuthorController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize("Admin")]

        public ActionResult Delete(int id, Author collection)
        {
            try
            {
                dataHelper.delete(id);
                var filePath = "~/imges/" + collection.ProtfileImgeUrl;
                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
