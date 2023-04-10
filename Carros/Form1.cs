using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Carros
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            textBox1.ReadOnly = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox6.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
            textBox11.Text = "";

            foreach (Control c in Controls)
            {
                if (c is System.Windows.Forms.ComboBox)
                {
                    ((System.Windows.Forms.ComboBox)c).SelectedIndex = -1;
                }

                if (c is CheckBox)
                {
                    CheckBox cb = (CheckBox)c;
                    if (cb.Checked == false)
                    {
                        cb.Checked = false;

                    }
                    else
                    {
                        cb.Checked = false;

                    }
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            foreach (Control c in Controls)
            {
                if (c is CheckBox)
                {
                    CheckBox cb = (CheckBox)c;
                    if (cb.Checked == false)
                    {
                        cb.Checked = true;

                    }
                    else
                    {
                        cb.Checked = false;

                    }
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button4.FlatStyle = FlatStyle.Flat;
            button4.FlatAppearance.BorderSize = 0;

            foreach (var comboBox in this.Controls.OfType<System.Windows.Forms.ComboBox>())
            {
                comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            }
            
        }


        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                { e.Handled = true; }
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                { e.Handled = true; }
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                { e.Handled = true; }
            }
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                { e.Handled = true; }
            }
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                { e.Handled = true; }
            }
        }

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                { e.Handled = true; }
            }
        }

        private void textBox9_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                { e.Handled = true; }
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            textBox6.MaxLength = 4;
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            textBox9.MaxLength = 17;
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            textBox10.MaxLength = 7;
        }

        private void textBox10_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                { e.Handled = true; }
            }
        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {
            textBox11.MaxLength = 256;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) ||
                comboBox2.SelectedItem == null ||
                comboBox3.SelectedItem == null ||
                comboBox4.SelectedItem == null ||
                comboBox5.SelectedItem == null ||
                string.IsNullOrWhiteSpace(textBox6.Text) ||
                comboBox7.SelectedItem == null ||
                comboBox8.SelectedItem == null ||
                string.IsNullOrWhiteSpace(textBox9.Text) ||
                string.IsNullOrWhiteSpace(textBox10.Text) ||
                string.IsNullOrWhiteSpace(textBox11.Text))
            {
                MessageBox.Show("Por favor, preencha todos os campos antes de prosseguir.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DataGridViewRow novaLinha = new DataGridViewRow();

            novaLinha.CreateCells(dataGridView1);
            novaLinha.Cells[0].Value = textBox1.Text;
            novaLinha.Cells[1].Value = comboBox2.Text;
            novaLinha.Cells[2].Value = comboBox3.Text;
            novaLinha.Cells[3].Value = comboBox4.Text;
            novaLinha.Cells[4].Value = comboBox5.Text;
            novaLinha.Cells[5].Value = textBox6.Text;
            novaLinha.Cells[6].Value = comboBox7.Text;
            novaLinha.Cells[7].Value = comboBox8.Text;
            novaLinha.Cells[8].Value = textBox9.Text;
            novaLinha.Cells[9].Value = textBox10.Text;
            novaLinha.Cells[10].Value = checkBox1.Checked;
            novaLinha.Cells[11].Value = checkBox2.Checked;
            novaLinha.Cells[12].Value = checkBox3.Checked;
            novaLinha.Cells[13].Value = checkBox4.Checked;
            novaLinha.Cells[15].Value = textBox11.Text;

            dataGridView1.Rows.Add(novaLinha);

            int currentNumber;
            if (!int.TryParse(textBox1.Text, out currentNumber))
            {
                currentNumber = 0;
            }
            textBox1.Text = (currentNumber + 1).ToString();

        }
    }
}
