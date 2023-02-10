using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tarea_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void btnCalcular_Click(object sender, EventArgs e)
        {
            //Declaración de Var de cajas de texto

            decimal nota1=Convert.ToDecimal (txtNota1.Text);
            decimal nota2 = Convert.ToDecimal(txtNota2.Text);
            decimal nota3 = Convert.ToDecimal(txtNota3.Text);
            decimal nota4 = Convert.ToDecimal(txtNota4.Text);

            //Txt Resultado
            decimal Resultado;

            //llamado de Función 
            Resultado = await PromedioEtudianteAsync(nota1,nota2,nota3,nota4);

        MessageBox.Show($"EL PROMEDIO FINAL ES :{ Resultado}");
        }

        //Función Asincrona
        private async Task<decimal>PromedioEtudianteAsync(decimal n1,decimal n2,decimal n3,decimal n4)
        {
            decimal promediofinal = await Task.Run(() =>
            {

                return (n1 + n2 + n3 + n4 )/ 4;
            });
                return promediofinal;
        }
    }
}
