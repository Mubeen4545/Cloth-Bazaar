using ClothBazaar.Entities;
using ClothBazaar.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClothBazaar.Web.Controllers
{
    public class ProductController : Controller
    {
        ProductsService productsService = new ProductsService();
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ProductTable(string search) //yahn sari ki sari product len gy or phir un ko view py show krain gy.is k liye ek service ki be zaroort ha..
        {
            var products = productsService.GetProducts(); //sari ki sari products list mein a jain gi us ko view py bejon ga.
            if (string.IsNullOrEmpty(search)==false)
            {
                products = products.Where(p => p.Name != null && p.Name.ToLower().Contains(search.ToLower())).ToList();//ye chese ek loop ka kaam kr rehe ha..hr product to compare kr rehe ha.
            }
           
            
            return PartialView(products);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult Create(Product product)
        {
            productsService.SaveProduct(product);
            return RedirectToAction("ProductTable");
        }
        [HttpGet]
        public ActionResult Edit(int ID) // k is ID k against edit krna ha
        {
            var product = productsService.GetProduct(ID); // yahan hamry pass product a jay gi or wo product mein view py bej den gy.
            return PartialView(product);
        }
        [HttpPost]
        public ActionResult Edit(Product product)
        {
            productsService.UpdateProduct(product);
            return RedirectToAction("ProductTable");
        }
        [HttpPost]
        public ActionResult Delete(int ID)
        {
            productsService.DeleteProduct(ID);
            return RedirectToAction("ProductTable");
        }
    }
}