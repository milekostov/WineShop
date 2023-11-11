using Microsoft.AspNetCore.Mvc;
using WineShop.DataAccess;
using WineShop.DataAccess.Repository.IRepository;
using WineShop.Models;


namespace WineShopWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PackagingTypeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public PackagingTypeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            IEnumerable<PackagingType> objPackagintTypeyList = _unitOfWork.PackagingType.GetAll();
            return View(objPackagintTypeyList);
        }

        // GET for Create action
        public IActionResult Create()
        {
            return View();
        }

        // Post for Create action
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(PackagingType obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.PackagingType.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Packaging type successfully created";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        // GET for Edit action
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var packagingTypeFromDb = _unitOfWork.PackagingType.GetFirstOrDefault(u => u.Id == id);
            if (packagingTypeFromDb == null)
            {
                return NotFound();
            }
            return View(packagingTypeFromDb);
        }

        // Post for Edit action
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(PackagingType obj)
        {
            
            if (ModelState.IsValid)
            {
                _unitOfWork.PackagingType.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Packaging type successfully edited";
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
            var packagingTypeFromDb = _unitOfWork.PackagingType.GetFirstOrDefault(u => u.Id == id);
            if (packagingTypeFromDb == null)
            {
                return NotFound();
            }
            return View(packagingTypeFromDb);
        }

        // Post for Delete action
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var obj = _unitOfWork.PackagingType.GetFirstOrDefault(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.PackagingType.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Packaging type successfully deleted";

            return RedirectToAction("Index");
        }
    }
}