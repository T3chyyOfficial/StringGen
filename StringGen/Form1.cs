using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace StringGen
{
    /*
     * Author: T3chyy
     */
    public partial class Form1 : Form
    { 
        public string RString(int length)
        {
            string chars = "";
            var stringChars = new char[length];
            var random = new Random();

            if(checkBox1.CheckState == CheckState.Checked)
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

            if(chars == "")
            {
                MessageBox.Show("You must select a set of characters!", "StringGen", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            for (int i = 0; i < stringChars.Length; i++)
            {
                try
                {
                    stringChars[i] = chars[random.Next(chars.Length)];
                } catch 
                {
                    
                }
            }

            return new string(stringChars);
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           int characterCount = Convert.ToInt32(Math.Round(numericUpDown1.Value, 0));
           textBox1.Text = RString(characterCount);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/T3chyyOfficial/StringGen");
        }
    }
}
