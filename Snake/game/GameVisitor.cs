using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake.game
{
	abstract class GameVisitor
	{
		public abstract void Visit(Game game);
		public abstract void Visit(Food food);
		public abstract void Visit(Snake snake);
	}
}
