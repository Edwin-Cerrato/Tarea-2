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
           
            //Uso de error provider para evitar campos vacios por parte del usuario
            if (txtNota1.Text == "")
            {
                Alerta.SetError(txtNota1, "INGRESE LA CALIFICACIÓN");
                return;
            }

            if (txtNota2.Text == "")
            {
                Alerta.SetError(txtNota2, "INGRESE LA CALIFICACIÓN");
                return;
            }

            if (txtNota3.Text == "")
            {
                Alerta.SetError(txtNota3, "INGRESE LA CALIFICACIÓN");
                return;
            }

            if (txtNota4.Text == "")
            {
                Alerta.SetError(txtNota4, "INGRESE LA CALIFICACIÓN");
                return;
            }
            Alerta.Clear();

            //Declaración de Var de cajas de texto
            decimal nota1 = Convert.ToDecimal(txtNota1.Text);
            decimal nota2 = Convert.ToDecimal(txtNota2.Text);
            decimal nota3 = Convert.ToDecimal(txtNota3.Text);
            decimal nota4 = Convert.ToDecimal(txtNota4.Text);


            //Llamado de Función Asincrona 
            decimal Resultado = await PromedioEtudianteAsync(nota1,nota2,nota3,nota4);

            //Mensaje con el promedio del estudiante
            MessageBox.Show($"EL PROMEDIO FINAL DEL ESTUDIANTE ES :{ Resultado}","PROMEDIO FINAL",MessageBoxButtons.OK,MessageBoxIcon.Information);

        }

        //Creación de Función Asincrona
        private async Task<decimal>PromedioEtudianteAsync(decimal n1,decimal n2,decimal n3,decimal n4)
        {
            decimal promediofinal = await Task.Run(() =>
            {

                return (n1 + n2 + n3 + n4 )/ 4;
            });
            //Limpiar los textBox
            txtNota1.Clear();
            txtNota2.Clear();
            txtNota3.Clear();
            txtNota4.Clear();

            //Retorna al primer TextBox para introducir calificaciones de otro estudiante
            txtNota1.Focus();

            return promediofinal;

        }

    }
}
