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

namespace StringGen
{
    /*
     * Author: T3chyyOfficial
     * 
     * May 8th, 2022 @ 11:41 AM
     */
    public partial class Form2 : Form
    {
        public string RString(int length)
        {
            string chars = "";
            var stringChars = new char[length];
            var random = new Random();

            if (checkBox1.CheckState == CheckState.Checked)
            {
                chars += "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            }

            if (checkBox2.CheckState == CheckState.Checked)
            {
                chars += "abcdefghijklmnopqrstuvwxyz";
            }

            if (checkBox3.CheckState == CheckState.Checked)
            {
                chars += "0123456789";
            }

            if (checkBox4.CheckState == CheckState.Checked)
            {
                chars += "!@#$%^&*()_-+=,./<>?:`~";
            }

            if (chars == "")
            {
                MessageBox.Show("You must select a set of characters!", "StringGen", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            for (int i = 0; i < stringChars.Length; i++)
            {
                try
                {
                    stringChars[i] = chars[random.Next(chars.Length)];
                }
                catch
                {

                }
            }

            return new string(stringChars);
        }

        OpenFileDialog openFileDialog = new OpenFileDialog();

        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog.Filter = "txt files (*.txt)|*.txt";
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = openFileDialog.FileName;


            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1 == null)
                {
                    MessageBox.Show("Please specify a file to save to!", "StringGen", MessageBoxButtons.OK, MessageBoxIcon.Error);
                } else
                {
                    int characterCount = Convert.ToInt32(Math.Round(numericUpDown1.Value, 0));
                    File.WriteAllText(openFileDialog.FileName, RString(characterCount));
                    MessageBox.Show("Generated string to text file!", "StringGen", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message + "\n\n" + ex.StackTrace, "StringGen", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
