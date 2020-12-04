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

namespace SuperKeyGenerator
{
    public partial class Form1 : Form
    {
        private string key1 = "SKG";
        private string key2 = "SkgCrypt@";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Load Event
            label6.Text = "Ver.1.0";
            for (int i = 0; i < 20; i++)
            {
                key1 += System.Web.Security.Membership.GeneratePassword(128, 0);
            }

            for (int i = 0; i < 50; i++)
            {
                key2 += System.Web.Security.Membership.GeneratePassword(128, 0);
            }

            textBox2.Text = key1;
            textBox3.Text = key2;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Random Key ReGen
            key1 = "SKG";
            for (int i = 0; i < 20; i++)
            {
                key1 += System.Web.Security.Membership.GeneratePassword(128, 0);
            }
            textBox2.Text = key1;
            return;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Crypt Key ReGen
            key2 = "SkgCrypt@";
            for (int i = 0; i < 50; i++)
            {
                key2 += System.Web.Security.Membership.GeneratePassword(128, 0);
            }
            textBox3.Text = key2;
            return;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Is Null Check
            if(textBox1.Text == "")
            {
                MessageBox.Show("Custom Key Required.", "Oops.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if(textBox2.Text == "")
            {
                MessageBox.Show("Random Key Required.", "Oops.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (textBox3.Text == "")
            {
                MessageBox.Show("Crypt Key Required.", "Oops.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (textBox4.Text == "")
            {
                MessageBox.Show("Please choose save file.", "Oops.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (File.Exists(textBox4.Text))
            {
                DialogResult dr = MessageBox.Show("The file already exists.\nDo you want to continue?", "continue?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dr == DialogResult.No) return;
            }
            return;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Save file select
            saveFileDialog1.Title = "Choose save file..";
            saveFileDialog1.Filter = "SuperKeyGen Files (*.skg)|*.skg|All Files (*.*)|*.*";
            saveFileDialog1.FileName = "";
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel) return;
            else
            {
                textBox4.Text = saveFileDialog1.FileName;
            }
            return;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //Exit Application
            Application.Exit();
        }

    }
}
