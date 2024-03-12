using System; // Not sure what this is.
using System.Threading; // This may be a function of "System".
using System.IO; // For file input and output.

namespace Pokemon // "Pokemon" name space? Could be.
{
	class Program
	// Main class of the program.
	// To do: Separation of this file into a number of files, if advantageous.
	{
		static void Main() // Main and only function of the program.
		{
			IO io = new IO();
			Game g = new Game(io, true); // Creates an object of the "Game" class and absorbs the "io" object of the "IO" class along with its functions and everything else?
			g.Run(); // Executes the startup function of the "g" object of the "Game" class.
		}
	}
}
