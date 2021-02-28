using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NinjaTest.Mocking
{
    public class EmployeeController
    {
        private readonly IEmployeeStorage storage;

        public EmployeeController(IEmployeeStorage storage)
        {
            this.storage = storage;
        }

        public ActionResult DeleteEmployee(int id)
        {
            storage.DeleteEmployee(id);

            return RedirectToAction("Employees");
        }

        private ActionResult RedirectToAction(string employees)
        {
            return new RedirectResult();
        }
    }

    public class ActionResult { }

    public class RedirectResult : ActionResult { }

    public class EmployeeContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }

        public void SaveChanges()
        {

        }
    }

    public class Employee
    {
        public int Id { get; set; }
    }
}
