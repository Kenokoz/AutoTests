using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NinjaTest.Mocking
{
    public interface IEmployeeStorage
    {
        void DeleteEmployee(int id);
    }

    public class EmployeeStorage : IEmployeeStorage
    {
        private EmployeeContext db;

        public EmployeeStorage()
        {
            db = new EmployeeContext();
        }

        public void DeleteEmployee(int id)
        {
            var employee = db.Employees.Find(id);
            if (employee == null)
            {
                return;
            }
            db.Employees.Remove(employee);
            db.SaveChanges();
        }
    }
}
