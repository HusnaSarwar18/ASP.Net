using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using EMS_BO;

namespace EMS_DAL
{
    public class EmployeeDAL
    {
        private readonly string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=EMS;Integrated Security=True;Connect Timeout=30;Encrypt=False";

        // Retrieve all employees with their department details
        public IEnumerable<EmployeeBo> GetAllEmployees()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = @"SELECT e.EmployeeID, e.FirstName, e.LastName, e.Position, e.Salary, e.DepartmentID, d.DepartmentName 
                                 FROM Employee e 
                                 INNER JOIN Department d ON e.DepartmentID = d.DepartmentID";
                var employees = connection.Query<EmployeeBo>(query);
                return employees;
            }
        }

        // Add a new employee 
        public void AddEmployee(EmployeeBo emp)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                try
                {
                    // Validate if department exists
                    string checkDept = "SELECT COUNT(*) FROM Department WHERE DepartmentID = @DepartmentID";
                    var departmentExists = connection.Execute(checkDept, new { emp.DepartmentID });

                    if (departmentExists == 0)
                    {
                        throw new Exception("Department does not exist.");
                    }

                    // Validate salary range
                    if (emp.Salary <= 0)
                    {
                        throw new Exception("Salary must be greater than zero.");
                    }

                    // Validate first and last names
                    if (string.IsNullOrWhiteSpace(emp.FirstName) || string.IsNullOrWhiteSpace(emp.LastName))
                    {
                        throw new Exception("First and Last names cannot be empty.");
                    }

                    // Insert the employee if all validations pass
                    string insertQuery = @"INSERT INTO Employee (FirstName, LastName, Position, Salary, DepartmentID)
                                           VALUES (@FirstName, @LastName, @Position, @Salary, @DepartmentID)";
                    connection.Execute(insertQuery, emp);
                }
                catch (Exception ex)
                {
                    throw new Exception("Error adding employee: " + ex.Message);
                }
            }
        }

        // Update employee details
        public void UpdateEmployee(EmployeeBo emp)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                try
                {
                    // Validate if employee exists
                    string checkEmp = "SELECT COUNT(*) FROM Employee WHERE EmployeeID = @EmployeeID";
                    var employeeExists = connection.Execute(checkEmp, new { emp.EmployeeID });
                    if (employeeExists == 0)
                    {
                        throw new Exception("Employee does not exist.");
                    }

                    // Validate salary range
                    if (emp.Salary <= 0)
                    {
                        throw new Exception("Salary must be greater than zero.");
                    }

                    // Validate first and last names
                    if (string.IsNullOrWhiteSpace(emp.FirstName) || string.IsNullOrWhiteSpace(emp.LastName))
                    {
                        throw new Exception("First and Last names cannot be empty.");
                    }

                    // Update the employee details
                    string updateQuery = @"UPDATE Employee
                                           SET FirstName = @FirstName, LastName = @LastName, Position = @Position, Salary = @Salary, DepartmentID = @DepartmentID
                                           WHERE EmployeeID = @EmployeeID";
                    connection.Execute(updateQuery, emp);
                }
                catch (Exception ex)
                {
                    throw new Exception("Error updating employee: " + ex.Message);
                }
            }
        }

        // Delete an employee by ID
        public void DeleteEmployee(int employeeId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                try
                {
                    // Validate if employee exists
                    string checkEmp = "SELECT COUNT(*) FROM Employee WHERE EmployeeID = @EmployeeID";
                    var employeeExists = connection.Execute(checkEmp, new { EmployeeID = employeeId });

                    if (employeeExists == 0)
                    {
                        throw new Exception("Employee does not exist.");
                    }

                    // Delete the employee
                    string deleteQuery = "DELETE FROM Employee WHERE EmployeeID = @EmployeeID";
                    connection.Execute(deleteQuery, new { EmployeeID = employeeId });
                }
                catch (Exception ex)
                {
                    throw new Exception("Error deleting employee: " + ex.Message);
                }
            }
        }

        // Get department-wise analysis
        //public IEnumerable<dynamic> GetDepartmentWiseAnalysis()
        //{
        //    using (var connection = new SqlConnection(connectionString))
        //    {
        //        connection.Open();
        //        string sql = @"SELECT d.DepartmentName, COUNT(e.EmployeeID) AS EmployeeCount, SUM(e.Salary) AS TotalSalary
        //                       FROM Employee e
        //                       INNER JOIN Department d ON e.DepartmentID = d.DepartmentID
        //                       GROUP BY d.DepartmentName";
        //        return connection.Query(sql).ToList();
        //    }
        //}
        // Retrieve an employee by ID
        public EmployeeBo GetEmployeeById(int employeeId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = @"SELECT e.EmployeeID, e.FirstName, e.LastName, e.Position, e.Salary, e.DepartmentID, d.DepartmentName 
                             FROM Employee e 
                             INNER JOIN Department d ON e.DepartmentID = d.DepartmentID
                             WHERE e.EmployeeID = @EmployeeID";
                var employee = connection.QuerySingleOrDefault<EmployeeBo>(query, new { EmployeeID = employeeId });

                if (employee == null)
                {
                    throw new Exception("Employee not found.");
                }

                return employee;
            }
        }
        public IEnumerable<EmployeeBo> SearchEmployees(string searchQuery)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = @"SELECT e.EmployeeID, e.FirstName, e.LastName, e.Position, e.Salary, e.DepartmentID, d.DepartmentName
                         FROM Employee e
                         INNER JOIN Department d ON e.DepartmentID = d.DepartmentID
                         WHERE e.FirstName LIKE @SearchQuery
                         OR e.LastName LIKE @SearchQuery
                         OR e.Position LIKE @SearchQuery
                         OR d.DepartmentName LIKE @SearchQuery";

                var employees = connection.Query<EmployeeBo>(query, new { SearchQuery = "%" + searchQuery + "%" });
                return employees;
            }
        }

    }
}
