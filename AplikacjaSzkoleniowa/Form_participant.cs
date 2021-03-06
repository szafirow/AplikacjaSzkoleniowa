﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Linq;
using System.Text.RegularExpressions;
using System.Net.Mail;
using System.Net;

namespace AplikacjaSzkoleniowa
{
    public partial class Form_participant : Form
    {
        DataClasses1DataContext db;
        String temp;
        public Form_participant(string login)
        {
            temp = login;
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            using (db = new DataClasses1DataContext())
            {
                comboBox1.DisplayMember = "code";
                comboBox1.ValueMember = "id_countries";
                comboBox1.DataSource = db.countries.ToList<countries>();

                comboBox2.DisplayMember = "name";
                comboBox2.ValueMember = "id_education";
                comboBox2.DataSource = db.education.ToList<education>();

                comboBox3.DisplayMember = "name";
                comboBox3.ValueMember = "id_offers";
                comboBox3.DataSource = db.offers.ToList<offers>().Where(p => p.active == true).ToList();

                comboBox4.DisplayMember = "name";
                comboBox4.ValueMember = "id_trainings";
                comboBox4.DataSource = db.trainings.ToList<trainings>().Where(t => t.active == true).ToList();

            }
            label14.Text = "Logged in as: " + this.temp;
            label12.Text = "Online";
        }



        private void btn_insertPartcipants_Click(object sender, EventArgs e)
        {

            try
            {
                Regex emailRegex = new Regex(@"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");
                Regex phoneRegex = new Regex(@"^[0-9]{9}$");
                Regex postalcodeRegex = new Regex(@"^[0-9]{5}$");


                //obsługa formularza
                if ((emailRegex.IsMatch(textBox3.Text)) 
                    && (phoneRegex.IsMatch(textBox4.Text))
                    && (postalcodeRegex.IsMatch(textBox7.Text))
                     && textBox1.Text.Length != 0
                     && textBox2.Text.Length != 0
                     && textBox5.Text.Length != 0
                     && textBox6.Text.Length != 0)
                {
                    if (MessageBox.Show("Are you sure you want to perform this operation?", "Question", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        using (db = new DataClasses1DataContext())
                        {
                            

                            var free = (from f in db.view_participants_trainings
                                        where f.id_trainings == Decimal.Parse(comboBox4.SelectedValue.ToString())
                                        select f.count_free).Single();

                            if (free > 0)
                            {
                                participants p = new participants();
                                p.name = textBox1.Text;
                                p.surname = textBox2.Text;
                                p.email = textBox3.Text;
                                p.phone = textBox4.Text;
                                p.id_countries = Int32.Parse((comboBox1.SelectedValue.ToString()));
                                p.city = textBox5.Text;
                                p.street = textBox6.Text;
                                p.postal_code = textBox7.Text;
                                p.id_education = Int32.Parse((comboBox2.SelectedValue.ToString()));
                                p.id_offers = Int32.Parse((comboBox3.SelectedValue.ToString()));

                                db.participants.InsertOnSubmit(p);
                                db.SubmitChanges();

                                var last_participants_id = db.participants.ToArray().LastOrDefault().id_participants;

                                participants_trainings pt = new participants_trainings();
                                pt.id_participants = Int32.Parse((last_participants_id.ToString()));
                                pt.id_trainings = Int32.Parse((comboBox4.SelectedValue.ToString()));
                                db.participants_trainings.InsertOnSubmit(pt);
                                db.SubmitChanges();
                                MessageBox.Show("New training added!");
                            }
                            else
                            {
                                MessageBox.Show("There are no places for training!");
                            }

                            

                        }
                      
                    }  
                }
                else
                {
                    MessageBox.Show("Wrongly completed form. Please correct errors!");
                }
                    
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void ustawieniaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_login form_participants = new Form_login();
            form_participants.Show();
        }

        private void plikToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form_main form_main = new Form_main(this.temp);
            form_main.Show();
            this.Hide();
        }
    }
}