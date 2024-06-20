/*
This file contains the HourlyEmployee class. This class is derived from the Employee class. It contains the properties and methods that are specific to hourly employees.
*/

namespace PayrollLibrary
{

    /*
    Create a public class 'HourlyEmployee'.
    Details:
    - The class is derived from the Employee class.
    - The class has a public c'tor that accepts all the properties as parameters, and calls the base c'tor.
    - The class has a default c'tor that calls the base c'tor with null values.
    - The class has the following private fields:
      - _HourlyRate (double)
      - _HoursWorked (double)
    - The class has the following public properties:
        - HourlyRate (double) - get and set
        - HoursWorked (double) - get and set
        - Payment (double) - get-only, override
        - EmployeeDetails (string) - get-only, override
    */

    public class HourlyEmployee : Employee
    {
        private double _HourlyRate;
        private double _HoursWorked;

        public double HourlyRate
        {
            get { return _HourlyRate; }
            set { _HourlyRate = value; }
        }

        public double HoursWorked
        {
            get { return _HoursWorked; }
            set { _HoursWorked = value; }
        }

        public HourlyEmployee(int? id, int? reportsTo, string? name, string? email, string? mobile, int? departmentId, double hourlyRate, double hoursWorked) : base(id, reportsTo, name, email, mobile, departmentId)
        {
            _HourlyRate = hourlyRate;
            _HoursWorked = hoursWorked;
        }

        public HourlyEmployee() : base(null, null, null, null, null, null)
        {
            _HourlyRate = 0;
            _HoursWorked = 0;
        }

        public override double Payment
        {
            get
            {
                return _HourlyRate * _HoursWorked;
            }
        }

        public override string EmployeeDetails
        {
            get
            {
                return base.EmployeeDetails + $", HourlyRate: {_HourlyRate}, HoursWorked: {_HoursWorked}";
            }
        }
    }
}
