using Microsoft.AspNetCore.Mvc;
using WineShop.DataAccess;
using WineShop.DataAccess.Repository.IRepository;
using WineShop.Models;

namespace WineShopWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _db;
        public CategoryController(ICategoryRepository db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Category> objCategoryList = _db.GetAll();
            return View(objCategoryList);
        }

        // GET for Create action
        public IActionResult Create()
        {
            return View();
        }

        // Post for Create action
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "Order cannot be the same as the name");
            }
            if (ModelState.IsValid)
            {
                _db.Add(obj);
                _db.Save();
                TempData["success"] = "Category successfully created";
                return RedirectToAction("Index");
            }
            return View(obj);
        }
   
// GET for Edit action
public IActionResult Edit(int? id)
{
    if (id == null||id == 0) 
            {
                return NotFound();
            }
    var categoryFromDb = _db.GetFirstOrDefault(u=>u.Id==id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }
    return View(categoryFromDb);
}

// Post for Edit action
[HttpPost]
[ValidateAntiForgeryToken]
public IActionResult Edit(Category obj)
{
    if (obj.Name == obj.DisplayOrder.ToString())
    {
        ModelState.AddModelError("name", "Order cannot be the same as the name");
    }
    if (ModelState.IsValid)
    {
        _db.Update(obj);
        _db.Save();
        TempData["success"] = "Category successfully edited";
                return RedirectToAction("Index");
    }
    return View(obj);
}

        // GET for Delete action
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var categoryFromDb = _db.GetFirstOrDefault(u=>u.Id ==id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }

        // Post for Delete action
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var obj = _db.GetFirstOrDefault(u=>u.Id==id);
            if (obj == null)
            {
                return NotFound();
            }
                _db.Remove(obj);
                _db.Save();
            TempData["success"] = "Category successfully deleted";

            return RedirectToAction("Index");
            }
    }
}