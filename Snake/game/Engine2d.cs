using System;
using System.Drawing;
using System.Windows.Forms;

namespace Snake.game
{
    class Engine2d : GameVisitor
    {
        private PictureBox canvas;
        public PictureBox Canvas {
            get
            {
                return canvas;
            }
            set
            {
                //Beim Setzen einer Picturebox wird das Paint-Event abboniert
                canvas = value;
                canvas.Paint += Canvas_Paint;
                canvas.Resize += delegate { canvas.Refresh(); };
            }
        }      
        public Game Game { get; set; }
        public int Scaling { get; set; }
        public Point Offset { get; set; }
        public Graphics Device { get; set; }

        /// <summary>
        /// Eventhandler-Methode für das Paint-Event der PictureBox
        /// </summary>
        private void Canvas_Paint(object sender, PaintEventArgs e)
        {
            //Sicheren des Grafik-Context, Berechnen von Scaling und Offset
            Device = e.Graphics;
            Scaling = Math.Min(((canvas.Width -20)/ Game.Width), ((canvas.Height -20)/ Game.Height));
            Offset = new Point((canvas.Width - Game.Width * Scaling) / 2, (canvas.Height - Game.Height * Scaling) / 2);

            //Besucher-Zyklus starten
            Game.Accept(this);
        }

        /// <summary>
        /// Initiiert den Malvorgang
        /// </summary>
        public void Refresh()
        {
            Canvas.Refresh();
        }

        public override void Visit(Snake snake)
        {
            foreach (var hugo in snake.Body)
            {
                Device.FillRectangle(Brushes.DarkBlue, hugo.X * Scaling + Offset.X, hugo.Y * Scaling + Offset.Y, Scaling, Scaling);
            }
        }

        public override void Visit(Food food)
        {
            Device.FillRectangle(Brushes.Green, food.Position.X * Scaling + Offset.X, food.Position.Y * Scaling + Offset.Y, Scaling, Scaling);
        }

        public override void Visit(Game game)
        {
            Device.DrawRectangle(Pens.Black, Offset.X, Offset.Y, game.Width * Scaling, game.Height * Scaling);
        }
    }
}
