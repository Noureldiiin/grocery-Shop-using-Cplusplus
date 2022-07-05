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
    public partial class Form3 : Form
    {
        public string PathUsers = "Users.txt";
        public List<NewUser> ListNewUsers = new List<NewUser>();
        int FlagNewUser = 0;
        public Form3()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            button1.Enabled = checkBox1.Checked;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox2.Text != textBox3.Text)
            {
                MessageBox.Show("Password not match");
                FlagNewUser = 0;
            }
            else
            {
                FlagNewUser = 1;
            }
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && FlagNewUser == 1)
            {
                StreamWriter SWNewUser = new StreamWriter(PathUsers, true);
                string name = textBox1.Text;
                string pass = textBox2.Text;
                SWNewUser.WriteLine(name + "," + pass);
                SWNewUser.Close();
            }
            else
            {
                if (FlagNewUser == 1)
                {
                    FlagNewUser = 0;
                    MessageBox.Show("Please enter username and password");
                }
            }
            if (FlagNewUser == 1)
                this.Close();
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.PasswordChar = '*';
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            textBox3.PasswordChar = '*';
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            button1.Visible = true;
            button1.Enabled = checkBox1.Checked;
        }
    }
    public class NewUser
    {
        public String name;
        public String ID;
    }
}
