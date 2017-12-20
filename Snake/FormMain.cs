using Snake.game;
using System;
using System.Windows.Forms;

namespace Snake
{
    public partial class FormMain : Form
    {
        Game game;

        public FormMain()
        {
            InitializeComponent();

            game = new Game();

            ButtonStart.Click += ButtonStart_Click;
            this.KeyDown += FormMain_KeyDown;
            Timer.Tick += Timer_Tick;
            canvas.Paint += Canvas_Paint;
        }

        private void Canvas_Paint(object sender, PaintEventArgs e)
        {
           //todo: Spielinhalt neu malen
        }

        private void FormMain_KeyDown(object sender, KeyEventArgs e)
        {
            //Tastendrücke an das Spiel weiterreichen
            game.HandleKey(e.KeyCode);
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            //Tick an Spiel weiterreichen            
            game.Tick();
        }

        private void ButtonStart_Click(object sender, EventArgs e)
        {
            //Spiel starten
            game.Start();
        }
    }
}
