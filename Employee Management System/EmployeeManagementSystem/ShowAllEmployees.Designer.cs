namespace EmployeeManagementSystem
{
    partial class dataGridViewEmployees
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.AllEmployeesButton = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.AllEmployeesButton)).BeginInit();
            this.SuspendLayout();
            // 
            // AllEmployeesButton
            // 
            this.AllEmployeesButton.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.AllEmployeesButton.Location = new System.Drawing.Point(148, 55);
            this.AllEmployeesButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.AllEmployeesButton.Name = "AllEmployeesButton";
            this.AllEmployeesButton.RowHeadersWidth = 51;
            this.AllEmployeesButton.RowTemplate.Height = 24;
            this.AllEmployeesButton.Size = new System.Drawing.Size(270, 188);
            this.AllEmployeesButton.TabIndex = 0;
            this.AllEmployeesButton.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.AllEmployeesButton_CellContentClick);
            // 
            // dataGridViewEmployees
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 562);
            this.Controls.Add(this.AllEmployeesButton);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "dataGridViewEmployees";
            this.Text = "GetAllEmployees";
            ((System.ComponentModel.ISupportInitialize)(this.AllEmployeesButton)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView AllEmployeesButton;
    }
}