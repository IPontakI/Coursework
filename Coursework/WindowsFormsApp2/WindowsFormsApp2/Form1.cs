using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int n;
        //Form1 form = new Form1();

        private void Form1_Load(object sender, EventArgs e)
        {
            //Form1 form = new Form1();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            

            n = Convert.ToInt32(textBox1.Text);

            switch (n)
            {
                case 0:
                case 1:
                case 3:
                case 5:
                case 7:
                    Size = new Size(318, 241);
                    break;
                case 9:
                case 11:
                case 13:
                case 15:
                case 17:
                    //form.Size = new Size(318, 241);
                    break;
                case 19:
                case 21:
                case 23:
                case 25:
                    //form.Size = new Size(318, 241);
                    break;
            }

            int[,] data = new int[n, n];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    data[i, j] = 1;

                }
            }

            dataGridView1.ColumnCount = n;
            dataGridView1.RowCount = n;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    dataGridView1.Rows[i].Cells[j].Value = data[i, j].ToString();
                }
            }
        }
    }    
}
