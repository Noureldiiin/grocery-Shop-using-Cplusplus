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
    public partial class Form4 : Form
    {
        public string PathFruits = "Furits.txt";
        public string PathCustomer = "Customer.txt";
        public string PathItems = "Items.txt";
        public string PathPrice = "Price.txt";
        int CountFruits = 0;
        int FlagItem = 0;
        int Number;
        int Next = 0;
        int Previous = 0;
        int NumberPrevious;
        public string name;
        public int counter;
        public int ct;
        public List<Customer> ListCustomer = new List<Customer>();
        public List<Fruits> ListFruits = new List<Fruits>();
        public List<itemm> ListItems = new List<itemm>();
        bool ItemThere = false;
        public Form4()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            PathItems.Clone();
            PathPrice.Clone();
            StreamReader SRI = new StreamReader(PathItems);
            while (!SRI.EndOfStream)
            {
                String line = SRI.ReadLine();
                string[] temp = line.Split(',');
                itemm pnn = new itemm();
                pnn.name = temp[0];
                pnn.counter = temp[1];
                ListItems.Add(pnn);
            }
            SRI.Close();

            StreamReader SR = new StreamReader(PathFruits);
            while (!SR.EndOfStream)
            {
                String line = SR.ReadLine();
                string[] temp = line.Split(',');
                Fruits pnn = new Fruits();
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

            StreamReader SR2 = new StreamReader(PathCustomer);
            while (!SR2.EndOfStream)
            {
                String line = SR2.ReadLine();
                string[] temp = line.Split(',');
                Customer pnn = new Customer();
                pnn.name = temp[0];
                ListCustomer.Add(pnn);
            }
            SR2.Close();
            label2.Text = ListCustomer[0].name;
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
        private void label3_Click(object sender, EventArgs e)
        {
            
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

        private void label5_Click(object sender, EventArgs e)
        {

        }
        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Your item has been added to the cart successfully");
            StreamWriter SWItem = new StreamWriter(PathItems, true);
            name = ListFruits[Next].name;
            counter = ListFruits[Next].counter++;
            SWItem.WriteLine(name + "," + counter);
            SWItem.Close();
            StreamWriter SW = new StreamWriter(PathPrice, true);
            string p = ListFruits[Next].price;
            SW.WriteLine(p);
            SW.Close();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            Form5 f5 = new Form5();
            f5.ShowDialog();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void progressBar1_Click(object sender, EventArgs e)
        {
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Shop f1 = new Shop();
            f1.ShowDialog();
            this.Close();

        }
    }
    public class Fruits
    {
        public String name;
        public String price;
        public String path;
        public String color;
        public int counter = 1;
    }
    public class Customer
    {
        public String name;
    }
    public class itemm
    {
        public String name;
        public String counter;
        public int count = 1;
    }
}
