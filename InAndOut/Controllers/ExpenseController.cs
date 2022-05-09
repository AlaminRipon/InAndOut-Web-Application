using InAndOut.Data;
using InAndOut.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace InAndOut.Controllers
{
    public class ExpenseController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ExpenseController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Expense> objList = _db.Expenses;   
            return View(objList);
        }
        
        [HttpGet]
        public IActionResult Create()
        {
            return View();  
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Expense obj)
        {
            if (ModelState.IsValid)
            {
                _db.Expenses.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View(obj);   
            }
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var exp = _db.Expenses.FirstOrDefault(x => x.Id == id);
            var result = new Expense()
            {
                Name = exp.Name,
                Cost = exp.Cost,
            };
            return View(result);
        }

        public IActionResult Update(Expense model)
        {
            var exp = new Expense()
            {
                Id = model.Id,
                Name = model.Name,
                Cost = model.Cost,
            };
            _db.Expenses.Update(exp);
            _db.SaveChanges();
            TempData["message"] = "Record Updated";
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var exp = _db.Expenses.SingleOrDefault(e => e.Id == id);
            _db.Expenses.Remove(exp);
            _db.SaveChanges();
            TempData["message"] = "Record Deleted";
            return RedirectToAction("Index");
        }

    }
}
