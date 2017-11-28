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
    public partial class Form_training_stat : Form
    {
        DataClasses1DataContext db;
        String temp;
        public Form_training_stat(string login)
        {
            temp = login;
            InitializeComponent();
        }

        private void Form_list_Load(object sender, EventArgs e)
        {
            label1.Text = "Logged in as: " + this.temp;
            label3.Text = "Online";

            using (db = new DataClasses1DataContext())
            {
                dataGridView1.ReadOnly = true;
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridView1.AllowUserToAddRows = false;
                dataGridView1.DataSource = db.view_participants_trainings;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form_list_all form_list_all = new Form_list_all(this.temp);
            form_list_all.Show();
            this.Hide();
        }
    }
}
