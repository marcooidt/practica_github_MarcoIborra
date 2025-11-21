using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ejercicioTelegrama
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCalcularPrecio_Click(object sender, EventArgs e)
        {
            string textoTelegrama;
            char tipoTelegrama = 'o';
            int numPalabras = 0;
            double coste = 0;

            textoTelegrama = txtTelegrama.Text;

            // Leer el tipo de telegrama
            if (rbUrgente.Checked)
            {
                tipoTelegrama = 'u';
            }
            else // Asume que si no es Urgente, es Ordinario
            {
                tipoTelegrama = 'o';
            }

            string[] palabras = textoTelegrama.Split(' ');
            numPalabras = palabras.Length;

            if (tipoTelegrama == 'o')
            {
                if (numPalabras <= 10)
                {
                    coste = 2.5;
                }
                else
                {
                    // CORRECCIÓN: 2.5€ base + (palabras_extra * 0.50€)
                    coste = 2.5 + 0.5 * (numPalabras - 10);
                }
            }
            else
            {
                if (tipoTelegrama == 'u')
                {
                    if (numPalabras <= 10)
                    {
                        coste = 5;
                    }
                    else
                    {
                        coste = 5 + 0.75 * (numPalabras - 10);
                    }
                }
                else
                {
                    coste = 0;
                }
            }

            txtPrecio.Text = coste.ToString() + " euros";
        }
    }
}
