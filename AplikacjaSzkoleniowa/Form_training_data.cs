using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

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

        private void button2_Click(object sender, EventArgs e)
        {
            //generowanie excela
            Microsoft.Office.Interop.Excel.Application xla = new Microsoft.Office.Interop.Excel.Application();
            Workbook xb = xla.Workbooks.Add(XlSheetType.xlWorksheet);
            Worksheet ws = (Worksheet)xla.ActiveSheet;

            xla.Visible = true;

            ws.Cells[1, 1] = "LP";
            ws.Cells[1, 2] = "Name";
            ws.Cells[1, 3] = "Surname";
            ws.Cells[1, 4] = "Email";
            ws.Cells[1, 5] = "Phone";
            ws.Cells[1, 6] = "Country";
            ws.Cells[1, 7] = "City";
            ws.Cells[1, 8] = "Street";
            ws.Cells[1, 9] = "Postal Code";
            ws.Cells[1, 10] = "Oferta";
            ws.Cells[1, 11] = "Education";


            for (int j = 2; j <= dataGridView1.Rows.Count+1; j++)
            {
                for (int i = 2; i <= 11; i++)
                {
                    ws.Cells[j, 1] = j - 1;
                    ws.Cells[j, i] = dataGridView1.Rows[j - 2].Cells[i - 1].Value;
                }
            }


           


        }
    }
}
