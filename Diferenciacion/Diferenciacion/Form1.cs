using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Diferenciacion
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        double xi = 0;
        double h = 0;
        double x4 = 0;
        double x3 = 0;
        double x2 = 0;
        double x = 0;
        double c = 0;
        string tipo = "";
        string derivada = "";
        string oh = "";

        double resultado = 0;

        void Proceso()
        {
            try
            {
                xi = Convert.ToDouble(txtXi.Text);
                h = Convert.ToDouble(txtH.Text);
                x4 = Convert.ToDouble(txtX4.Text);
                x3 = Convert.ToDouble(txtX3.Text);
                x2 = Convert.ToDouble(txtX2.Text);
                x = Convert.ToDouble(txtX.Text);
                c = Convert.ToDouble(txtC.Text);
                tipo = cmbTipo.SelectedItem.ToString();
                oh = cmbError.SelectedItem.ToString();
                derivada = cmbDerivada.SelectedItem.ToString();

                if (tipo == "Centrada")
                {
                    switch (derivada)
                    {
                        case "Primera derivada":
                            switch (oh)
                            {
                                case "O(h^2)":
                                    resultado = ((CalcularFuncion(xi + h)) - (CalcularFuncion(xi - h))) / (2 * h);
                                    txtResultado.Text = resultado.ToString();
                                    break;

                                case "O(h^4)":
                                    resultado = ((-CalcularFuncion(xi + (2 * h))) + (8 * CalcularFuncion(xi + h)) - (8 * CalcularFuncion(xi - h)) + (CalcularFuncion(xi - (2 * h)))) / (12 * h);
                                    txtResultado.Text = resultado.ToString();
                                    break;

                                default:
                                    MessageBox.Show("La diferencia hacia centrada no tiene O(h) intente con otra opcion");
                                    cmbError.Focus();
                                    break;
                            }
                            break;

                        case "Segunda derivada":
                            switch (oh)
                            {
                                case "O(h^2)":
                                    resultado = (CalcularFuncion(xi + h) - (2 * CalcularFuncion(xi)) + CalcularFuncion(xi - h)) / (Math.Pow(h, 2));
                                    txtResultado.Text = resultado.ToString();
                                    break;

                                case "O(h^4)":
                                    resultado = (-CalcularFuncion(xi + (2 * h)) + (16 * CalcularFuncion(xi + h)) - (30 * CalcularFuncion(xi)) + (16 * CalcularFuncion(xi - h)) - (CalcularFuncion(xi - (2 * h)))) / (12 * Math.Pow(h, 2));
                                    txtResultado.Text = resultado.ToString();
                                    break;

                                default:
                                    MessageBox.Show("La diferencia hacia centrada no tiene O(h) intente con otra opcion");
                                    cmbError.Focus();
                                    break;
                            }
                            break;
                    }

                }
                else if (tipo == "Hacia adelante")
                {
                    switch (derivada)
                    {
                        case "Primera derivada":
                            switch (oh)
                            {
                                case "O(h)":
                                    resultado = ((CalcularFuncion(xi + h)) - (CalcularFuncion(xi))) / (2 * h);
                                    txtResultado.Text = resultado.ToString();
                                    break;

                                case "O(h^2)":
                                    resultado = ((-CalcularFuncion(xi + (h * 2))) + (4 * CalcularFuncion(xi + h)) - (3 * CalcularFuncion(xi))) / (2 * h);
                                    txtResultado.Text = resultado.ToString();
                                    break;

                                default:
                                    MessageBox.Show("La diferencia hacia adelante no tiene O(h^4) intente con otra opcion");
                                    cmbError.Focus();
                                    break;
                            }
                            break;

                        case "Segunda derivada":
                            switch (oh)
                            {
                                case "O(h)":
                                    resultado = ((CalcularFuncion(xi + (2 * h))) - (2 * CalcularFuncion(xi + h)) + (CalcularFuncion(xi))) / (Math.Pow(h, 2));
                                    txtResultado.Text = resultado.ToString();
                                    break;

                                case "O(h^2)":
                                    resultado = ((-CalcularFuncion(xi + (3 * h))) + (4 * CalcularFuncion(xi + (2 * h))) - (5 * CalcularFuncion(xi + h)) + (2 * CalcularFuncion(xi))) / (Math.Pow(h, 2));
                                    txtResultado.Text = resultado.ToString();
                                    break;

                                default:
                                    MessageBox.Show("La diferencia hacia adelante no tiene O(h^4) intente con otra opcion");
                                    cmbError.Focus();
                                    break;
                            }
                            break;
                    }
                }
                else
                {
                    switch (derivada)
                    {
                        case "Primera derivada":
                            switch (oh)
                            {
                                case "O(h)":
                                    resultado = ((CalcularFuncion(xi)) - (CalcularFuncion(xi - h))) / (2 * h);
                                    txtResultado.Text = resultado.ToString();
                                    break;

                                case "O(h^2)":
                                    resultado = ((3 * CalcularFuncion(xi)) - (4 * CalcularFuncion(xi - h)) + (1 * CalcularFuncion(xi - (2 * h)))) / (2 * h);
                                    txtResultado.Text = resultado.ToString();
                                    break;

                                default:
                                    MessageBox.Show("La diferencia hacia atras no tiene O(h^4) intente con otra opcion");
                                    cmbError.Focus();
                                    break;
                            }
                            break;

                        case "Segunda derivada":
                            switch (oh)
                            {
                                case "O(h)":
                                    resultado = ((CalcularFuncion(xi)) - (2 * CalcularFuncion(xi - h)) + (CalcularFuncion(xi + (2 * h)))) / (Math.Pow(h, 2));
                                    txtResultado.Text = resultado.ToString();
                                    break;

                                case "O(h^2)":
                                    resultado = ((2 * CalcularFuncion(xi)) - (5 * CalcularFuncion(xi - h)) + (4 * CalcularFuncion(xi + (2 * h))) - (CalcularFuncion(xi - (3 * h)))) / (Math.Pow(h, 2));
                                    txtResultado.Text = resultado.ToString();
                                    break;

                                default:
                                    MessageBox.Show("La diferencia hacia atras no tiene O(h^4) intente con otra opcion");
                                    cmbError.Focus();
                                    break;
                            }
                            break;
                    }
                }
            }

            catch(Exception ex)
            {
                MessageBox.Show("LLene todos los datos correctamente");
            }
        }

        public double CalcularFuncion(double XI)
        {
            double funcion = 0;
            funcion = ((Math.Pow(XI, 4) * x4) + (Math.Pow(XI, 3) * x3) + (Math.Pow(XI, 2) * x2) + (XI * x) + c);
            return funcion; 
        }

        public void Limpiar()
        {
            txtC.Clear();
            txtX.Clear();
            txtX2.Clear();
            txtX3.Clear();
            txtX4.Clear();
            txtH.Clear();
            txtXi.Clear();
            txtResultado.Clear();
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            Proceso();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cmbTipo.SelectedIndex = 0;
            cmbError.SelectedIndex = 0;
            cmbDerivada.SelectedIndex = 0;
            cmbError.Items.Clear();
            cmbError.Items.Add("O(h^2)");
            cmbError.Items.Add("O(h^4)");
        }

        private void cmbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTipo.SelectedItem.ToString()=="Centrada")
            {
                cmbError.Items.Clear();
                cmbError.Items.Add("O(h^2)");
                cmbError.Items.Add("O(h^4)");
                cmbError.SelectedIndex = 0;
            }
            else
            {
                cmbError.Items.Clear();
                cmbError.Items.Add("O(h)");
                cmbError.Items.Add("O(h^2)");
                cmbError.SelectedIndex = 0; ;
            }
        }
    }
}
