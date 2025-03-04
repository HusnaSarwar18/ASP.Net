using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EMS_BO;
using EMS_DAL;

namespace EMS_BLL
{
    public class EmployeeManagementBLL
    {
        private readonly EmployeeDAL empDal = new EmployeeDAL();
        private readonly DepartmentDAL deptDal = new DepartmentDAL();

        // Employee Creation
        public void CreateEmployee(EmployeeBo emp)
        {
            // Validate department existence
            var departments = deptDal.GetAllDepartments(); // Assuming this returns a list of departments
            DepartmentBo department = null;

            foreach (var dept in departments)
            {
                if (dept.DepartmentID == emp.DepartmentID)
                {
                    department = dept;
                    break; // Exit the loop once the department is found
                }
            }

            if (department == null)
            {
                throw new Exception("Department does not exist.");
            }

            // Validate salary
            if (emp.Salary <= 0 || emp.Salary > department.Budget)
            {
                throw new Exception("Salary must be greater than zero and within the department budget.");
            }

            // Add employee
            empDal.AddEmployee(emp);
        }

        // Employee Update
        public void UpdateEmployee(EmployeeBo emp)
        {
            // Validate if employee exists
            var existingEmployee = empDal.GetEmployeeById(emp.EmployeeID);
            if (existingEmployee == null)
            {
                throw new Exception("Employee does not exist.");
            }

            // Validate salary against existing department
            var currentDepartment = deptDal.GetDepartmentById(existingEmployee.DepartmentID); // Assuming this method retrieves the department by ID
            if (emp.Salary <= 0 || emp.Salary > currentDepartment.Budget)
            {
                throw new Exception("Salary must be greater than zero and within the current department budget.");
            }

            // Check for department reassignment
            if (emp.DepartmentID != existingEmployee.DepartmentID)
            {
                var newDepartment = deptDal.GetDepartmentById(emp.DepartmentID); // Retrieve new department
                if (newDepartment == null)
                {
                    throw new Exception("New department does not exist.");
                }

                // Check if the new department has enough budget
                if (emp.Salary > newDepartment.Budget)
                {
                    throw new Exception("The new department does not have enough budget for this salary.");
                }
            }

            // Update the employee details
            empDal.UpdateEmployee(emp);
        }
        public void DeleteEmployee(int employeeId)
        {
            // Validate if employee exists before deletion
            var existingEmployee = empDal.GetEmployeeById(employeeId);
            if (existingEmployee == null)
            {
                throw new Exception("Employee does not exist.");
            }

            // Proceed with deletion
            empDal.DeleteEmployee(employeeId);
        }
        // Department-wise Employee Analysis
        public IEnumerable<dynamic> GetDepartmentWiseEmployeeAnalysis()
        {
            // Call the method from DepartmentDAL
            var analysis = deptDal.GetDepartmentWiseAnalysis();

            // Initialize a list to hold results
            var results = new List<dynamic>();

            // Calculate total salary spent and check against budget
            foreach (var dept in analysis)
            {
                var departmentID = dept.DepartmentID; // You might need to adjust this based on your query result
                var totalSalary = dept.TotalSalary;
                var budget = deptDal.GetDepartmentById(departmentID).Budget; // Ensure GetDepartmentById is implemented

                results.Add(new
                {
                    DepartmentName = dept.DepartmentName,
                    EmployeeCount = dept.EmployeeCount,
                    TotalSalary = totalSalary,
                    Budget = budget,
                    ExceedsBudget = totalSalary > budget // Check if total salary exceeds budget
                });
            }

            return results;
        }
        public IEnumerable<EmployeeBo> SearchEmployees(string searchQuery)
        {
            if (string.IsNullOrWhiteSpace(searchQuery))
            {
                throw new ArgumentException("Search query cannot be empty.");
            }

            // Call the DAL method to search for employees
            var employees = empDal.SearchEmployees(searchQuery);

            if (!employees.Any())
            {
                throw new Exception("No employees found matching the search criteria.");
            }

            return employees;
        }


    }
}

