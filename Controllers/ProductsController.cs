using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using panatura.Model;
using panatura.Model.Entities;

namespace panatura.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            using (var db = new PanaturaContext())
            {
                var newProduct = new Product();
                newProduct.Name = "Saumerio";
                newProduct.Code = "S00001";
                db.Products.Add(newProduct);
                db.SaveChanges();

                var products = db.Products.ToList();
            }


            return View();
        }
    }
}