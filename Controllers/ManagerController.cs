using JanBatchCodeFirstApprochImpl.Data;
using JanBatchCodeFirstApprochImpl.Models;
using Microsoft.AspNetCore.Mvc;

namespace JanBatchCodeFirstApprochImpl.Controllers
{
    public class ManagerController : Controller
    {
        private readonly ApplicationDbContext db;
        public ManagerController(ApplicationDbContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            var data=db.manager.ToList();
            return View(data);
        }

        public IActionResult AddManager()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddManager(Managers m)
        {
            db.manager.Add(m);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
