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
using System.Security.Cryptography;

namespace SuperKeyGenerator
{
    public partial class Form1 : Form
    {
        private string key1 = "SKG";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Load Event
            label6.Text = "Ver.1.0";
            for (int i = 0; i < 4; i++)
            {
                key1 += System.Web.Security.Membership.GeneratePassword(5, 0);
            }

            textBox2.Text = key1;
            textBox3.Text = ":SkG@cRYpt:";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Random Key ReGen
            key1 = "SKG";
            for (int i = 0; i < 4; i++)
            {
                key1 += System.Web.Security.Membership.GeneratePassword(5, 0);
            }
            textBox2.Text = key1;
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

            string password = textBox3.Text + textBox1.Text + textBox2.Text + textBox3.Text;
            SHA256 sha256 = SHA256.Create();
            byte[] encoded = Encoding.UTF8.GetBytes(password);
            byte[] hash = sha256.ComputeHash(encoded);
            string hashed = string.Concat(hash.Select(b => $"{b:x2}"));

            Encoding enc = Encoding.GetEncoding("UTF-8");
            StreamWriter writer = new StreamWriter((textBox4.Text), false, enc);
            writer.WriteLine(hashed);
            writer.Close();

            MessageBox.Show("Generated!", "Done!", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkLabel1.LinkVisited = true;
            System.Diagnostics.Process.Start("https://github.com/dekotan24/super_key_gen");
            return;
        }
    }
}
