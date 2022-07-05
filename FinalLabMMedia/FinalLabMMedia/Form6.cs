using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalLabMMedia
{
    
    public partial class Form6 : Form
    {
        int Next;
        int Number;
        public List<Fruit> ListFruits = new List<Fruit>();
        public List<Customers> ListCustomer = new List<Customers>();
        public string PathFruits = "Furits.txt";
        public string PathCustomer = "Customer.txt";
        public string PathPic;
        public Form6()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Next++;
            for (int i = 0; i < ListFruits.Count; i++)
            {
                Number = i;
            }
            if (Next == Number + 1)
            {
                MessageBox.Show("There's no next fruits");
            }
            else
            {
                NextPic();
            }
        }
        void NextPic()
        {
            pictureBox1.Image = Image.FromFile(ListFruits[Next].path);
            label3.Text = ListFruits[Next].name;
            label5.Text = ListFruits[Next].price;
            this.BackColor = Color.FromName(ListFruits[Next].color);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Next--;
            //Previous = NumberPrevious;
            if (Next < 0)
            {
                Next++;
                MessageBox.Show("There's no previous fruits");
            }
            else
            {
                PreviousPic();
            }
        }
        void PreviousPic()
        {
            pictureBox1.Image = Image.FromFile(ListFruits[Next].path);
            label3.Text = ListFruits[Next].name;
            label5.Text = ListFruits[Next].price;
            this.BackColor = Color.FromName(ListFruits[Next].color);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || PathPic == "")
            {
                MessageBox.Show("Please enter your item");
            }
            else
            {
                StreamWriter SW = new StreamWriter(PathFruits, true);
                string name = textBox1.Text;
                string price = textBox2.Text;
                string path = PathPic;
                string color = textBox3.Text;
                SW.WriteLine(name + "," + price + "," + path + "," + color);
                SW.Close();
                Next = 0;
                Number = 0;
                StreamReader SR = new StreamReader(PathFruits);
                while (!SR.EndOfStream)
                {
                    String line = SR.ReadLine();
                    string[] temp = line.Split(',');
                    Fruit pnn = new Fruit();
                    pnn.name = temp[0];
                    pnn.price = temp[1];
                    pnn.path = temp[2];
                    pnn.color = temp[3];
                    ListFruits.Add(pnn);
                }
                SR.Close();
                pictureBox1.Image = Image.FromFile(ListFruits[0].path);
                label3.Text = ListFruits[0].name;
                label5.Text = ListFruits[0].price;
                this.BackColor = Color.FromName(ListFruits[0].color);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            label3.Text = "";
            label5.Text = "";
            label4.Text = "";
            label6.Text = "";
            OpenFileDialog OFD = new OpenFileDialog();
            if (OFD.ShowDialog() == DialogResult.OK)
            {
                PathPic = OFD.FileName;
                pictureBox1.Image = Image.FromFile(PathPic);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form6_Load(object sender, EventArgs e)
        {
            StreamReader SR = new StreamReader(PathFruits);
            while (!SR.EndOfStream)
            {
                String line = SR.ReadLine();
                string[] temp = line.Split(',');
                Fruit pnn = new Fruit();
                pnn.name = temp[0];
                pnn.price = temp[1];
                pnn.path = temp[2];
                pnn.color = temp[3];
                ListFruits.Add(pnn);
            }
            SR.Close();
            pictureBox1.Image = Image.FromFile(ListFruits[0].path);
            label3.Text = ListFruits[0].name;
            label5.Text = ListFruits[0].price;
            this.BackColor = Color.FromName(ListFruits[0].color);
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 f2 = new Form2();
            f2.ShowDialog();
            this.Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
    public class Fruit
    {
        public String name;
        public String price;
        public String path;
        public String color;
        public int counter = 1;
    }
    public class Customers
    {
        public String name;
    }
}
