using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wp
{
    public partial class Form1 : Form
    {
        public static string conn = "Data Source=DESKTOP-ODAA6DI;Initial Catalog=Продукт;Integrated Security=True";
        private SqlConnection sc;
        private object Продукт;
        public Form1()
        {
            InitializeComponent();
            sc= new SqlConnection(conn);
            sc.Open();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "продуктDataSet1.Product". При необходимости она может быть перемещена или удалена.
            this.productTableAdapter1.Fill(this.продуктDataSet1.Product);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "продуктDataSet.Client". При необходимости она может быть перемещена или удалена.
            


        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            string Name = textBox1.Text;
            int Price = Convert.ToInt32(textBox2.Text);
            string query = "Insert Into Product(Name,Price)Values('" + Name + "','" + Price + "')";
            SqlCommand command = new SqlCommand(query,sc);
            command.ExecuteNonQuery();
            MessageBox.Show(" Продукт погружен на склад");
            this.productTableAdapter1.Fill(this.продуктDataSet1.Product);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var Id = Convert.ToInt32(textBox3.Text);
            string query = "Delete From Product Where Id= " + Id;
            SqlCommand command = new SqlCommand(query, sc);
            command.ExecuteNonQuery();
            MessageBox.Show("Продукт продан");
            this.productTableAdapter1.Fill(this.продуктDataSet1.Product);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Client f2 = new Client();
            f2.Owner = this;
            f2.Show();
        }
    }
}
