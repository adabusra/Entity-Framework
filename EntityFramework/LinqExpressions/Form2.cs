using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LinqExpressions
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            northwindDataContext nt = new northwindDataContext();
            dataGridView1.DataSource = from o in nt.Orders  join emp in nt.Employees on o.EmployeeID equals emp.EmployeeID  select new
                                       {
                                            emp.EmployeeID,
                                            emp.Employees,
                                            emp.EmployeeTerritories,
                                          o.Customer,
                                          o.CustomerID
                                       };
        }
    }
}
