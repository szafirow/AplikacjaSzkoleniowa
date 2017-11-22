using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AplikacjaSzkoleniowa
{
    public partial class Form_main : Form
    {
        public Form_main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form_training form_training = new Form_training();
            form_training.Show();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            Form_participant form_participant = new Form_participant();
            form_participant.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(1);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Hide();
            Form_login form_login = new Form_login();
            form_login.Show();
        }

       
    }
}
