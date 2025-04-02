using JanBatchCodeFirstApprochImpl.Data;
using JanBatchCodeFirstApprochImpl.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace JanBatchCodeFirstApprochImpl.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext db;
        private readonly IWebHostEnvironment env;
        public EmployeeController(ApplicationDbContext db,IWebHostEnvironment env)
        {
            this.db = db;
            this.env = env;
        }

        public IActionResult Index()
        {
            var data = db.employee.Include(x => x.mng).ToList();
            
            return View(data);
            
            
        }

        public IActionResult AddEmp()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddEmp(EmpView e)
        {
            if(ModelState.IsValid)
            {
                string path = env.WebRootPath;
                string filepath = "Content/Images/" + e.eimg.FileName;
                string fullpath = Path.Combine(path, filepath);
                UploadFile(e.eimg,fullpath);
                var em = new Emp()
                {
                    ename=e.ename,
                    email=e.email,
                    esalary=e.esalary,
                    eimg=filepath
                };

                db.emps.Add(em);
                db.SaveChanges();
                TempData["success"] = "Emp Added Successfully!!";
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
            
        }

        public void UploadFile(IFormFile file,string path)
        {
            FileStream stream = new FileStream(path,FileMode.Create);
            file.CopyTo(stream);
        }

        public IActionResult DeleteEmp(int id)
        {
            //var d = db.emps.Where(x => x.eid==id).SingleOrDefault();
            var data=db.emps.Find(id);
            if(data!=null)
            {
                db.emps.Remove(data);
                db.SaveChanges();
                TempData["error"] = "Emp Deleted Successfully!!";
                return RedirectToAction("Index");
            }
            else
            {
                return NotFound();
            }
        }

        public IActionResult EditEmp(int id)
        {
            var data=db.emps.Find(id);
            return View(data);
        }

        [HttpPost]
        public IActionResult EditEmp(Emp e,IFormFile eimg)
        {
            Emp em;
            if(eimg==null)
            {
                var img=db.emps.Where(x => x.eid.Equals(e.eid)).Select(x => x.eimg).SingleOrDefault();
                em = new Emp()
                {
                    eid=e.eid,
                    ename = e.ename,
                    email = e.email,
                    esalary = e.esalary,
                    eimg = img
                };
            }
            else
            {
                string path = env.WebRootPath;
                string filepath = "Content/Images/" + eimg.FileName;
                string fullpath = Path.Combine(path, filepath);
                UploadFile(eimg, fullpath);
                em = new Emp()
                {
                    eid=e.eid,
                    ename = e.ename,
                    email = e.email,
                    esalary = e.esalary,
                    eimg = filepath
                };
            }
            db.emps.Update(em);
            db.SaveChanges();
            TempData["upd"] = "Emp Updated Successfully!!";
            return RedirectToAction("Index");
        }


        public IActionResult AddEmployee()
        {
            ViewBag.managers = new SelectList(db.manager,"Mid","Mname");
            return View();
        }

        [HttpPost]
        public IActionResult AddEmployee(Employees e)
        {
            db.employee.Add(e);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
