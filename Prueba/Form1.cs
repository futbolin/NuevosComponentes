using NuevosComponentes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prueba
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            labelTextBox1.CambiaPosicion += (s, e) => CambioPosicion();
            labelTextBox1.CambiaSeparacion += (s, e) => CambioSeparacion();
        }

        private void labelTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.Text = "Letra: " + e.KeyChar;
        }

        private void btn_Click(object sender, EventArgs e)
        {
            labelTextBox1.Posicion = labelTextBox1.Posicion == ePosicion.DERECHA ?
                ePosicion.IZQUIERDA : ePosicion.DERECHA;

        }

        private void CambioPosicion()
        {
            Text = "Posición: " + labelTextBox1.Posicion;
        }

        private void CambioSeparacion()
        {
            Text = "Separación: " + labelTextBox1.Separacion;
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            labelTextBox1.Separacion = labelTextBox1.Separacion == 30 ? 10 :30;
        }

        private void KeyUp(object sender, KeyEventArgs e)
        {
            Text = "levantaste tecla";
        }
    }
}
