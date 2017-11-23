﻿using System;
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
    public partial class Form_training : Form
    {
        DataClasses1DataContext db;
        public Form_training()
        {
            InitializeComponent();
        }

        private void Form_training_Load(object sender, EventArgs e)
        {
            using (db = new DataClasses1DataContext())
            {
                comboBox1.DisplayMember = "code";
                comboBox1.ValueMember = "id_currency";
                comboBox1.DataSource = db.currency.ToList<currency>();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime date = DateTime.Now.Date;
                TimeSpan time = DateTime.Now.TimeOfDay;

                //dodac weryfikacje czy takie szkolenie jest juz w bazie(identyczne)

                if (textBox1.Text.Length != 0 
                    && textBox2.Text.Length != 0
                    && textBox3.Text.Length != 0
                    && textBox4.Text.Length != 0
                    && textBox5.Text.Length != 0
                    && (textBox4.Text.All(c => Char.IsNumber(c)))
                    && (textBox5.Text.All(c => Char.IsNumber(c)))
                    )
                {
                    using (db = new DataClasses1DataContext())
                    {
                        trainings t = new trainings();
                        t.name = textBox1.Text;
                        t.business = textBox2.Text;
                        t.leader = textBox3.Text;
                        t.price = Decimal.Parse(textBox4.Text);
                        t.slot = Int32.Parse(textBox5.Text);
                        t.description = textBox6.Text;
                        t.start = Convert.ToDateTime(dateTimePicker1.Text);
                        t.finish = Convert.ToDateTime(dateTimePicker2.Text);
                        t.id_currency = Int32.Parse((comboBox1.SelectedValue.ToString()));
                        t.active = true;
                        t.date_add = date + time;
                        db.trainings.InsertOnSubmit(t);
                        db.SubmitChanges();
                        MessageBox.Show("New training added!");

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
        
        private void button2_Click(object sender, EventArgs e)
        {
           
            Form_main form_main = new Form_main("a");
            form_main.Show();
            this.Hide();
        }
    }
}
