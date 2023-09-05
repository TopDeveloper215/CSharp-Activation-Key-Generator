using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Serial_Maker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            try
            {
                stbPass.Text = SoftwareLocker.Encryption.MakePassword(stbBase.Text, txtIdentifier.Text);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Can't make password\n" + ex.Message);
            }
        }

        private void txtIdentifier_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}