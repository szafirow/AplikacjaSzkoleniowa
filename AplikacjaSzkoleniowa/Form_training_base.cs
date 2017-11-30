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
                dataGridView1.DataSource = db.view_trainings;
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

                dateTimePicker1.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                dateTimePicker2.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();

                using (db = new DataClasses1DataContext())
                {
                    comboBox1.DisplayMember = "code";
                    comboBox1.ValueMember = "id_currency";
                    comboBox1.DataSource = db.currency.ToList<currency>();
                }

                textBox4.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
                textBox5.Text = dataGridView1.SelectedRows[0].Cells[9].Value.ToString();
                textBox6.Text = dataGridView1.SelectedRows[0].Cells[8].Value.ToString();

                checkBox1.Checked = Boolean.Parse(dataGridView1.SelectedRows[0].Cells[10].Value.ToString());

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }

           

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //UPDATE TRAINING

            try
            {
                if (MessageBox.Show("Are you sure you want to perform this operation?", "Question", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    using (db = new DataClasses1DataContext())
                    {
                        var result = (from t in db.trainings
                                      where t.id_trainings == Decimal.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString())
                                      select t).Take(1);

                        foreach (var t in result)
                        {
                            trainings trainings = db.trainings.Single(cp => cp.id_trainings == t.id_trainings);
                            trainings.name = textBox1.Text;
                            trainings.business = textBox2.Text;
                            trainings.leader = textBox3.Text;
                            trainings.price = Decimal.Parse(textBox4.Text);
                            trainings.id_currency = Int32.Parse((comboBox1.SelectedValue.ToString()));
                            trainings.slot = Int32.Parse(textBox5.Text);

                            trainings.start = Convert.ToDateTime(dateTimePicker1.Text);
                            trainings.finish = Convert.ToDateTime(dateTimePicker2.Text);

                            trainings.description = textBox6.Text;
                            trainings.active = checkBox1.Checked;
                            db.SubmitChanges();
                        }
                        //AKTUALIZACJA DATAGRID LIVE
                        dataGridView1.DataSource = null;
                        dataGridView1.Update();
                        dataGridView1.Refresh();
                        dataGridView1.DataSource = db.view_trainings;
                    }
                    MessageBox.Show("The data has been modified!");
                }   

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //DELETE TRAINING?
            try
            {
                if (MessageBox.Show("Are you sure you want to perform this operation?", "Question", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    using (db = new DataClasses1DataContext())
                    {
                     
                        //DEL PARTICIPANT_TRAININGS
                        var result1 = (
                                        from pt in db.participants_trainings
                                        where pt.id_trainings == Decimal.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString())
                                        select pt).Take(1);

                        foreach (var pt in result1)
                        {
                            db.participants_trainings.DeleteOnSubmit(pt);
                            db.SubmitChanges();
                        }

                        //DEL TRAININGS
                        var result2 = (
                                       from t in db.trainings
                                       where t.id_trainings == Decimal.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString())
                                       select t).Take(1);

                        foreach (var t in result2)
                        {
                            db.trainings.DeleteOnSubmit(t);
                            db.SubmitChanges();
                        }

                        

                        //AKTUALIZACJA DATAGRID LIVE
                        dataGridView1.DataSource = null;
                        dataGridView1.Update();
                        dataGridView1.Refresh();
                        dataGridView1.DataSource = db.view_trainings;
                  


                        /*   //DEL PARTICIPANT
                        var result1 = (
                                        from t in db.trainings
                                        join pt in db.participants_trainings
                                             on t.id_trainings equals pt.id_trainings
                                        join p in db.participants
                                            on pt.id_participants equals p.id_participants
                                        where t.id_trainings == Decimal.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString())
                                        select p).Take(1);

                        foreach (var p in result1)
                        { 
                            db.participants.DeleteOnSubmit(p);
                            db.SubmitChanges();
                        }
                         //DEL PARTICIPANT_TRAININGS
                            var result2 = (
                                            from t in db.trainings
                                            join pt in db.participants_trainings
                                                on t.id_trainings equals pt.id_participants_trainings
                                            where t.id_trainings == Decimal.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString())
                                            select pt).Take(1);

                            foreach (var pt in result2)
                            {
                                db.participants_trainings.DeleteOnSubmit(pt);
                                db.SubmitChanges();
                            }

                            //DEL TRAININGS
                            var result3 = (
                                           from t in db.trainings
                                           where t.id_trainings == Decimal.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString())
                                           select t).Take(1);

                            foreach (var t in result3)
                            {
                                db.trainings.DeleteOnSubmit(t);
                                db.SubmitChanges();
                            }*/
                    }
                    MessageBox.Show("Deleted record!");

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }

            

        }
    }
}
