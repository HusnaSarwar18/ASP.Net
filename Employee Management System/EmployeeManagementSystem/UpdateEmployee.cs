﻿using EMS_BLL;
using EMS_BO;
using EMS_DAL;
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
    public partial class UpdateEmployee : Form
    {
        public UpdateEmployee()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            EmployeeDAL bll = new EmployeeDAL();
            try
            {
                EmployeeBo emp = new EmployeeBo();
                emp.EmployeeID = Convert.ToInt32(textBox1.Text);
                
                emp.FirstName = textBox2.Text;
                emp.LastName = textBox3.Text;
                emp.Position = textBox4.Text;
                emp.Salary = Convert.ToDecimal(textBox5.Text);
                emp.DepartmentID = Convert.ToInt32(textBox6.Text);
                

               bll.UpdateEmployee(emp);
                MessageBox.Show("Employee updated successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
