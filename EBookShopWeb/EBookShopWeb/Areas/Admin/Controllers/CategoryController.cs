

using DataAccess.Repository.IRepository;
using EBookShopWeb.DataAccess;
using EBookShopWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace EBookShopWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var objCategoryList = _unitOfWork.Category.GetAll();
            return View(objCategoryList);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category category)
        {
            if (category.Name == category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "Aynı değerde olamaz");
            }
            if (ModelState.IsValid)
            {
                _unitOfWork.Category.Add(category);
                _unitOfWork.Save();
                TempData["success"] = "Kategori eklendi";
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Edit(int id)
        {
            if (id == 0 || id == null)
            {
                return NotFound();
            }
            var category = _unitOfWork.Category.Get(x => x.Id == id);
            if (category is null)
            {
                return NotFound();
            }
            return View(category);
        }
        [HttpPost]
        public IActionResult Edit(Category category)
        {
            if (category.Name == category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "Aynı değerde olamaz");
            }
            if (ModelState.IsValid)
            {
                _unitOfWork.Category.Update(category);
                _unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View();
        }

        [ActionName("Delete")]
        public IActionResult DeletePost(int id)
        {
            var category = _unitOfWork.Category.Get(x => x.Id == id);
            if (ModelState.IsValid)
            {
                _unitOfWork.Category.Remove(category);
                _unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
