using Snake.game;
using System;
using System.Windows.Forms;

namespace Snake
{
    public partial class FormMain : Form
    {
        Game game;
        Engine2d engine2D;

        public FormMain()
        {
            InitializeComponent();

            game = new Game();
            engine2D = new Engine2d { Game = game, Canvas = canvas };

            ButtonStart.Click += ButtonStart_Click;
            ButtonStart.Focus();
            this.KeyDown += FormMain_KeyDown;
            this.KeyPreview = true;
            Timer.Tick += Timer_Tick;                
        }


        private void FormMain_KeyDown(object sender, KeyEventArgs e)
        {
            //Tastendrücke an das Spiel weiterreichen
            game.HandleKey(e.KeyCode);
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (game.Over)
            {
                Timer.Enabled = false;
                ButtonStart.Visible = true;
            }
            else
            {
                //Tick an Spiel weiterreichen            
                game.Tick();
                engine2D.Refresh();
            }
        }

        private void ButtonStart_Click(object sender, EventArgs e)
        {
            //Spiel starten
            game.Start();
            Timer.Enabled = true;
            ButtonStart.Visible = false;
        }
    }
}
