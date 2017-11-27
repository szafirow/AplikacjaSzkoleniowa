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
    public partial class Form_participant_base : Form
    {
        DataClasses1DataContext db;
        String temp;
        public Form_participant_base(string login)
        {
            temp = login;
            InitializeComponent();
        }

        private void Form_participant_base_Load(object sender, EventArgs e)
        {
            groupBox1.Enabled = false;
            label1.Text = "Logged in as: " + this.temp;
            label3.Text = "Online";

            using (db = new DataClasses1DataContext())
            {
                dataGridView1.ReadOnly = true;
                dataGridView1.DataSource =db.view_participants;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form_list_all form_list_all = new Form_list_all(this.temp);
            form_list_all.Show();
            this.Hide();
        }




        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            groupBox1.Enabled = true;

            textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();

            using (db = new DataClasses1DataContext())
            {
                comboBox1.DisplayMember = "code";
                comboBox1.ValueMember = "id_countries";
                comboBox1.DataSource = db.countries.ToList<countries>();
            }

            textBox5.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            textBox6.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();

            using (db = new DataClasses1DataContext())
            {
                comboBox2.DisplayMember = "name";
                comboBox2.ValueMember = "id_education";
                comboBox2.DataSource = db.education.ToList<education>();
            }


        }
    }
}
