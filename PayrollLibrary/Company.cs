/*
This file contains the 'Company' class. This class is used to store information about Acme corporation departments and employees.
*/

using System.Collections.Generic;
using System;

namespace PayrollLibrary
{
    /*
    
    Create a class called Company.
    private fields:
    - name: a string that stores the company's name
    - address: a CompanyAddress object that stores the company's address
    - phoneNumber: a string that stores the company's phone number
    - departments: a list of Department objects that store the company's departments
    public methods:
    - A constructor that initializes the name, address, and phoneNumber fields
    - 'AddDepartment'  adds a department to the company's list of departments
    - 'GetDepartment' returns a department object given an id
    - 'ListDepartments' returns a list of Department objects
    */

    public class Company
    {
        private string name;
        private CompanyAddress address;
        private string phoneNumber;
        private List<Department> departments;

        public Company(string name, CompanyAddress address, string phoneNumber)
        {
            this.name = name;
            this.address = address;
            this.phoneNumber = phoneNumber;
            departments = new List<Department>();
        }
        public List<Department> Departments => departments;

        public void AddDepartment(Department department)
        {
            departments.Add(department);
        }

        public Department? GetDepartment(int id)
        {
            foreach (Department department in departments)
            {
                if (department.Id == id)
                {
                    return department;
                }
            }
            return null;
        }

    }

    /*
    Create a class called CompanyAddress.
    private fields:
    - address: a string that stores the company's address
    - city: a string that stores the company's city
    - state: a string that stores the company's state
    - zip: a string that stores the company's zip code
    public methods:
    - A constructor that initializes the address, city, state, and zip fields
    - 'GetFullAddress' returns the full address as a string
    */

    public class CompanyAddress
    {
        private string address;
        private string city;
        private string state;
        private string zip;

        public CompanyAddress(string address, string city, string state, string zip)
        {
            this.address = address;
            this.city = city;
            this.state = state;
            this.zip = zip;
        }

        public string GetFullAddress()
        {
            return address + ", " + city + ", " + state + " " + zip;
        }
    }
}