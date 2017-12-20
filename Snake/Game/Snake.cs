using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake.game
{
    public enum Direction { North, East, South, West}
    class Snake : GameObject
    {
        public Snake(Direction direction, Point start)
        {
            Direction = direction;
            Body = new List<Point>();
            Body.Add(start);
        }

        public List<Point> Body { get; set; }
        /// <summary>
        /// aktuelle Bewegungsrichtung der Schlange
        /// </summary>
        public Direction Direction { get; private set; }

		public override bool Accept(GameVisitor visitor)
		{
			visitor.Visit(this);
			return true;
		}

		/// <summary>
		/// Die Schlange bewegt sich in die aktuelle Richtung um eine Position weiter
		/// </summary>
		public void Move()
        {
            Point newHead = new Point(Body.First().X, Body.First().Y);
            switch (Direction)
            {
                case Direction.North: newHead.Y -= 1;
                    break;
                case Direction.East: newHead.X += 1;
                    break;
                case Direction.South: newHead.Y += 1;
                    break;
                case Direction.West: newHead.X -= 1;
                    break;
            }

            Body.Insert(0, newHead);
            Body.Remove(Body.Last());
        }

        public void TurnLeft()
        {
            switch (Direction)
            {
                case Direction.North:
                    Direction = Direction.West;
                    break;
                case Direction.East:
                    Direction = Direction.North;
                    break;
                case Direction.South:
                    Direction = Direction.East;
                    break;
                case Direction.West:
                    Direction = Direction.South;
                    break;
            }
        }

        public void TurnRight()
        {
            switch (Direction)
            {
                case Direction.North:
                    Direction = Direction.East;
                    break;
                case Direction.East:
                    Direction = Direction.South;
                    break;
                case Direction.South:
                    Direction = Direction.West;
                    break;
                case Direction.West:
                    Direction = Direction.North;
                    break;
            }
        }


    }
}
