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
using Carros;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Xml.Serialization;

namespace Carros
{
    public partial class Form1 : Form
    {
        private List<Carro> carros = new List<Carro>();
        public Form1()
        {
            InitializeComponent();            

            textBox1.ReadOnly = true;
            //
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Cosmic Sans MS", 10, FontStyle.Bold);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int count = 0;

            foreach (Control c in Controls)
            {
                if (c is System.Windows.Forms.TextBox && c != textBox1)
                {
                    System.Windows.Forms.TextBox tb = (System.Windows.Forms.TextBox)c;
                    if (!string.IsNullOrEmpty(tb.Text))
                    {
                        tb.Text = "";
                        count++;
                    }
                }

                if (c is System.Windows.Forms.ComboBox)
                {
                    System.Windows.Forms.ComboBox cb = (System.Windows.Forms.ComboBox)c;
                    if (cb.SelectedIndex != -1)
                    {
                        cb.SelectedIndex = -1;
                        count++;
                    }
                }

                if (c is CheckBox)
                {
                    CheckBox chk = (CheckBox)c;
                    if (chk.Checked)
                    {
                        chk.Checked = false;
                        count++;
                    }
                }

            }

            if (count == 0)
            {
                MessageBox.Show("Nenhum campo preenchido para ser limpo.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Campo(s) limpos!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            // Define o valor inicial do ID como 1
            textBox1.Text = "1";

            // Definir as propriedades WrapMode e AutoSizeRowsMode para as células que podem ser multi linha
            for (int i = 0; i <= 10; i++)
            {
                dataGridView1.Columns[i].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dataGridView1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }

            // Pular as próximas 5 células e definir as propriedades WrapMode e AutoSizeRowsMode para a célula seguinte
            int j = 11;
            if (j >= 0 && j < dataGridView1.Columns.Count)
            {
                dataGridView1.Columns[j].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dataGridView1.Columns[j].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            //Botão de "certinho" das checkbox, flat
            button4.FlatStyle = FlatStyle.Flat;
            button4.FlatAppearance.BorderSize = 0;

            //Deixar as comboBox bonitinha
            foreach (var comboBox in this.Controls.OfType<System.Windows.Forms.ComboBox>())
            {
                comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            }

            //Para não deixar selecionar a textBox do Id(código)              
            textBox1.Enabled = false;
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

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            textBox6.MaxLength = 4;
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

        private void button2_Click(object sender, EventArgs e)
        {
            // Verifica se todos os campos obrigatórios foram preenchidos
            if (!Controls.OfType<System.Windows.Forms.TextBox>().Where(tb => tb != textBox11 && tb != textBox1).All(tb => !string.IsNullOrWhiteSpace(tb.Text)) ||
                !Controls.OfType<System.Windows.Forms.ComboBox>().All(cb => cb.SelectedItem != null))
            {
                MessageBox.Show("Preencha todos os campos obrigatórios antes de prosseguir.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Verifica se o campo do número do chassi tem no mínimo 17 caracteres
            if (textBox9.Text.Length < 17)
            {
                MessageBox.Show("O número do chassi deve ter pelo menos 17 caracteres.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Verifica se o valor digitado na caixa de texto é um ano válido
            int ano;
            if (!int.TryParse(textBox6.Text, out ano) || ano > DateTime.Now.Year || ano < 1886)
            {
                MessageBox.Show("O ano inserido é inválido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Cria uma nova linha na dataGridView
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
            novaLinha.Cells[14].Value = checkBox5.Checked;
            novaLinha.Cells[15].Value = checkBox6.Checked;
            novaLinha.Cells[16].Value = textBox11.Text;

            // Adiciona a nova linha à dataGridView
            dataGridView1.Rows.Add(novaLinha);


            // Incrementa o valor do número atual
            int currentNumber;
            if (!int.TryParse(textBox1.Text, out currentNumber))
            {
                currentNumber = 1;
            }
            textBox1.Text = (currentNumber + 1).ToString();

            MessageBox.Show("Cadastro feito com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        

        private Point lastMousePosition;
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            lastMousePosition = Control.MousePosition;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point delta = new Point(
                    Control.MousePosition.X - lastMousePosition.X,
                    Control.MousePosition.Y - lastMousePosition.Y
                );
                Location = new Point(Location.X + delta.X, Location.Y + delta.Y);
                lastMousePosition = Control.MousePosition;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            // Excluir um cadastro da dataGridView
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecione um cadastro para excluir.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int rowIndex = dataGridView1.SelectedRows[0].Index;
            dataGridView1.Rows.RemoveAt(rowIndex);

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                dataGridView1.Rows[i].Cells[0].Value = (i + 1).ToString();
            }

            MessageBox.Show("Cadastro removido com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            // Adicionar algo novo na lista das comboBoxes
            //e da uma mensagem de erro caso escreva algo igual que já tenha na lista
            string newItem = Microsoft.VisualBasic.Interaction.InputBox("Digite a marca do seu carro:", "Adicionar item");
            if (!string.IsNullOrEmpty(newItem))
            {
                if (comboBox2.Items.Cast<string>().Any(item => string.Equals(item, newItem, StringComparison.CurrentCultureIgnoreCase)))
                {
                    MessageBox.Show("O item já existe na lista.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    comboBox2.Items.Add(newItem);
                    comboBox2.SelectedItem = newItem;
                    MessageBox.Show("O item foi adicionado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string newItem = Microsoft.VisualBasic.Interaction.InputBox("Digite o modelo do seu carro:", "Adicionar item");
            if (!string.IsNullOrEmpty(newItem))
            {            
                if (comboBox3.Items.Cast<string>().Any(item => string.Equals(item, newItem, StringComparison.CurrentCultureIgnoreCase)))
                {                
                    MessageBox.Show("O item já existe na lista.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    comboBox3.Items.Add(newItem);
                    comboBox3.SelectedItem = newItem;
                    MessageBox.Show("O item foi adicionado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            string newItem = Microsoft.VisualBasic.Interaction.InputBox("Digite o fabricante do seu carro:", "Adicionar item");
            if (!string.IsNullOrEmpty(newItem))
            {              
                if (comboBox4.Items.Cast<string>().Any(item => string.Equals(item, newItem, StringComparison.CurrentCultureIgnoreCase)))
                { 
                    MessageBox.Show("O item já existe na lista.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    comboBox4.Items.Add(newItem);
                    comboBox4.SelectedItem = newItem;
                    MessageBox.Show("O item foi adicionado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        private void button10_Click(object sender, EventArgs e)
        {
            string newItem = Microsoft.VisualBasic.Interaction.InputBox("Digite o tipo do seu carro:", "Adicionar item");
            if (!string.IsNullOrEmpty(newItem))
            {
                if (comboBox5.Items.Cast<string>().Any(item => string.Equals(item, newItem, StringComparison.CurrentCultureIgnoreCase)))
                {             
                    MessageBox.Show("O item já existe na lista.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    comboBox5.Items.Add(newItem);
                    comboBox5.SelectedItem = newItem;
                    MessageBox.Show("O item foi adicionado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        private void button11_Click(object sender, EventArgs e)
        {
            string newItem = Microsoft.VisualBasic.Interaction.InputBox("Digite a cor do seu carro:", "Adicionar item");
            if (!string.IsNullOrEmpty(newItem))
            {
                if (comboBox8.Items.Cast<string>().Any(item => string.Equals(item, newItem, StringComparison.CurrentCultureIgnoreCase)))
                {
                    MessageBox.Show("O item já existe na lista.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    comboBox8.Items.Add(newItem);
                    comboBox8.SelectedItem = newItem;
                    MessageBox.Show("O item foi adicionado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            string newItem = Microsoft.VisualBasic.Interaction.InputBox("Digite o tipo do combustível do seu carro:", "Adicionar item");
            if (!string.IsNullOrEmpty(newItem))
            {
                if (comboBox7.Items.Cast<string>().Any(item => string.Equals(item, newItem, StringComparison.CurrentCultureIgnoreCase)))
                {
                    MessageBox.Show("O item já existe na lista.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    comboBox7.Items.Add(newItem);
                    comboBox7.SelectedItem = newItem;
                    MessageBox.Show("O item foi adicionado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        private void label18_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                lastPoint = new Point(e.X, e.Y);
            }
        }
        private void label18_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.AllowUserToAddRows = false; // impede o usuário de adicionar linhas manualmente
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // ajusta automaticamente o tamanho das colunas
            dataGridView1.ReadOnly = true; // torna o DataGridView somente leitura
        }      

        private void btnSalvarBackup_Click(object sender, EventArgs e)
        {
            List<Carro> carrosBackup = new List<Carro>();

            foreach (DataGridViewRow linha in dataGridView1.Rows)
            {
                if (!linha.IsNewRow)
                {
                    Carro carro = new Carro();
                    carro.Marca = linha.Cells["Marca"].Value?.ToString();
                    carro.Modelo = linha.Cells["Modelo"].Value?.ToString();
                    carro.Fabricante = linha.Cells["Fabricante"].Value?.ToString();
                    carro.Tipo = linha.Cells["Tipo"].Value?.ToString();
                    carro.Ano = Convert.ToInt32(linha.Cells["Ano"].Value);
                    carro.Combustível = linha.Cells["Combustivel"].Value?.ToString();
                    carro.Cor = linha.Cells["Cor"].Value?.ToString();
                    carro.NumChassi = Convert.ToInt64(linha.Cells["NumChassi"].Value);
                    carro.Kilometragem = Convert.ToInt32(linha.Cells["Kilometragem"].Value);
                    carro.Revisão = Convert.ToBoolean(linha.Cells["Revisao"].Value).ToString();
                    carro.Sinistro = Convert.ToBoolean(linha.Cells["Sinistro"].Value).ToString();
                    carro.Roubo_Furto = Convert.ToBoolean(linha.Cells["Roubo_Furto"].Value).ToString();
                    carro.Aluguel = linha.Cells["Aluguel"].Value?.ToString();
                    carro.Venda = Convert.ToBoolean(linha.Cells["Venda"].Value).ToString();
                    carro.Particular = Convert.ToBoolean(linha.Cells["Particular"].Value).ToString();
                    carro.Observações = linha.Cells["Observacoes"].Value?.ToString();

                    carrosBackup.Add(carro);
                }
            }
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Arquivos XML|*.xml";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;

                using (var streamWriter = new StreamWriter(filePath))
                {
                    var serializer = new XmlSerializer(typeof(List<Carro>));
                    serializer.Serialize(streamWriter, carrosBackup);
                }

                MessageBox.Show("Backup salvo com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnCarregarBackup_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Arquivos XML (*.xml)|*.xml";
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;

                try
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(List<Carro>));
                    using (StreamReader reader = new StreamReader(filePath))
                    {
                        List<Carro> carrosBackup = (List<Carro>)serializer.Deserialize(reader);

                        // Obtém o ID máximo dos carros existentes na coleção atual
                        int maxID = carros.Any() ? carros.Max(c => c.ID) : 0;

                        // Limpa a dataGridView
                        dataGridView1.Rows.Clear();

                        foreach (Carro carro in carrosBackup) // Preenche a dataGridView com os dados carregados
                        {
                            // Incrementa o ID para evitar conflitos com carros existentes
                            maxID++;
                            carro.ID = maxID;

                            DataGridViewRow novaLinha = new DataGridViewRow();
                            novaLinha.CreateCells(dataGridView1);
                            novaLinha.Cells[0].Value = carro.ID;
                            novaLinha.Cells[1].Value = carro.Marca;
                            novaLinha.Cells[2].Value = carro.Modelo;
                            novaLinha.Cells[3].Value = carro.Fabricante;
                            novaLinha.Cells[4].Value = carro.Tipo;
                            novaLinha.Cells[5].Value = carro.Ano;
                            novaLinha.Cells[6].Value = carro.Combustível.ToString();
                            novaLinha.Cells[7].Value = carro.Cor;
                            novaLinha.Cells[8].Value = carro.NumChassi.ToString();
                            novaLinha.Cells[9].Value = carro.Kilometragem.ToString();
                            novaLinha.Cells[10].Value = carro.Revisão.ToString();
                            novaLinha.Cells[11].Value = carro.Sinistro.ToString();
                            novaLinha.Cells[12].Value = carro.Roubo_Furto.ToString();
                            novaLinha.Cells[13].Value = carro.Aluguel.ToString();
                            novaLinha.Cells[14].Value = carro.Venda.ToString();
                            novaLinha.Cells[15].Value = carro.Particular.ToString();
                            novaLinha.Cells[16].Value = carro.Observações;

                            dataGridView1.Rows.Add(novaLinha);
                        }

                        MessageBox.Show("Backup carregado com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao carregar o backup: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private Point lastPoint;
        private void pictureBox2_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void pictureBox2_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
