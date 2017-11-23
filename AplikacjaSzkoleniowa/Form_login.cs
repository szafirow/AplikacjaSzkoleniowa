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
    public partial class Form_login : Form
    {
        DataClasses1DataContext db;
        public Form_login()
        {
            InitializeComponent();
        }
        private void Form_login_Load(object sender, EventArgs e)
        {
            textBox2.PasswordChar = '*';
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            //logowanie
            using (db = new DataClasses1DataContext())
            {

                if (String.IsNullOrEmpty(textBox1.Text) || String.IsNullOrEmpty(textBox2.Text))
                {
                    MessageBox.Show("You did not complete the form!");
                }
                else
                {
                    
                    var count = (from u in db.users
                                 where u.login.Contains(textBox1.Text) & u.password.Contains(textBox2.Text) & u.active == true
                                 select u).Count();
                    //MessageBox.Show(count.ToString());
                    if (count >= 1)
                    {
                        Form_main form_main = new Form_main(textBox1.Text);
                        form_main.Show();
                        Hide();
                    }
                    else
                    {
                        MessageBox.Show("Wrongly completed form. Please correct errors!");
                    }
                }
               

            }

            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(1);
        }
    }
}
