using EMS_BLL;
using EMS_BO;
using EMS_DAL;
using System;
using System.Windows.Forms;

namespace EmployeeManagementSystem
{
    public partial class addEmp : Form
    {
        public addEmp()
        {
            InitializeComponent();
        }

        // This method is triggered when the submit button is clicked
        private void SubmitButton_Click(object sender, EventArgs e)
        {
            
        }

        // Handlers for text change events (if needed)
        private void textBox1_TextChanged(object sender, EventArgs e) { }
        private void label6_Click(object sender, EventArgs e) { }
        private void label7_Click(object sender, EventArgs e) { }
        private void textBox6_TextChanged(object sender, EventArgs e) { }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            EmployeeBo e1 = new EmployeeBo();
            e1.DepartmentID = int.Parse(textBox2.Text);
            e1.Position = textBox3.Text;
            e1.Salary = int.Parse(textBox4.Text);
            e1.FirstName = textBox5.Text;
            e1.LastName = textBox6.Text;
            EmployeeDAL employee = new EmployeeDAL();
            employee.AddEmployee(e1);
            MessageBox.Show("Employee added successfully.");
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
