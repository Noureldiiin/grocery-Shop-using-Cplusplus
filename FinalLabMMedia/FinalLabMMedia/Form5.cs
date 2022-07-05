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
    public partial class Form5 : Form
    {
        public string PathFruits = "Furits.txt";
        public string PathPrice = "Price.txt";
        public List<Price> ListPrice = new List<Price>();
        public List<Fruitii> ListFruits = new List<Fruitii>();
        public string item;
        public string NameItemSelected;
        public List<items> ListItems = new List<items>();
        public string PathItems = "Items.txt";
        public string tot = "0";
        public string v;
        public int x;
        public int y;

        public Form5()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int i = listBox1.SelectedIndex;
            listBox1.Items.RemoveAt(i);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index;

            foreach (int i in listBox1.SelectedIndices)
            {
                index = listBox1.SelectedIndex;
                item = listBox1.Items[index].ToString();
                StreamReader SR = new StreamReader(PathItems);
                while (!SR.EndOfStream)
                {
                    String line = SR.ReadLine();
                    string[] temp = line.Split(',');
                    items pnn = new items();
                    pnn.name = temp[0];
                    pnn.counter = temp[0];
                    ListItems.Add(pnn);
                }
                SR.Close();
            }
            for (int r = 0; r < ListItems.Count; r++)
            {
                string n = ListItems[r].name + "," + ListItems[r].counter;
                if (n == item)
                {
                    NameItemSelected = ListItems[r].name;
                    ShowImage();
                }
            }
        }
        void ShowImage()
        {
            StreamReader SR = new StreamReader(PathFruits);
            while (!SR.EndOfStream)
            {
                String line = SR.ReadLine();
                string[] temp = line.Split(',');
                Fruitii pnn = new Fruitii();
                pnn.name = temp[0];
                pnn.price = temp[1];
                pnn.path = temp[2];
                pnn.color = temp[3];
                ListFruits.Add(pnn);
            }
            SR.Close();
            for (int u = 0; u < ListFruits.Count; u++)
            {
                if (ListFruits[u].name == NameItemSelected)
                {
                    this.BackColor = Color.FromName(ListFruits[u].color);
                    pictureBox1.Image = Image.FromFile(ListFruits[u].path);
                }
            }
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            StreamReader SRItems = new StreamReader(PathItems, true);
            while (!SRItems.EndOfStream)
            {
                String line = SRItems.ReadLine();
                string[] temp = line.Split(',');
                items pnn = new items();
                pnn.name = temp[0];
                pnn.counter = temp[1];
                ListItems.Add(pnn);
            }
            SRItems.Close();
            StreamReader SR = new StreamReader(PathFruits);
            while (!SR.EndOfStream)
            {
                String line = SR.ReadLine();
                string[] temp = line.Split(',');
                Fruitii pnn = new Fruitii();
                pnn.name = temp[0];
                pnn.price = temp[1];
                pnn.path = temp[2];
                pnn.color = temp[3];
                ListFruits.Add(pnn);
            }
            SR.Close();

            StreamReader SRP = new StreamReader(PathPrice);
            while (!SRP.EndOfStream)
            {
                String line = SRP.ReadLine();
                string[] temp = line.Split(',');
                Price pnn = new Price();
                pnn.p = temp[0];
                ListPrice.Add(pnn);
            }
            SRP.Close();
            y = Convert.ToInt32(tot);
            for (int o = 0; o < ListPrice.Count; o++)
            {
                x = Convert.ToInt32(ListPrice[o].p);
                y += x;
            }
            tot = y.ToString();
            label2.Text = tot;
            string[] lines = File.ReadAllLines(PathItems);
            listBox1.Items.AddRange(lines);
            File.Create(PathItems).Close();
            ListPrice.Clear();
        }
        public class Price
        {
            public string p;
        }
        public class Fruitii
        {
            public String name;
            public String price;
            public String path;
            public String color;
            public int counter = 1;
        }
        public class items
        {
            public String name;
            public String counter;
        }
    }
}
