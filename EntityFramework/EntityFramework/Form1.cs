using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EntityFramework
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DataClassesDataContext ctx = new DataClassesDataContext();
            dataGridView1.DataSource = ctx.Categories;
            
             
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataClassesDataContext dcx = new DataClassesDataContext();
            Category category = new Category();
            category.Description = textBox1.Text;
            category.CategoryName = textBox2.Text;

            dcx.Categories.InsertOnSubmit(category);

            dcx.SubmitChanges();
            //submit changes olana kadar veritabanına kayıt eklenmez. Silersek silinmez. Olması gerekiyor.
            dataGridView1.DataSource = dcx.Categories;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int ctgryID = (int)dataGridView1.CurrentRow.Cells["id"].Value;
            DataClassesDataContext dcx = new DataClassesDataContext();
            Category category = dcx.Categories.
        }
    }
}
