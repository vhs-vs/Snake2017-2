using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake.game
{
    class Food : GameObject
    {
        public Point Position { get; set; }

		public override bool Accept(GameVisitor visitor)
		{
			visitor.Visit(this);
			return true;
		}
	}
}
