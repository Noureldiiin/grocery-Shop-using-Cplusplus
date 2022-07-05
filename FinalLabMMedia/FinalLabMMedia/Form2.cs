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
    public partial class Form2 : Form
    {
        public string Username;
        public string PathAdmins = "Admins.txt";
        public string PathUsers = "Users.txt";
        public string PathCustomer = "Customer.txt";
        public List<Admins> ListAdmins = new List<Admins>();
        public List<Users> ListUsers = new List<Users>();
        public Form2()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.PasswordChar = '*';
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (PathUsers == null)
            {
                MessageBox.Show("The file dosen't exist");
            }
            if (textBox1.Text != "" && textBox2.Text != "" && PathUsers != null)
            {
                StreamReader SRUsers = new StreamReader(PathUsers);
                while (!SRUsers.EndOfStream)
                {
                    String line = SRUsers.ReadLine();
                    string[] temp = line.Split(',');
                    Users pnn = new Users();
                    pnn.name = temp[0];
                    Username = pnn.name;
                    pnn.ID = temp[1];
                    ListUsers.Add(pnn);
                }
                SRUsers.Close();
                StreamWriter SWCustomer = new StreamWriter(PathCustomer);
                string name = textBox1.Text;
                SWCustomer.Write(name);
                SWCustomer.Close();
                for (int a = 0; a < ListUsers.Count; a++)
                {
                    if (textBox1.Text == ListUsers[a].name && textBox2.Text == ListUsers[a].ID)
                    {
                        this.Hide();
                        Form4 f4 = new Form4();
                        f4.ShowDialog();
                        this.Close();
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (PathAdmins == null)
            {
                MessageBox.Show("The file dosen't exist");
            }
            if (textBox1.Text != "" && textBox2.Text != "" && PathAdmins != null)
            {
                StreamReader SRAdmins = new StreamReader(PathAdmins);
                while (!SRAdmins.EndOfStream)
                {
                    String line = SRAdmins.ReadLine();
                    string[] temp = line.Split(',');
                    Admins pnn = new Admins();
                    pnn.name = temp[0];
                    pnn.ID = temp[1];
                    ListAdmins.Add(pnn);
                }
                SRAdmins.Close();
                for (int a = 0; a < ListAdmins.Count; a++)
                {
                    if (textBox1.Text == ListAdmins[a].name && textBox2.Text == ListAdmins[a].ID)
                    {
                        Form6 f6 = new Form6();
                        f6.ShowDialog();
                        this.Close();
                    }
                }
            }
        }
    }
    public class Admins
    {
        public String name;
        public String ID;
    }
    public class Users
    {
        public String name;
        public String ID;
    }
    
}
