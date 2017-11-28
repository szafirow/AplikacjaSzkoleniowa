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

    public partial class Form_training_data : Form
    {
        DataClasses1DataContext db;
        String temp;
        int train;
        public Form_training_data(string login, int trainx)
        {
            temp = login;
            train = trainx;
            InitializeComponent();
        }

        private void Form_training_data_Load(object sender, EventArgs e)
        {
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AllowUserToAddRows = false;
            label1.Text = "Logged in as: " + this.temp;
            label3.Text = "Online";

            using (db = new DataClasses1DataContext())
            {
                dataGridView1.DataSource = (from p in db.participants
                                            join pt in db.participants_trainings
                                                  on p.id_participants equals pt.id_participants
                                            join t in db.trainings
                                                 on pt.id_trainings equals t.id_trainings
                                            where t.id_trainings == this.train
                                            select p);
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
