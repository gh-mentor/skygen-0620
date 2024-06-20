/*
This file contains the 'Department' class. This class is used to store information about Acme corporation departments.
A department has an id, name, and owns  a collection of employees.
*/

using System.Collections.Generic;
using System;


namespace PayrollLibrary
{
    /*
    Create a class 'Department'.    
    Details:
    - The class has the following private fields:
      - _Id (int)
      - _Name (string)
      - _Employees (List<Employee>)
    - The class has the following public properties:
        - Id (int) - get and set
        - Name (string) - get and set
        - Employees (List<Employee>) - get
    - The class has a public c'tor that accepts id and name as parameters.
    - The class has a public method 'AddEmployee' that accepts an Employee object as a parameter and adds it to the _Employees list.
    - The class has an override for the ToString method that returns the department name.
   
    */
    public class Department
    {
        private int _Id;
        private string _Name;
        private List<Employee> _Employees;

        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        public List<Employee> Employees
        {
            get { return _Employees; }
        }

        public Department(int id, string name)
        {
            _Id = id;
            _Name = name;
            _Employees = new List<Employee>();
        }

        public void AddEmployee(Employee employee)
        {
            _Employees.Add(employee);
        }

        public override string ToString()
        {
            return $"Department: {_Name}";
        }
    }
}