using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using EMS_BO;

namespace EMS_DAL
{
    public class DepartmentDAL
    {
        private readonly string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=EMS;Integrated Security=True;Connect Timeout=30;Encrypt=False";

        // Retrieve all departments
        public IEnumerable<DepartmentBo> GetAllDepartments()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT DepartmentID, DepartmentName, Budget FROM Department";
                var departments = connection.Query<DepartmentBo>(query);
                return departments;
            }
        }

        // Add a new department
        public void AddDepartment(DepartmentBo dept)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                try
                {
                    // Validate department name
                    if (string.IsNullOrWhiteSpace(dept.DepartmentName))
                    {
                        throw new Exception("Department name cannot be empty.");
                    }

                    // Validate budget
                    if (dept.Budget <= 0)
                    {
                        throw new Exception("Budget must be greater than zero.");
                    }

                    // Insert the department
                    string insertQuery = @"INSERT INTO Department (DepartmentName, Budget)
                                           VALUES (@DepartmentName, @Budget)";
                    connection.Execute(insertQuery, dept);
                }
                catch (Exception ex)
                {
                    throw new Exception("Error adding department: " + ex.Message);
                }
            }
        }

        // Update department details
        public void UpdateDepartment(DepartmentBo dept)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                try
                {
                    // Validate if department exists
                    string checkDept = "SELECT COUNT(*) FROM Department WHERE DepartmentID = @DepartmentID";
                    var departmentExists = connection.Execute(checkDept, new { dept.DepartmentID });

                    if (departmentExists == 0)
                    {
                        throw new Exception("Department does not exist.");
                    }

                    // Validate department name
                    if (string.IsNullOrWhiteSpace(dept.DepartmentName))
                    {
                        throw new Exception("Department name cannot be empty.");
                    }

                    // Validate budget
                    if (dept.Budget <= 0)
                    {
                        throw new Exception("Budget must be greater than zero.");
                    }

                    // Update the department details
                    string updateQuery = @"UPDATE Department
                                           SET DepartmentName = @DepartmentName, Budget = @Budget
                                           WHERE DepartmentID = @DepartmentID";
                    connection.Execute(updateQuery, dept);
                }
                catch (Exception ex)
                {
                    throw new Exception("Error updating department: " + ex.Message);
                }
            }
        }

        // Delete a department by ID
        public void DeleteDepartment(int departmentId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                try
                {
                    // Validate if department exists
                    string checkDept = "SELECT COUNT(*) FROM Department WHERE DepartmentID = @DepartmentID";
                    var departmentExists = connection.Execute(checkDept, new { DepartmentID = departmentId });

                    if (departmentExists == 0)
                    {
                        throw new Exception("Department does not exist.");
                    }

                    // Delete the department
                    string deleteQuery = "DELETE FROM Department WHERE DepartmentID = @DepartmentID";
                    connection.Execute(deleteQuery, new { DepartmentID = departmentId });
                }
                catch (Exception ex)
                {
                    throw new Exception("Error deleting department: " + ex.Message);
                }
            }
        }
        // Method to retrieve department-wise employee count and total salary
        public IEnumerable<dynamic> GetDepartmentWiseAnalysis()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = @"SELECT d.DepartmentName, COUNT(e.EmployeeID) AS EmployeeCount, SUM(e.Salary) AS TotalSalary
                           FROM Employee e
                           INNER JOIN Department d ON e.DepartmentID = d.DepartmentID
                           GROUP BY d.DepartmentName";
                return connection.Query(sql).ToList();
            }
        }
        //GetDepartmentById
        public DepartmentBo GetDepartmentById(int departmentId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT DepartmentID, DepartmentName, Budget FROM Department WHERE DepartmentID = @DepartmentID";
                var department = connection.QuerySingleOrDefault<DepartmentBo>(query, new { DepartmentID = departmentId });

                if (department == null)
                {
                    throw new Exception("Department not found.");
                }

                return department;
            }
        }
    }
}
