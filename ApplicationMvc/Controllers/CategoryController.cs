using ApplicationMvc.Data;
using ApplicationMvc.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationMvc.Controllers
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
        //Get
        public IActionResult Create()
        {
             return View();
        }
        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        { 
            if(obj.Name == obj.SecondName)
            {
                ModelState.AddModelError("Name", "İsminiz ile Soyisminiz aynı olamaz");
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Mesajınız başarılı bir şekilde gönderildi";
                return RedirectToAction("Index");
            }
            return View(obj);
            
        }
    }
}
