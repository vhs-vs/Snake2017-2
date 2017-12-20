using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake.game
{
    class Game : GameObject
    {
        public int Width { get; private set; } = 20;
        public int Height { get; private set; } = 20;
        public Snake Snake { get; set; }
        public Food Food { get; set; }
        public bool Over { get; internal set; } = true;

        public void Start()
        {
            Snake = new Snake(Direction.East, new Point(10, 10));
            Food = new Food { Position = new Point(3, 3) };
            Over = false;
        }

        public void Tick()
        {
            Snake.Move();
        }

        public void HandleKey(Keys key)
        {
            if (key == Keys.Left)
            {
                Snake.TurnLeft();
            }
            else if (key == Keys.Right)
            {
                Snake.TurnRight();
            }
        }

        public override bool Accept(GameVisitor visitor)
        {
            visitor.Visit(this);
            Snake?.Accept(visitor);
            Food?.Accept(visitor);
            return true;
        }
    }
}
