using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS_BO
{
    public class EmployeeBo
    {
        public int EmployeeID { get; set; }         // Unique ID for each employee
        public string FirstName { get; set; }       // Employee's first name
        public string LastName { get; set; }        // Employee's last name
        public string Position { get; set; }        // Employee's job position
        public decimal Salary { get; set; }         // Employee's salary
        public int DepartmentID { get; set; }       // Foreign key to Department table
        public string DepartmentName {  get; set; }
    }
}

