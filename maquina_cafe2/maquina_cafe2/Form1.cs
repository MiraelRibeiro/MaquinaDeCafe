using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace maquina_cafe2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            txtValor.Text = "0.00";
        }

        public decimal custo = 0.00M;   
        
        public void liberar_bebida()
        {
            decimal saldo = Convert.ToDecimal(txtValor.Text);

            if(saldo >= 2.00M)
            {
                btnCafe.Enabled = true;

                if (saldo >= 3.00M)
                {
                    btnCafeLeite.Enabled = true;

                    if (saldo >= 3.50M)
                    {
                        btnCappuccino.Enabled = true;

                        if (saldo >= 4.00M)
                        {
                            btnMocha.Enabled = true;
                        }

                        else { btnMocha.Enabled = false; }
                    }

                    else { btnCappuccino.Enabled = false; }
                }

                else { btnCafeLeite.Enabled = false; }
            }

            else { btnCafe.Enabled = false; }
        }

        public double inserirValor(double valor)
        {
            double inserir = 0.00;            
            inserir = Convert.ToDouble(txtValor.Text);            
            return inserir + valor;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            txtPedido.Clear();
            custo = 3.50M;
            txtPedido.Text = "Cappuccino";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            double valor = 2.00;
            txtValor.Text = Convert.ToString(inserirValor(valor));            
        }

        private void btnComprar_Click(object sender, EventArgs e)
        {    
            if(txtValor.Text == "0.00")
            {                
                MessageBox.Show("Insira um valor e escolha uma bebida!");
            }

            else if (txtPedido.Text == string.Empty)
            {
                MessageBox.Show("Escolha a Bebida!");
            }

            decimal.TryParse(txtValor.Text, out decimal valorInserido);

            if(txtPedido.Text != string.Empty)
            {
                if (valorInserido < custo)
                {
                    lbTroco.Items.Clear();
                    MessageBox.Show("Valor insuficiente!");
                }

                else if (valorInserido == custo)
                {
                    lbTroco.Items.Clear();
                    txtPedido.Clear();
                    txtValor.Text = "0";
                    lbTroco.Items.Add("R$ 0,00");
                    MessageBox.Show("Retire sua bebida!");
                }

                else if (valorInserido > custo)
                {
                    decimal moeda = 1.00M;
                    int totMoedas = 0;
                    decimal troco = valorInserido - custo;

                    lbTroco.Items.Clear();

                    while (true)
                    {
                        if (troco >= moeda)
                        {
                            troco -= moeda;
                            totMoedas++;
                        }
                        else
                        {
                            if (totMoedas > 0) { lbTroco.Items.Add($"{totMoedas} moeda(s) de R$ {moeda}"); }

                            else if (moeda == 1.00M) { moeda = 0.50M; }
                            else if (moeda == 0.50M) { moeda = 0.25M; }
                            else if (moeda == 0.25M) { moeda = 0.10M; }
                            else if (moeda == 0.10M) { moeda = 0.05M; }
                            else if (moeda == 0.05M) { moeda = 0.01M; }
                            totMoedas = 0;
                            if (troco == 0) { break; }
                        }
                    }
                    
                    txtPedido.Clear();
                    txtValor.Text = "0";
                }
            }
            
        }


        private void btn1_Click(object sender, EventArgs e)
        {
            double valor = 1.00;
            txtValor.Text = Convert.ToString(inserirValor(valor));
        }

        private void btnCafe_Click(object sender, EventArgs e)
        {
            txtPedido.Clear();
            custo = 2.00M;
            txtPedido.Text = "Café";
        }

        private void btnMocha_Click(object sender, EventArgs e)
        {
            txtPedido.Clear();
            custo = 4.00M;
            txtPedido.Text = "Mocha";
        }

        private void btnCafeLeite_Click(object sender, EventArgs e)
        {
            txtPedido.Clear();
            custo = 3.00M;
            txtPedido.Text = "Cappuccino";
        }


        private void btn010_Click(object sender, EventArgs e)
        {
            double valor = 0.10;
            txtValor.Text = Convert.ToString(inserirValor(valor));             
        }

        private void btn025_Click(object sender, EventArgs e)
        {
            double valor = 0.25;
            txtValor.Text = Convert.ToString(inserirValor(valor));
        }

        private void btn050_Click(object sender, EventArgs e)
        {
            double valor = 0.50;
            txtValor.Text = Convert.ToString(inserirValor(valor));
        }

        private void btn5_Click(object sender, EventArgs e)
        {
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if(txtValor.Text != "0")
            {
                decimal troco = Convert.ToDecimal(txtValor.Text);                

                decimal moeda = 1.00M;
                int totMoedas = 0;

                lbTroco.Items.Clear();

                while (true)
                {
                    if (troco >= moeda)
                    {
                        troco -= moeda;
                        totMoedas++;
                    }
                    else
                    {
                        if (totMoedas > 0) { lbTroco.Items.Add($"{totMoedas} moeda(s) de R$ {moeda}"); }

                        else if (moeda == 1.00M) { moeda = 0.50M; }
                        else if (moeda == 0.50M) { moeda = 0.25M; }
                        else if (moeda == 0.25M) { moeda = 0.10M; }
                        else if (moeda == 0.10M) { moeda = 0.05M; }
                        else if (moeda == 0.05M) { moeda = 0.01M; }
                        totMoedas = 0;
                        if (troco == 0) { break; }
                    }
                }

                txtPedido.Clear();
                txtValor.Text = "0";
                MessageBox.Show("Cancelado! \nRetire o seu troco!");
            }
        }
    }
}
