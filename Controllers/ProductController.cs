using ECommerceProjBusiness.Repositories;
using ECommerceProjData.Context;
using ECommerceProjEntities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IntegratedTemplateMVCProject.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly AppDbContext db;
        public ProductController(IProductRepository productRepository, AppDbContext appDb)
        {
            _productRepository = productRepository;
            db = appDb;
        }

        public IActionResult Index()
        {
            //var products = _productRepository.GetProducts();
            var products = db.Products.Include(x=>x.ProductImages).AsEnumerable();
            return View(nameof(Index),products);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Name,StartPrice,Price,Rate,ProductImages")] Product product)
        {
            _productRepository.Add(product);
            return RedirectToAction(nameof(Index));
        }


        [ValidateAntiForgeryToken]
        public IActionResult Edit() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id,[Bind("Name,StartPrice,Price,Rate,ProductImages")] Product product)
        {
            if (id != product.Id) return NotFound();

            _productRepository.Update(product);
            return View();
        }

        public IActionResult Delete(int id)
        {
            _productRepository.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int id)
        {
            var result = _productRepository.GetById(id);

            if (result == null) return NotFound();
            return View(result);
        }
    }
}
