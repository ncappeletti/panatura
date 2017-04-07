using System.Linq;
using Microsoft.AspNetCore.Mvc;
using panatura.Model.Entities;
using panatura.Model.Repositories;

namespace panatura.Controllers
{
    public class ProductsController : Controller
    {
        readonly IProductsRepository repository;

        public ProductsController(IProductsRepository productRepository)
        {
            this.repository = productRepository;
        }

        public IActionResult Index()
        {

            var algo = this.repository.FindAll().ToList();

            var newProduct = new Product();
            newProduct.Name = "Jabon";
            newProduct.Code = "J00001";
            this.repository.Save(newProduct);

            return View();
        }
    }
}