using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NuevosComponentes
{
    //Indica donde está la etiqueta respecto al TextBox
    public enum ePosicion
    {
        IZQUIERDA, DERECHA
    }

    [DefaultProperty("TextLbl"), DefaultEvent("Load")]

    public partial class LabelTextBox : UserControl
    {
        [Category("La propiedad cambió")]
        [Description("Se lanza cuando la propiedad Posición cambia")]
        public event System.EventHandler CambiaPosicion;


        [Category("La propiedad cambió")]
        [Description("Se lanza cuando la propiedad Separación cambia")]
        public event System.EventHandler CambiaSeparacion;

        [Category("El texto cambiço")]
        [Description("SE lanza cuando el texto cambia")]
        public event System.EventHandler TxtChanged;
      
        private ePosicion posicion = ePosicion.IZQUIERDA;

        [Category("Appearance")]
        [Description("Indica si la Label se sitúa a la IZQUIERDA o DERECHA del Textbox")]

        public ePosicion Posicion
        {
            set //Posicion
            {
                if (Enum.IsDefined(typeof(ePosicion), value))
                {
                    posicion = value;
                    recolocar();
                    CambiaPosicion?.Invoke(this, new EventArgs());
                }
                else
                {
                    throw new InvalidEnumArgumentException();
                }
            }

            get
            {
                return posicion;
            }
        }

        [Category("Appearance")]
        [Description("Cambia el PasswordChar del txt intento")]

        public bool PasswordChar = false;
        

        void recolocar()
        {
            switch (posicion)
            {
                case ePosicion.DERECHA:
                    //Establecemos posición del componente txt
                    txt.Location = new Point(0, 0);
                    //Establecemos ancho del Textbox (la label tiene ancho fijo)
                    txt.Width = this.Width - lbl.Width - Separacion;
                    //Establecemos posición del componente lbl
                    lbl.Location = new Point(txt.Width + Separacion, 0);
                    //Establecemos altura del componente
                    this.Height = Math.Max(txt.Height, lbl.Height);
                    break;
                case ePosicion.IZQUIERDA:
                    lbl.Location = new Point(0, 0);
                    txt.Location = new Point(lbl.Width + Separacion, 0);
                    txt.Width = this.Width - lbl.Width - Separacion;
                    this.Height = Math.Max(txt.Height, lbl.Height);
                    break;
            }
        }

        //Pixeles de separación entre label y textbox
        private int separacion = 0;
        [Category("Design")]
        [Description("Píxels de separación entre Label y Textbox")]
        public int Separacion
        {
            set
            {
                if (value >= 0)
                {
                    separacion = value;
                    recolocar();
                    CambiaSeparacion?.Invoke(this, new EventArgs());

                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
            get
            {
                return separacion;
            }
        }

        [Category("Appearance")]
        [Description("Texto asociado a la Label del control")]
        public string TextLbl
        {
            set
            {
                lbl.Text = value;
                recolocar();
            }
            get
            {
                return lbl.Text;
            }
        }


        [Category("Appearance")]
        [Description("Texto asociado al TextBox del control")]
        public string TextTxt
        {
            set
            {
                txt.Text = value;
            }
            get
            {
                return txt.Text;
            }
        }

        // Esta función has de enlazarla con el evento SizeChanged.
        // Sería necesario también tener en cuenta otros eventos como FontChanged
        // que aquí nos saltamos.
        private void LabelTextBox_SizeChanged(object sender, EventArgs e)
        {
            recolocar();
        }


        public LabelTextBox()
        {
            InitializeComponent();
            TextLbl = Name;
            TextTxt = "";
            recolocar();

        }

        private void txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.OnKeyPress(e);
        }

        private void txt_KeyUp(object sender,KeyEventArgs e)
        {
            this.OnKeyUp(e);
        }

        private void txt_TxtChanged(object sender,KeyEventArgs e)
        {
            TxtChanged?.Invoke(sender, e);
        }
    }
}
