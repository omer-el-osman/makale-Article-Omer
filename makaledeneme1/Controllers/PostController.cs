using makaledeneme1.Core;
using makaledeneme1.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using makaledeneme1.CoreVeiw;
//
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace makaledeneme1.Controllers
{
    [Authorize]
    public class PostController : Controller
    {
        private readonly IDataHelper<AuthorPost> dataHelper;
        private readonly IDataHelper<Author> dataHelperForAuthor;
        private readonly IDataHelper<Category> dataHelperForCotegory;
        private readonly IWebHostEnvironment webHost;
        private readonly IAuthorizationService authorizationService;
        private Task<AuthorizationResult> result;
        private readonly Code.FilesHelper filesHelper;
       

        private int PageItme;
        public string UserId { get; private set; }

        public PostController(
            IDataHelper<AuthorPost> dataHelper,
            IDataHelper<Author> dataHelperForAuthor,
            IDataHelper<Category> dataHelperForCotegory,
            IWebHostEnvironment webHost,
            IAuthorizationService authorizationService
            )
        {
            PageItme = 5;
            this.filesHelper = new Code.FilesHelper(webHost);//burada bir hata cikti ise bu hatanin cozumu FileHelper classinde ikinci constracter yapmamiz gerekir

            this.dataHelper = dataHelper;
            this.dataHelperForAuthor = dataHelperForAuthor;
            this.dataHelperForCotegory = dataHelperForCotegory;
            this.webHost = webHost;
            this.authorizationService = authorizationService;
          
        }
        // GET: PostController
        public ActionResult Index(int? id)
        {


            SetUser();
            if (result.Result.Succeeded)
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
            else
            {
                if (id == 0 || id == null)
                {
                    //take birinci elemanleri almak icin burada ilk 5 eleman aldik
                    return View(dataHelper.getDataByUser(UserId).Take(PageItme));

                }
                else
                {
                    var data = dataHelper.getDataByUser(UserId).Where(x => x.Id > id).Take(PageItme);
                    return View(data);

                }
            }
          
        }




        public ActionResult search(string searchItem)
        {
            SetUser();
            if (result.Result.Succeeded)
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
            else
            {
                if (searchItem == null)
                {
                    return View("Index", dataHelper.getDataByUser(UserId));

                }
                else
                {
                    return View("Index", dataHelper.search(searchItem).Where(x=>x.UserId==UserId).ToList());

                }
            }
           
        }





        // GET: PostController/Details/5
        public ActionResult Details(int id)
        {
            SetUser();
            return View(dataHelper.Find(id));
        }

        // GET: PostController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PostController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CoreVeiw.AuthorPostVeiw collection)
        {
            SetUser();
            try
            {
                var Post = new AuthorPost
                {
                    UserId = UserId,//
                    FullName = dataHelperForAuthor.getAllData().Where(x => x.UserId == UserId).Select(x => x.FullName).First(),
                    UserName  = dataHelperForAuthor.getAllData().Where(x => x.UserId == UserId).Select(x => x.UserName).First(),

                    PostCategory = collection.PostCategory,
                    PostDescriptoin = collection.PostDescriptoin,
                    PostTitle = collection.PostTitle,
                    AddedDAte = collection.AddedDAte,
                    category = collection.category,
                    author = collection.author,

                    CategoryId = dataHelperForCotegory.getAllData().Where(x => x.Name == collection.PostCategory).Select(x => x.Id).First(),
                    AuthorId = dataHelperForAuthor.getAllData().Where(x=>x.UserId==UserId).Select(x=>x.Id).First(),
                    PostImgeUrl = filesHelper.UploadFile(collection.PostImgeUrl, "wwwroot\\imges")

                };
                dataHelper.Add(Post);
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                return View();
            }
        }

        // GET: PostController/Edit/5
        public ActionResult Edit(int id)
        {
            var authopost = dataHelper.Find(id);
            CoreVeiw.AuthorPostVeiw authorPostVeiw = new CoreVeiw.AuthorPostVeiw
            {
                UserId = UserId,
                FullName = authopost.FullName,
                UserName = authopost.UserName,

                PostCategory = authopost.PostCategory,
                PostDescriptoin = authopost.PostDescriptoin,
                PostTitle = authopost.PostTitle,
                AddedDAte = authopost.AddedDAte,
                category = authopost.category,
                author = authopost.author,

                CategoryId = authopost.CategoryId,
                AuthorId = authopost.AuthorId,
                Id = id
            };
            return View(authorPostVeiw);
        }

        // POST: PostController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CoreVeiw.AuthorPostVeiw collection)
        {
            SetUser();
            try
            {
                var Post = new AuthorPost
                {
                    Id = id,
                    UserId = UserId,
                    FullName = dataHelperForAuthor.getAllData().Where(x => x.UserId == UserId).Select(x => x.FullName).First(),
                    UserName = dataHelperForAuthor.getAllData().Where(x => x.UserId == UserId).Select(x => x.UserName).First(),

                    PostCategory = collection.PostCategory,
                    PostDescriptoin = collection.PostDescriptoin,
                    PostTitle = collection.PostTitle,
                    AddedDAte = collection.AddedDAte,
                    category = collection.category,
                    author = collection.author,

                    CategoryId = dataHelperForCotegory.getAllData().Where(x => x.Name == collection.PostCategory).Select(x => x.Id).First(),
                    AuthorId = dataHelperForAuthor.getAllData().Where(x => x.UserId == UserId).Select(x => x.Id).First(),
                    PostImgeUrl = filesHelper.UploadFile(collection.PostImgeUrl, "wwwroot\\imges"),
                   
                };
                dataHelper.Edit(id,Post);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PostController/Delete/5
        public ActionResult Delete(int id)
        {
            var authopost = dataHelper.Find(id);
          

            return View(authopost);
        }

        // POST: PostController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, AuthorPost collection)
        {
            try
            {
                dataHelper.delete(id);
                var filePath = "~/imges/" + collection.PostImgeUrl;
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

        private void SetUser()
        {
            result = authorizationService.AuthorizeAsync(User, "Admin");
            ////// UserId getirmek icin
            UserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
        }
    }
}
