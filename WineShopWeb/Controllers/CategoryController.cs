using Microsoft.AspNetCore.Mvc;
using WineShop.DataAccess;
using WineShop.Models;

namespace WineShopWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Category> objCategoryList = _db.Categories;
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
                _db.Categories.Add(obj);
                _db.SaveChanges();
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
    var categoryFromDb = _db.Categories.Find(id);
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
        _db.Categories.Update(obj);
        _db.SaveChanges();
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
            var categoryFromDb = _db.Categories.Find(id);
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
            var obj = _db.Categories.Find(id); if (obj == null)
            {
                return NotFound();
            }
                _db.Categories.Remove(obj);
                _db.SaveChanges();
            TempData["success"] = "Category successfully deleted";

            return RedirectToAction("Index");
            }
    }
}