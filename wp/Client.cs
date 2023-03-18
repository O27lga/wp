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
    public partial class Client : Form
    {
        public static string conn = "Data Source=DESKTOP-ODAA6DI;Initial Catalog=Продукт;Integrated Security=True";
        private SqlConnection sc;
        private object Продукт;
        public Client()
        {
            InitializeComponent();
            sc = new SqlConnection(conn);
            sc.Open();
        }

        private void Client_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "продуктDataSet1.Product". При необходимости она может быть перемещена или удалена.
            this.productTableAdapter1.Fill(this.продуктDataSet1.Product);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "продуктDataSet.Product". При необходимости она может быть перемещена или удалена.
            this.productTableAdapter.Fill(this.продуктDataSet.Product);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "продуктDataSet.Client". При необходимости она может быть перемещена или удалена.
            this.clientTableAdapter.Fill(this.продуктDataSet.Client);

        }

        private void button1_Click(object sender, EventArgs e)
        {

            string Name = textBox1.Text;
            int ProductId = Convert.ToInt32(textBox2.Text);
            string query = "Insert Into Client(Name,ProductId)Values('" + Name + "','" + ProductId + "')";
            SqlCommand cmd = new SqlCommand(query, sc);
            cmd.ExecuteNonQuery();
            MessageBox.Show(" Новый поставщик заказан");
            this.clientTableAdapter.Fill(this.продуктDataSet.Client);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int Id = Convert.ToInt32(textBox3.Text);
            string query = "Delete From Client Where Id= " + Id;
            SqlCommand command = new SqlCommand(query, sc);
            command.ExecuteNonQuery();
            MessageBox.Show("Продукт продан");
            this.clientTableAdapter.Fill(this.продуктDataSet.Client);
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                dataGridView1.Rows[i].Selected = false;
                for (int j = 0; j < dataGridView1.ColumnCount; j++)
                    if (dataGridView1.Rows[i].Cells[j].Value != null)
                        if (dataGridView1.Rows[i].Cells[j].Value.ToString().Contains(textBox4.Text))
                        {
                            dataGridView1.Rows[i].Selected = true;
                            break;
                        }
            }
        }
    }
}
