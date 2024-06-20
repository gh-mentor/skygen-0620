
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollLibrary
{
    public class Payroll
    {
        public void ProcessEmployees(Company company)
        {
            foreach (var department in company.Departments)
            {
                foreach (var employee in department.Employees)
                {
                    // print the employee payment
                    Console.WriteLine($"{employee.EmployeeDetails}, Payment: {employee.Payment}");
                    
                }
            }
        }
    }
}
