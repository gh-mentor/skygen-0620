/*
This file contains the abstract class Employee. This class is the base for the HourlyEmployee and SalariedEmployee classes. It contains the properties and methods that are common to both classes.
*/

namespace PayrollLibrary
{

  /*
  Create a public class 'Employee'.
  Details:
  - The class is abstract.
  - The class has the following nullable public properties:
    - Id (int, read-only)
    - ReportsTo (int)
    - Name (string)
    - Email (string)
    - Mobile (string)
    - DepartmentId (int)
  - The class has a public c'tor that accepts all the properties as parameters.
  - The class has the following public properties:
    - Payment (double) - get-only, abstract
  - The class has the following public methods:
    - EmployeeDetails (string) - get-only, virtual
  */

  public abstract class Employee
  {
    public int? Id { get; }
    public int? ReportsTo { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? Mobile { get; set; }
    public int? DepartmentId { get; set; }

    public Employee(int? id, int? reportsTo, string? name, string? email, string? mobile, int? departmentId)
    {
      Id = id;
      ReportsTo = reportsTo;
      Name = name;
      Email = email;
      Mobile = mobile;
      DepartmentId = departmentId;
    }

    public abstract double Payment { get; }
    public virtual string EmployeeDetails
    {
      get
      {
        return $"Id: {Id}, Name: {Name}, Email: {Email}, Mobile: {Mobile}, DepartmentId: {DepartmentId}";
      }
    }
  }

}
