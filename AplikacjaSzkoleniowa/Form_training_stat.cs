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

        private void button2_Click(object sender, EventArgs e)
        {
            // generowanie excela
            Microsoft.Office.Interop.Excel.Application xla = new Microsoft.Office.Interop.Excel.Application();
            Workbook xb = xla.Workbooks.Add(XlSheetType.xlWorksheet);
            Worksheet ws = (Worksheet)xla.ActiveSheet;

            xla.Visible = true;

            ws.Cells[1, 1] = "LP";
            ws.Cells[1, 2] = "Name";
            ws.Cells[1, 3] = "Count_save";
            ws.Cells[1, 4] = "Count_free";
            ws.Cells[1, 5] = "Slot";



            for (int j = 2; j <= dataGridView1.Rows.Count + 1; j++)
            {
                for (int i = 2; i <= 5; i++)
                {
                    ws.Cells[j, 1] = j - 1;
                    ws.Cells[j, i] = dataGridView1.Rows[j - 2].Cells[i - 1].Value;
                }
            }
        }
    }
}
