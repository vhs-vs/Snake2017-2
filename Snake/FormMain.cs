using Snake.game;
using System;
using System.Windows.Forms;
using WMPLib;

namespace Snake
{
    public partial class FormMain : Form
    {

        Game game;
        Engine2d engine2D;

        WindowsMediaPlayer wmp;
        Track currentTrack;
        enum Track { Title, Game };
        const string soundPath = @"sound";

        public FormMain()
        {
            InitializeComponent();

            game = new Game();
            engine2D = new Engine2d { Game = game, Canvas = canvas };

            wmp = new WindowsMediaPlayer();
            wmp.PlayStateChange += Wmp_PlayStateChange;
            PlayMusic(Track.Title);

            ButtonStart.Click += ButtonStart_Click;
            ButtonStart.Focus();
            this.KeyDown += FormMain_KeyDown;
            this.KeyPreview = true;
            Timer.Tick += Timer_Tick;                
        }

        private void Wmp_PlayStateChange(int NewState)
        {
            if ((WMPPlayState)NewState == WMPPlayState.wmppsStopped)
            {
                wmp.controls.play();
            }
        }

        private void PlayMusic(Track track)
        {
            currentTrack = track;
            switch (track)
            {
                case Track.Title:
                    wmp.URL = System.IO.Path.Combine(soundPath, "DST-1990.mp3");
                    break;
                case Track.Game:
                    wmp.URL = System.IO.Path.Combine(soundPath, "DST-Electrode.mp3");
                    
                    break;
                default:
                    wmp.controls.stop();
                    break;
            }
            wmp.controls.play();
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
                PlayMusic(Track.Title);
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
            PlayMusic(Track.Game);
            //Spiel starten
            game.Start();
            Timer.Enabled = true;
            ButtonStart.Visible = false;
        }
    }
}
