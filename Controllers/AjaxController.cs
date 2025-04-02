using JanBatchCodeFirstApprochImpl.Data;
using JanBatchCodeFirstApprochImpl.Models;
using Microsoft.AspNetCore.Mvc;

namespace JanBatchCodeFirstApprochImpl.Controllers
{
    public class AjaxController : Controller
    {
        private readonly ApplicationDbContext db;
        public AjaxController(ApplicationDbContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddProduct(Product p)
        {
            db.products.Add(p);
            db.SaveChanges();
            return Json("");
        }

        public IActionResult FetchProducts()
        {
            var data=db.products.ToList();
            return Json(data);
        }

        public IActionResult DelProd(int pid)
        {
            var data=db.products.Find(pid);
            db.products.Remove(data);
            db.SaveChanges();
            return Json("");
        }

        public IActionResult EditProduct(int pid)
        {
            var data=db.products.Find(pid);
            return Json(data);
        }

        public IActionResult UpdateProduct(Product p)
        {
            db.products.Update(p);
            db.SaveChanges();
            return Json("");
        }

        public IActionResult TakeProducts(int mydata)
        {
            var data=db.products.Take(mydata).ToList();
            return Json(data);
        }

        public IActionResult SearchProducts(string mydata)
        {
            var data=db.products.Where(x => x.Pname.Contains(mydata) || x.Pcat.Contains(mydata) || x.Price.ToString().Contains(mydata)).ToList();
            
            if(mydata!=null)
            {
                return Json(data);
            }
            else
            {
                return Json(db.products.ToList());
            }


        }

    }
}
