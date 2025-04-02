using JanBatchCodeFirstApprochImpl.Models;
using JanBatchCodeFirstApprochImpl.Repository;
using Microsoft.AspNetCore.Mvc;

namespace JanBatchCodeFirstApprochImpl.Controllers
{
    public class ProductController : Controller
    {
        IProduct prod;
        public ProductController(IProduct prod)
        {
            this.prod = prod;
        }
        public IActionResult Index()
        {
            var data=prod.FetchProducts();
            return View(data);
        }

        [HttpPost]
        public IActionResult Index(string srch)
        {
            if(srch==null)
            {
                var data = prod.FetchProducts();
                return View(data);
            }
            else
            {
                var data = prod.searchProduct(srch);
                return View(data);
            }
        }

        public IActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddProduct(Product p)
        {
            prod.AddProduct(p);
            return RedirectToAction("Index");
        }

        public IActionResult DelProd(int id)
        {
            prod.DeleteProduct(id);
            return RedirectToAction("Index");
        }
    }
}
