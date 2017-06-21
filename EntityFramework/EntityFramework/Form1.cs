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
            DataClassesDataContext dcx = new DataClassesDataContext();

            dataGridView1.DataSource = dcx.Categories;


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
            Category kategori = dcx.Categories.SingleOrDefault(ctg => ctg.CategoryID== ctgryID);

            //dcx.Categories.DeleteAllOnSubmit(kategori);
            dcx.SubmitChanges();
            dataGridView1.DataSource = dcx.Categories;
        }

        private void button3_Click(object sender, EventArgs e)
        {

            int categoryID = (int)textBox1.Tag;
            DataClassesDataContext dcx = new DataClassesDataContext();
            Category ctg = dcx.Categories.SingleOrDefault(category => category.CategoryID == categoryID);

            ctg.CategoryName = textBox1.Text;
            ctg.Description = textBox2.Text;

            dcx.SubmitChanges();


        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView1.CurrentRow;

            textBox1.Text = row.Cells["Description"].Value.ToString();

            textBox1.Tag = row.Cells["id"].Value;

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            DataClassesDataContext ctx = new DataClassesDataContext();
            dataGridView1.DataSource = ctx.Categories.Where(x => x.CategoryName.Contains(textBox1.Text));
        }
    }
}
