using EMS_BLL;
using EMS_BO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace EmployeeManagementSystem
{
    public partial class WelcomeForm : Form
    {
        public WelcomeForm()
        {
            InitializeComponent();
        }

        private void WelcomeForm_Load(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
            addEmp f = new addEmp();
            f.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {
                    

        }

        private void button1_Click(object sender, EventArgs e)
        {
            addEmp emp = new addEmp();
            emp.Show();

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            UpdateEmployee employee = new UpdateEmployee();
            employee.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridViewEmployees emp = new dataGridViewEmployees();
            emp.Show();
        }
    }
}
