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
            Dead = false;
        }

        private int GrowCount = 0;

        public List<Point> Body { get; set; }
        /// <summary>
        /// aktuelle Bewegungsrichtung der Schlange
        /// </summary>
        public Direction Direction { get; private set; }

        /// <summary>
        /// Kopf der Schlange
        /// </summary>
        public Point Head => Body?.First() ?? Point.Empty;

        public bool Dead { get; private set; }

        public override bool Accept(GameVisitor visitor)
        {
            visitor.Visit(this);
            return true;
        }

        /// <summary>
        /// lässt die Schlange wachsen
        /// </summary>
        public void Grow()
        {
            GrowCount++;
        }

   

        /// <summary>
        /// Prüft ob der Kopf der Schlange mit einem Punkt im Spiel kollidiert
        /// </summary>
        public bool TestCollision(Point p)
        {
            return Head.Equals(p);
        }

        /// <summary>
        /// Die Schlange bewegt sich in die aktuelle Richtung um eine Position weiter
        /// </summary>
        public void Move()
        {
            Point newHead = new Point(Head.X, Head.Y);
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

            if (GrowCount > 0)
            {
                GrowCount--;
            }
            else
            {
                Body.Remove(Body.Last());
            }

            Dead = Body.Exists(p => p.Equals(newHead));

            Body.Insert(0, newHead);
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
