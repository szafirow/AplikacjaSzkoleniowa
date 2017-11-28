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
            button2.Enabled = false;
            button3.Enabled = false;
            label1.Text = "Logged in as: " + this.temp;
            label3.Text = "Online";

            using (db = new DataClasses1DataContext())
            {
                dataGridView1.ReadOnly = true;
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridView1.AllowUserToAddRows = false;
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
            try
            {
                groupBox1.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = true;

                textBox1.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                textBox2.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                textBox3.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                textBox4.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();

                using (db = new DataClasses1DataContext())
                {
                    comboBox1.DisplayMember = "code";
                    comboBox1.ValueMember = "id_countries";
                    comboBox1.DataSource = db.countries.ToList<countries>();
                }

                textBox5.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
                textBox6.Text = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();

                using (db = new DataClasses1DataContext())
                {
                    comboBox2.DisplayMember = "name";
                    comboBox2.ValueMember = "id_education";
                    comboBox2.DataSource = db.education.ToList<education>();
                }

                textBox7.Text = dataGridView1.SelectedRows[0].Cells[8].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            //UPDATE PARTICIPANT
            try
            {
                using (db = new DataClasses1DataContext())
                {
                    var result = (from p in db.participants
                                   where p.id_participants == Decimal.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString())
                    select p).Take(1);

                    foreach (var p in result)
                    {
                        participants participants = db.participants.Single(cp => cp.id_participants == p.id_participants);
                        participants.name = textBox1.Text;
                        participants.surname = textBox2.Text;
                        participants.email = textBox3.Text;
                        participants.phone = textBox4.Text;

                        participants.id_countries = Int32.Parse((comboBox1.SelectedValue.ToString()));
                        participants.city = textBox5.Text;
                        participants.street = textBox6.Text;
                        participants.postal_code = textBox7.Text;
                        participants.id_education = Int32.Parse((comboBox2.SelectedValue.ToString()));
                       

                        db.SubmitChanges();
                    }
                    //AKTUALIZACJA DATAGRID LIVE
                    dataGridView1.DataSource = null;
                    dataGridView1.Update();
                    dataGridView1.Refresh();
                    dataGridView1.DataSource = db.view_participants;
                }
                MessageBox.Show("The data has been modified!");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }


            
        }

        private void button2_Click(object sender, EventArgs e)
        {

            try
            {
                using (db = new DataClasses1DataContext())
                {

                    //DEL PARTICIPANT_TRAININGS
                    var result1 = (
                                from p in db.participants
                                join pt in db.participants_trainings
                                    on p.id_participants equals pt.id_participants_trainings
                                where p.id_participants == Decimal.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString())
                                select pt).Take(1);

                    foreach (var pt in result1)
                    {
                      
                        db.participants_trainings.DeleteOnSubmit(pt);
                        db.SubmitChanges();
                    }

                    //DEL PARTICIPANT
                    var result2 = (
                                 from p in db.participants
                                 where p.id_participants == Decimal.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString())
                                 select p).Take(1);

                    foreach (var p in result2)
                    {
                        db.participants.DeleteOnSubmit(p);
                        db.SubmitChanges();
                    }
                    //AKTUALIZACJA DATAGRID LIVE
                    dataGridView1.DataSource = null;
                    dataGridView1.Update();
                    dataGridView1.Refresh();
                    dataGridView1.DataSource = db.view_participants;
                }
                MessageBox.Show("Deleted record!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
        }

    }
}
