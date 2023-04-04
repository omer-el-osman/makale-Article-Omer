using makaledeneme1.Core;
using makaledeneme1.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace makaledeneme1.Controllers
{
    [Authorize("Admin")]
    public class CategoryController : Controller
    {
        private readonly IDataHelper<Category> dataHelper;
        private int PageItme;
        public CategoryController(IDataHelper<Category> dataHelper)
        {
            this.dataHelper = dataHelper;
            PageItme = 5;
        }
        // GET: CategoryController
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

        // GET: CategoryController/Details/5


        /// //Search icin//////////////////////////////////
        public ActionResult search(string searchItem)
        {
            if (searchItem == null)
            {
                return View("Index",dataHelper.getAllData()) ;

            }
            else
            {
                return View("Index",dataHelper.search(searchItem));

            }
        }




        // GET: CategoryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category collection)
        {
            try
            {
                var r = dataHelper.Add(collection);
                if (r == 1)
                {
                    return RedirectToAction(nameof(Index));

                }
                else
                {
                    return View();

                }
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoryController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(dataHelper.Find(id));
        }

        // POST: CategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Category collection)
        {
            try
            {

                var r = dataHelper.Edit(id,collection);
                if (r == 1)
                {
                    return RedirectToAction(nameof(Index));

                }
                else
                {
                    return View();

                }
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoryController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(dataHelper.Find(id));
        }

        // POST: CategoryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Category collection)
        {
            try
            {

                var r = dataHelper.delete(id);
                if (r == 1)
                {
                    return RedirectToAction(nameof(Index));

                }
                else
                {
                    return View();

                }
            }
            catch
            {
                return View();
            }
        }
    }
}
