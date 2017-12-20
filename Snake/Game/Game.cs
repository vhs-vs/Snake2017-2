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
        private Random rng = new Random();

        public void Start()
        {
            Snake = new Snake(Direction.East, new Point(10, 10));
            CreateFood();
            Over = false;
        }

        public void Tick()
        {
            Snake.Move();
            if (Snake.TestCollision(Food.Position))
            {
                Snake.Grow();
                CreateFood();
            }
            if (! new Rectangle(0, 0, 20, 20).Contains(Snake.Head))
            {
                Over = true;
            }
            if (Snake.Dead)
            {
                Over = true;
            }
        }

        private void CreateFood()
        {
            Food = new Food { Position = new Point(rng.Next(0, Width), rng.Next(0, Height)) };
            if (Snake.Body.Exists(p => p.Equals(Food.Position)))
            {
                CreateFood();
            }
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
