using System;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        int n;        

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Text = "";
            label2.Text = "Enter n(odd):";
            label4.Text = "Enter num of iterations:";

            textBox1.MaxLength = 2;
            textBox2.MaxLength = 2;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();          
                      
            if (textBox1.Text == "")
            {
                label1.ForeColor = Color.Red;
                label1.Text = "Enter something!";
            }
            else
            {
                n = Convert.ToInt32(textBox1.Text);

                if (n % 2 == 0)
                {
                    textBox1.Text = "";
                    label1.ForeColor = Color.Red;
                    label1.Text = "Not an odd number,\n enter one more!";
                    //System.out.print("You enter not an odd number, enter one more: ");                
                }
                else
                {                   
                    n = Convert.ToInt32(textBox1.Text);
                    textBox1.Enabled = false;
                    textBox2.Enabled = false;
                    label1.ForeColor = Color.Green;
                    label1.Text = "Correct!";
                    //Size = new Size(27*n + 145, 7*n + 300);

                    switch (n)
                    {
                        case 1:
                            Size = new Size(300, 220);//+
                            break;
                        case 3:
                            Size = new Size(300, 220);//+
                            break;
                        case 5:
                            Size = new Size(300, 220);//+
                            break;
                        case 7:
                            Size = new Size(312, 243);//+
                            break;
                        case 9:
                            Size = new Size(360, 301);//+
                            break;
                        case 11:
                            Size = new Size(408, 359);//+
                            break;
                        case 13:
                            Size = new Size(456, 417);//+
                            break;
                        case 15:
                            Size = new Size(504, 475);//+
                            break;
                        case 17:
                            Size = new Size(552, 533);//+
                            break;
                        case 19:
                            Size = new Size(600, 591);//+
                            break;
                        case 21:
                            Size = new Size(648, 649);//+
                            break;
                        case 23:
                            Size = new Size(696, 707);//+
                            break;
                        case 25:
                            Size = new Size(744, 765);//+
                            break;
                    }

                    int[,] arr = new int[n,n];
                    int[,] immuneArr = new int[n,n];                    
                    Ringworm ringworm = new Ringworm(n, arr, immuneArr);
                                      
                    dataGridView1.ColumnCount = n;
                    dataGridView1.RowCount = n;               
                    
                    runArr(arr, n);                                          
                }
            }                                        
        }

        public static int[,] transportTmpArr(int[,] arr, int[,] tmpArr, int n)
        {

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    tmpArr[i, j] = arr[i, j];
                }
            }

            return tmpArr;
        }

        public static int[,] infection2(int[,] arr, int[,] immuneArr, int n)
        {
            Random random = new Random();
            int rand;
            int[,] tmpArr = new int[n, n];
            transportTmpArr(arr, tmpArr, n);

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (tmpArr[i, j] == 1)
                    {
                        //CENTER
                        if (i > 0 && j > 0 && i < n - 1 && j < n - 1)
                        {
                            rand = random.Next(0, 2);
                            if (rand == 1)
                            {
                                if (arr[i - 1, j] == 0)
                                {
                                    arr[i - 1, j] = 1;
                                    immuneArr[i - 1, j] = 10;
                                }
                            }
                            rand = random.Next(0, 2);
                            if (rand == 1)
                            {
                                if (arr[i, j + 1] == 0)
                                {
                                    arr[i, j + 1] = 1;
                                    immuneArr[i, j + 1] = 10;
                                }
                            }
                            rand = random.Next(0, 2);
                            if (rand == 1)
                            {
                                if (arr[i + 1, j] == 0)
                                {
                                    arr[i + 1, j] = 1;
                                    immuneArr[i + 1, j] = 10;
                                }
                            }
                            rand = random.Next(0, 2);
                            if (rand == 1)
                            {
                                if (arr[i, j - 1] == 0)
                                {
                                    arr[i, j - 1] = 1;
                                    immuneArr[i, j - 1] = 10;
                                }
                            }
                        }
                        //CORNERS
                        if (i == 0 && j == 0)
                        { //left-up
                            rand = random.Next(0, 2);
                            if (rand == 1)
                            {
                                if (arr[i + 1, j] == 0)
                                {
                                    arr[i + 1, j] = 1;
                                    immuneArr[i + 1, j] = 10;
                                }
                            }
                            rand = random.Next(0, 2);
                            if (rand == 1)
                            {
                                if (arr[i, j + 1] == 0)
                                {
                                    arr[i, j + 1] = 1;
                                    immuneArr[i, j + 1] = 10;
                                }
                            }
                        }
                        if (i == n - 1 && j == 0)
                        { //left-down
                            rand = random.Next(0, 2);
                            if (rand == 1)
                            {
                                if (arr[i - 1, j] == 0)
                                {
                                    arr[i - 1, j] = 1;
                                    immuneArr[i - 1, j] = 10;
                                }
                            }
                            rand = random.Next(0, 2);
                            if (rand == 1)
                            {
                                if (arr[i, j + 1] == 0)
                                {
                                    arr[i, j + 1] = 1;
                                    immuneArr[i, j + 1] = 10;
                                }
                            }
                        }
                        if (i == n - 1 && j == n - 1)
                        { //right-down
                            rand = random.Next(0, 2);
                            if (rand == 1)
                            {
                                if (arr[i, j - 1] == 0)
                                {
                                    arr[i, j - 1] = 1;
                                    immuneArr[i, j - 1] = 10;
                                }
                            }
                            rand = random.Next(0, 2);
                            if (rand == 1)
                            {
                                if (arr[i - 1, j] == 0)
                                {
                                    arr[i - 1, j] = 1;
                                    immuneArr[i - 1, j] = 10;
                                }
                            }
                        }
                        /*00000000000000000000000000000000000000000000000000000000000*/
                        if (i == 0 && j == n - 1)
                        { //right-up
                            rand = random.Next(0, 2);
                            if (rand == 1)
                            {
                                if (arr[i + 1, j] == 0)
                                {
                                    arr[i + 1, j] = 1;
                                    immuneArr[i + 1, j] = 10;
                                }
                            }
                            rand = random.Next(0, 2);
                            if (rand == 1)
                            {
                                if (arr[i, j - 1] == 0)
                                {
                                    arr[i, j - 1] = 1;
                                    immuneArr[i, j - 1] = 10;
                                }

                            }
                        }
                        //BARS
                        if (i > 0 && i < n - 1 && j == 0)
                        { // left-bar
                            rand = random.Next(0, 2);
                            if (rand == 1)
                            {
                                if (arr[i - 1, j] == 0)
                                {
                                    arr[i - 1, j] = 1;
                                    immuneArr[i - 1, j] = 10;
                                }
                            }
                            rand = random.Next(0, 2);
                            if (rand == 1)
                            {
                                if (arr[i, j + 1] == 0)
                                {
                                    arr[i, j + 1] = 1;
                                    immuneArr[i, j + 1] = 10;
                                }

                            }
                            rand = random.Next(0, 2);
                            if (rand == 1)
                            {
                                if (arr[i + 1, j] == 0)
                                {
                                    arr[i + 1, j] = 1;
                                    immuneArr[i + 1, j] = 10;
                                }

                            }
                        }
                        if (j > 0 && j < n - 1 && i == 0)
                        { // up-bar
                            rand = random.Next(0, 2);
                            if (rand == 1)
                            {
                                if (arr[i, j - 1] == 0)
                                {
                                    arr[i, j - 1] = 1;
                                    immuneArr[i, j - 1] = 10;
                                }
                            }
                            rand = random.Next(0, 2);
                            if (rand == 1)
                            {
                                if (arr[i + 1, j] == 0)
                                {
                                    arr[i + 1, j] = 1;
                                    immuneArr[i + 1, j] = 10;
                                }
                            }
                            rand = random.Next(0, 2);
                            if (rand == 1)
                            {
                                if (arr[i, j + 1] == 0)
                                {
                                    arr[i, j + 1] = 1;
                                    immuneArr[i, j + 1] = 10;
                                }
                            }
                        }
                        if (i > 0 && i < n - 1 && j == n - 1)
                        { // right-bar
                            rand = random.Next(0, 2);
                            if (rand == 1)
                            {
                                if (arr[i - 1, j] == 0)
                                {
                                    arr[i - 1, j] = 1;
                                    immuneArr[i - 1, j] = 10;
                                }
                            }
                            rand = random.Next(0, 2);
                            if (rand == 1)
                            {
                                if (arr[i, j - 1] == 0)
                                {
                                    arr[i, j - 1] = 1;
                                    immuneArr[i, j - 1] = 10;
                                }
                            }
                            rand = random.Next(0, 2);
                            if (rand == 1)
                            {
                                if (arr[i + 1, j] == 0)
                                {
                                    arr[i + 1, j] = 1;
                                    immuneArr[i + 1, j] = 10;
                                }
                            }
                        }
                        if (j > 0 && j < n - 1 && i == n - 1)
                        { // down-bar
                            rand = random.Next(0, 2);
                            if (rand == 1)
                            {
                                if (arr[i, j - 1] == 0)
                                {
                                    arr[i, j - 1] = 1;
                                    immuneArr[i, j - 1] = 10;
                                }
                            }
                            rand = random.Next(0, 2);
                            if (rand == 1)
                            {
                                if (arr[i - 1, j] == 0)
                                {
                                    arr[i - 1, j] = 1;
                                    immuneArr[i - 1, j] = 10;
                                }
                            }
                            rand = random.Next(0, 2);
                            if (rand == 1)
                            {
                                if (arr[i, j + 1] == 0)
                                {
                                    arr[i, j + 1] = 1;
                                    immuneArr[i, j + 1] = 10;
                                }
                            }
                        }
                    }
                }
            }
            return arr;
        }

        public void runArr(int[,] arr, int n)
        {

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    dataGridView1.Rows[i].Cells[j].Value = arr[i, j].ToString();
                }                
            }      
                       
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            label3.Text = Width.ToString() + "; " + Height.ToString();
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (!Char.IsDigit(number) && number > 0)
            {
                e.Handled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("0 - neutral \n1 - infected \n2 - protected", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int[,] arr = new int[n, n];
            int[,] immuneArr = new int[n, n];
            Ringworm ringworm = new Ringworm(n, arr, immuneArr);

            dataGridView1.ColumnCount = n;
            dataGridView1.RowCount = n;

            int iteratio = Convert.ToInt32(textBox2.Text);
            for (int k = 0; k < iteratio; k++)
            {
                runArr(infection2(arr, immuneArr, n), n);
                ringworm.immune(arr, immuneArr, n);
                Thread.Sleep(100);
            }
        }
    }
}
