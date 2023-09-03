using EBookShopWeb.Data;
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
    }
}
