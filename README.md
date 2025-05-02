# Krish-AjaxCrud-SpMVC in 1 - no Api - no DI
Krish-AjaxCrud-SpMVC
1) Ajax Crud - AjaxController
2) image Crud - EmployeeController.cs with Dropdown -> ManagerController -> 
|Simple                         |
 public IActionResult AddEmployee()
        {
            ViewBag.managers = new SelectList(db.manager,"Mid","Mname");
            return View();
        }

|                          |
--+++--  Table me List EmployeeController.cs
 Inner Join  -- var data = db.employee.Include(x => x.mng).ToList();

|                          |
4) SpCrud - SPController


\JanBatchCodeFirstApprochImpl-Krish\JanBatchCodeFirstApprochImpl\JanBatchCodeFirstApprochImpl\JanBatchCodeFirstApprochImpl.csproj

Sp-MVC.txt ---> Procedure
