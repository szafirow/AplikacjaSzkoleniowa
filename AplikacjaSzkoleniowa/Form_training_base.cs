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
    public partial class Form_training_base : Form
    {
        DataClasses1DataContext db;
        String temp;
        public Form_training_base(string login)
        {
            temp = login;
            InitializeComponent();
        }

        private void Form_training_base_Load(object sender, EventArgs e)
        {
            label1.Text = "Logged in as: " + this.temp;
            label3.Text = "Online";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form_list_all form_list_all = new Form_list_all(this.temp);
            form_list_all.Show();
            this.Hide();
        }
    }
}
