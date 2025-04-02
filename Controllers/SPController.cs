using JanBatchCodeFirstApprochImpl.Data;
using JanBatchCodeFirstApprochImpl.Migrations;
using JanBatchCodeFirstApprochImpl.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JanBatchCodeFirstApprochImpl.Controllers
{
    public class SPController : Controller
    {
        private readonly ApplicationDbContext db;
        public SPController(ApplicationDbContext db)
        {

            this.db = db;
        }
        public IActionResult Index()
        {
            var data = db.students.FromSqlRaw("exec FetchStudents").ToList();
            return View(data);
        }

        public IActionResult AddStudent()
        {
            return View();
        }
        [HttpPost]

        public IActionResult AddStudent(Student s)
        {
            db.Database.ExecuteSqlRaw($"exec InsertOrUpdate '{s.Sid}','{s.SName}', '{s.Scourse}' ,'{s.Sfees}'");
                return RedirectToAction("Index");
        }

        public IActionResult DelStudent(int id)
        {
            db.Database.ExecuteSqlRaw($"exec DeleteStudents '{id}'");
            return RedirectToAction("Index");
        }

        public IActionResult EditStudent(int id)
        {
            var data = db.students.FromSqlRaw($"exec FindStudentById '{id}'").ToList().SingleOrDefault();
            return View(data);
        }

        [HttpPost]
        public IActionResult EditStudent(Student s)
        {
            db.Database.ExecuteSqlRaw($"exec InsertOrUpdate '{s.Sid}','{s.SName}','{s.Scourse}','{s.Sfees}'");
            return RedirectToAction("Index");
        }
    }
}

