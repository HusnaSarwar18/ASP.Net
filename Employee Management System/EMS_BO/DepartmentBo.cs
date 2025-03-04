using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS_BO
{
    public class DepartmentBo
    {
        public int DepartmentID { get; set; }        // Unique ID for each department
        public string DepartmentName { get; set; }   // Name of the department
        public decimal Budget { get; set; }          // Budget allocated for the department
    }
}
