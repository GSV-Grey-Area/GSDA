using System;
using System.Collections.Generic;
using System.Text;
using Pokemon;

namespace Pokemon
{
	[Serializable]
	public class Box
	{
		Pokemon[] box;
		Game g;
		IO io;

		public Box(Game g, IO io)
		{
			box = new Pokemon[30];
			this.g = g;
			this.io = io;
		}
	}
}
