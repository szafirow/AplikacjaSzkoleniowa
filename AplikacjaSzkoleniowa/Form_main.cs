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
        DataClasses1DataContext db;
        String temp;
        public Form_main(string t)
        {
            temp = t;
            InitializeComponent();
        }

        private void Form_main_Load(object sender, EventArgs e)
        {
            using (db = new DataClasses1DataContext())
            {
                var count = (from u in db.users
                             where u.login.Contains(this.temp) & u.active == true
                             select u).Count();
                if (count >= 1)
                {
                    label3.Text = "Logged in as: " + this.temp;
                    label2.Text = "Online";
                }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form_training form_training = new Form_training();
            form_training.Show();
            this.Hide();
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
