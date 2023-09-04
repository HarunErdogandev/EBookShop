

using DataAccess.Repository.IRepository;
using EBookShopWeb.DataAccess;
using EBookShopWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace EBookShopWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepo;
        public CategoryController(ICategoryRepository db)
        {
            _categoryRepo = db;
        }
        
        public IActionResult Index()
        {
            var objCategoryList = _categoryRepo.GetAll();
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
            if(ModelState.IsValid)
            {
                _categoryRepo.Add(category);
                _categoryRepo.Save();
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Edit(int id)
        {
            if (id==0 || id==null)
            {
                return NotFound();
            }
            var category = _categoryRepo.Get(x=>x.Id == id);
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
                _categoryRepo.Update(category);
                _categoryRepo.Save();
                return RedirectToAction("Index");
            }
            return View();
        }

        [ActionName("Delete")]
        public IActionResult DeletePost(int id)
        {
            var category = _categoryRepo.Get(x => x.Id == id);
            if (ModelState.IsValid)
            {
                _categoryRepo.Remove(category);
                _categoryRepo.Save();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
