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
    public partial class Form_list_all : Form
    {
        DataClasses1DataContext db;
        String temp;
        public Form_list_all(string login)
        {
            temp = login;
            InitializeComponent();
        }

        private void Form_list_all_Load(object sender, EventArgs e)
        {
            using (db = new DataClasses1DataContext())
            {
                comboBox1.DisplayMember = "name";
                comboBox1.ValueMember = "id_trainings";
                comboBox1.DataSource = db.trainings.ToList<trainings>().Where(t => t.active == true).ToList();

            }
            label2.Text = "Logged in as: " + this.temp;
            label3.Text = "Online";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form_training_stat form_training_stat = new Form_training_stat(this.temp);
            form_training_stat.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form_main form_main = new Form_main(this.temp);
            form_main.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form_participant_base form_participant_base = new Form_participant_base(this.temp);
            form_participant_base.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form_training_base form_training_base = new Form_training_base(this.temp);
            form_training_base.Show();
            this.Hide();
        }
    }
}
