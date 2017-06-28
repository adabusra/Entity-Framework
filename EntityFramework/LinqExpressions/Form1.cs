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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            northwindDataContext nt = new northwindDataContext();
            dataGridView1.DataSource = from c in  nt.Customers join o in nt.Orders on c.CustomerID equals o.CustomerID select new
              {
                     o.Customer,
                     o.CustomerID,
                     o.Employee,
                     c.ContactName,
                     c.ContactTitle,
                     c.Country,
                     c.Address
              };

        }
    }
}
