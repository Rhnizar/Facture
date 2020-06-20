using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TpListview
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
        private void ViderForm()
        {
            textBox1.Text = textBox2.Text = textBox3.Text = "";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            double q = double.Parse(textBox2.Text);
            double p = double.Parse(textBox3.Text);
            double MHT = q * p;
            ListViewItem item = new ListViewItem(textBox1.Text);
            item.SubItems.Add(textBox2.Text);
            item.SubItems.Add(textBox3.Text);
            item.SubItems.Add(MHT.ToString());
            if (radioButton1.Checked == true)
            {
                p = 0.07;
            }
            else if (radioButton2.Checked == true)
            {
                p = 0.2;
            }
            else
                MessageBox.Show("Vérifier les champs");
            item.SubItems.Add((MHT * p).ToString());
            item.SubItems.Add((MHT + p * MHT).ToString());
            listView1.Items.Add(item);
            double THTC = 0;
            double TTVA = 0;
            for (int i = 0; i < listView1.Items.Count;i++ )
            {
                THTC += Convert.ToDouble(listView1.Items[i].SubItems[3].Text);
                TTVA += Convert.ToDouble(listView1.Items[i].SubItems[4].Text);
            }
            textBox4.Text = THTC.ToString()+ " $";
            textBox5.Text = TTVA.ToString()+ " $";
            textBox6.Text = (TTVA + THTC).ToString() + " $";
            
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listView1.Width = 730;
            listView1.Columns.Add("Designation", 120);
            listView1.Columns.Add("Prix Unitaire", 120);
            listView1.Columns.Add("Quantité", 120);
            listView1.Columns.Add("Montant ht", 120);
            listView1.Columns.Add("Montant TVA", 120);
            listView1.Columns.Add("Total(TTC)", 120);
            listView1.View = View.Details;
         
        }

        private void buttQuitter_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void butSupp_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listView1.Items)
                if (item.Selected) 
                    listView1.Items.Remove(item);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ViderForm();
        }

        private void butMod_Click(object sender, EventArgs e)
        {
           if (listView1.SelectedIndices.Count>0)
           {
               int i = listView1.SelectedIndices[0];
               textBox1.Text = listView1.Items[i].SubItems[0].Text;
               textBox2.Text = listView1.Items[i].SubItems[1].Text;
               textBox3.Text = listView1.Items[i].SubItems[2].Text;
               if (Convert.ToDouble(listView1.Items[i].SubItems[3].Text) == 20 * Convert.ToDouble(listView1.Items[i].SubItems[4].Text))
               {
                   radioButton2.Checked = true;
               }
               else
                   radioButton1.Checked = true;
               listView1.Items[i].Remove();
           }
                    
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
