using System;
using System.Windows.Forms;

namespace Snake
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();

            canvas.Paint += Canvas_Paint;
            ButtonStart.Click += ButtonStart_Click;
            this.KeyPress += FormMain_KeyPress;
            Timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            //Tick an Spiel weiterreichen
        }

        private void FormMain_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Tastendrücke an das Spiel weiterreichen
        }

        private void ButtonStart_Click(object sender, EventArgs e)
        {
            //Spiel starten
        }

        private void Canvas_Paint(object sender, PaintEventArgs e)
        {
            //Spiel zeichnen
        }

    }
}
