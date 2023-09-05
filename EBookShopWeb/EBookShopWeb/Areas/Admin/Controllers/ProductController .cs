

using DataAccess.Repository.IRepository;
using EBookShopWeb.DataAccess;
using EBookShopWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Models.Models;

namespace EBookShopWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var objProductList = _unitOfWork.Product.GetAll();
            return View(objProductList);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Product product)
        {
            //if (product.Name == product.DisplayOrder.ToString())
            //{
            //    ModelState.AddModelError("name", "Aynı değerde olamaz");
            //}
            if (ModelState.IsValid)
            {
                _unitOfWork.Product.Add(product);
                _unitOfWork.Save();
                TempData["success"] = "Ürün eklendi";
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
            var product = _unitOfWork.Product.Get(x => x.Id == id);
            if (product is null)
            {
                return NotFound();
            }
            return View(product);
        }
        [HttpPost]
        public IActionResult Edit(Product product)
        {
            //if (category.Name == category.DisplayOrder.ToString())
            //{
            //    ModelState.AddModelError("name", "Aynı değerde olamaz");
            //}
            if (ModelState.IsValid)
            {
                _unitOfWork.Product.Update(product);
                _unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View();
        }

        [ActionName("Delete")]
        public IActionResult DeletePost(int id)
        {
            var product = _unitOfWork.Product.Get(x => x.Id == id);
            if (ModelState.IsValid)
            {
                _unitOfWork.Product.Remove(product);
                _unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
