using EBookShopWeb.Data;
using EBookShopWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace EBookShopWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _dbcontext;
        public CategoryController(ApplicationDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        
        public IActionResult Index()
        {
            var objCategoryList= _dbcontext.Categories.ToList();
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
                _dbcontext.Categories.Add(category);
                _dbcontext.SaveChanges();
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
            var category = _dbcontext.Categories.Find(id);
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
                _dbcontext.Categories.Update(category);
                _dbcontext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        [ActionName("Delete")]
        public IActionResult DeletePost(int id)
        {
            var category = _dbcontext.Categories.Find(id);
            if (ModelState.IsValid)
            {
                _dbcontext.Categories.Remove(category);
                _dbcontext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
