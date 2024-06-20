/*
This file contains the SalariedEmployee class. This class is derived from the Employee class. It contains the properties and methods that are specific to salaried employees.
*/

namespace PayrollLibrary
{
    /*
    Create a public class 'SalariedEmployee'.
    Details:
    - The class is derived from the Employee class.
    - The class has a public c'tor that accepts all the properties as parameters, and calls the base c'tor.
    - The class has a default c'tor that calls the base c'tor with null values.
    - The class has the following private fields:
      - _WeeklySalary (double)
    - The class has the following public properties:
        - WeeklySalary (double) - get and set
        - Payment (double) - get-only, override
        - EmployeeDetails (string) - get-only, override
    */

    public class SalariedEmployee : Employee
    {
        private double _WeeklySalary;

        public double WeeklySalary
        {
            get { return _WeeklySalary; }
            set { _WeeklySalary = value; }
        }

        public SalariedEmployee(int? id, int? reportsTo, string? name, string? email, string? mobile, int? departmentId, double weeklySalary) : base(id, reportsTo, name, email, mobile, departmentId)
        {
            _WeeklySalary = weeklySalary;
        }

        public SalariedEmployee() : base(null, null, null, null, null, null)
        {
            _WeeklySalary = 0;
        }

        public override double Payment
        {
            get
            {
                return _WeeklySalary;
            }
        }

        public override string EmployeeDetails
        {
            get
            {
                return $"Id: {Id}, Name: {Name}, Email: {Email}, Mobile: {Mobile}, DepartmentId: {DepartmentId}, WeeklySalary: {WeeklySalary}";
            }
        }
    }

}
