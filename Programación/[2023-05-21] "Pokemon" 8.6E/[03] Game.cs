using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.IO;
using Pokemon;

using System.Linq;
using MySql.Data;
using MySqlConnector;

namespace Pokemon
{
	[Serializable]
	public class Game
	// Class of the game.
	{
		IO io;											// New object of the "IO" class.
		bool quickstart = false;
		bool graphical = true;
		bool release = true;
		string savePath = @"../../../Savefile.txt";		// Path of the save file.
		string exportPath = @"../../../PokemonExport.txt";

		Species[] species;								// Container of species information.
		int[] colors;									// Container of color information.
		Medicine[] medicine;							// Container of medicine information.
		PokeballItem[] pokeballs;						// Container of pokeball information.
		Treasure[] treasures;							// Container of treasure information.
		Move[] moves;									// Container of move information.
		MT[] mts;										// Container of training machine information.

		public Species GetSpecies(int i)
		{
			return species[i];
		}

		public void Run()
		// Main function.
		{
			this.species = io.DataLoaderSpecies();		// Loads species.
			this.colors = io.DataLoaderColors();		// Loads colors.
			this.medicine = io.DataLoaderMedicine();	// Loads medicines.
			this.pokeballs = io.DataLoaderPokeballs();	// Loads pokeballs.
			this.treasures = io.DataLoaderTreasures();	// Loads treasures.
			this.moves = io.DataLoaderMoves();			// Loads moves.
			this.mts = io.DataLoaderMTS(moves);			// Loads training machines.

			Species[] fireStoneCompatibleSpecies =
			{
				species[133],
				species[37],
				species[58]
			};

			Species[] waterStoneCompatibleSpecies =
			{
				species[61],
				species[90],
				species[120],
				species[133]
			};

			Species[] thunderStoneCompatibleSpecies =
			{
				species[25],
				species[133]
			};

			EvolutiveStone[] evolutiveStones = new EvolutiveStone[3]
			{
				new EvolutiveStone ("Piedra de fuego", fireStoneCompatibleSpecies),
				new EvolutiveStone("Piedra de agua", waterStoneCompatibleSpecies),
				new EvolutiveStone("Piedra de trueno", thunderStoneCompatibleSpecies)
			};

			if (graphical == true || release == true)
			{
				io.WindowResize(152, 50);
			}

			io.ColorTransfer(colors);

			// Canvas generation:
			Point[,,] array = new Point[95, 43, 2];
			for (int i = 0; i < array.GetLength(0); i++)
			{
				for (int j = 0; j < array.GetLength(1); j++)
				{
					if ((i + j) % 2 == 0)
					{
						array[i, j, 0] = new Point(5, 5, true);
					}
					else
					{
						array[i, j, 0] = new Point(1, 1, true);
					}
					array[i, j, 1] = new Point(2, 2, false);
				}
			}

			if (release == true)
			{
				io.BigFill(0, 0, 95, 43, 0, 0, array);

				io.BMPLoader(601, 1, 42, array);
				io.BMPLoader(602, 41, 42, array);
				io.BMPLoader(603, 52, 42, array);
				io.BMPLoader(400, 65, 24, array);
				io.BMPLoader(RandomExternal.GenerateRandomInt(1, 10), 65, 25, array);

				io.Render(array);
			}

			Player player;
			Team team;
			Bag bag = null;
			int res = 1;

			if (File.Exists(savePath))
			{
				player = (Player)io.Load(savePath);
				team = player.GetTeam();
				bag = player.GetBag();
				//team2 = player.GetTeam2();
				//Console.WriteLine("Entra");
			}
			else
			{
				if (quickstart == false)
				{
					if (graphical == true)
					{
						io.Clean(array);							// Clears the canvas.
						io.BigFill(0, 15, 50, 30, 2, 1, array);		// Wall.
						io.BigFill(0, 0, 50, 15, 14, 2, array);		// Floor.
						io.BigFill(30, 20, 40, 29, 10, 3, array);	// Window.
						io.ColorLoad(9, 21, 4, array, graphics);	// Shadow.
						io.ColorLoad(0, 20, 25, array, graphics);	// Professor.
						io.Render(array);
					}

					// Test.
					/* io.BMPLoader(400, 5, 24, array);
					io.BMPLoader(1, 5, 25, array);

					io.BMPLoader(400, 25, 24, array);
					io.BMPLoader(2, 25, 25, array);

					io.BMPLoader(400, 45, 24, array);
					io.BMPLoader(9, 45, 25, array); */

					io.WriteLine("Hola");
					io.Dialogue("Bienvenido a un juego de Pokemon.");
					io.WriteLine("");
				}

				if (graphical == true)
				{
					io.Clean(array);							// Clears the canvas.
					io.BigFill(0, 15, 50, 30, 2, 1, array);		// Wall.
					io.BigFill(0, 0, 50, 15, 14, 2, array);		// Floor.
					io.BigFill(3, 20, 25, 29, 10, 3, array);	// Window.
					io.ColorLoad(9, 2, 6, array, graphics);		// Pokémon in order, with their shadows etc.
					io.ColorLoad(2, 2, 15, array, graphics);

					io.ColorLoad(9, 15, 6, array, graphics);
					io.ColorLoad(4, 15, 15, array, graphics);

					io.ColorLoad(9, 28, 6, array, graphics);
					io.ColorLoad(6, 28, 15, array, graphics);

					io.ColorLoad(9, 39, 4, array, graphics);	// Professor.
					io.ColorLoad(0, 38, 25, array, graphics);
				}

				// To do: It would be interesting to have a function that automatically determined the shadow's position.
				// Possibly even an intermediate function which would allow the main code's to contain only the image and its position.

				if (graphical == true)
				{
					io.Render(array);
				}

				string pokemonName = "Primer pokémon";
				if (quickstart == false)
				{
					io.WriteLine("¿Qué Pokémon eliges?");
					res = (int)io.ReadLine()[0] - 48;
					io.WriteLine("¿Qué nombre le pones?");
					pokemonName = io.ReadLine();
				}

				team = new Team(this, io);

				Box[] box = new Box[32];
				for (int i = 0; i < box.GetLength(0); i++)
				{
					box[i] = new Box(this, io);
				}

				Inventory[] pockets = new Inventory[7];
				pockets[0] = new Inventory(this, io, "Bolsillo de los botiquines");
				pockets[1] = new Inventory(this, io, "Bolsillo de las Pokéballs");
				pockets[2] = new Inventory(this, io, "Bolsillo de los objetos de combate");
				pockets[3] = new Inventory(this, io, "Bolsillo de los movimientos");
				pockets[4] = new Inventory(this, io, "Bolsillo de los tesoros");
				pockets[5] = new Inventory(this, io, "Bolsillo de los objetos clave");
				pockets[6] = new Inventory(this, io, "Bolsillo para las demás cosas");

				bag = new Bag(this, io, pockets);

				player = CreatePlayer(team, box, bag);
				player.TransferMoney(101000);

				//player.AddItem(pokeballs[0], 1);
				//player.AddItem(mts[4], 1);

				team.GeneratePokemon(res - 1, pokemonName);
				team.GetPokemon(0).SetEO(player);
				team.GetPokemon(0).AddMove(moves[0]);
				team.GetPokemon(0).AddMove(moves[1]);
				team.GetPokemon(0).AddMove(moves[5]);
			}

			Inventory inventory = new Inventory(this, io, "Inventario de la tienda");
			Shop shop = new Shop(this, io, inventory);

			shop.AddItem(medicine[0], 100, shop.GetAmount(medicine[0]));
			shop.AddItem(pokeballs[0], 100, shop.GetAmount(pokeballs[0]));
			shop.AddItem(treasures[0], 100, shop.GetAmount(treasures[0]));

			// Generation of the wild pokémon. This should be random:
			Pokemon newpokemon2 = new Pokemon(species[2], "Pokémon salvaje", RandomExternal.GenerateRandom(0, 1), io);
			newpokemon2.AddMove(moves[0]);

			// It may be good to have the rival pokemon be generated at the start of combat, to cut a healing line.

			while (0 == 0)
			// Infinite loop.
			{
				if (graphical == true)
				{
					io.BigFill(0, 15, 50, 30, 10, 11, array);		// Sky.
					io.BigFill(0, 0, 50, 15, 12, 0, array);			// Land.
					io.ColorLoad(9, 20, 6, array, graphics);		// Shadow.
					io.ColorLoad(res * 2, 20, 15, array, graphics);	// Chosen pokemon.
					io.Render(array);
				}

				io.WriteLine("Menú principal");
				io.WriteLine("\t1) Datos");
				io.WriteLine("\t2) Equipo");
				io.WriteLine("\t3) Combate");
				io.WriteLine("\t4) Mochila");
				io.WriteLine("\t5) Tienda");
				io.WriteLine("\t6) Centro Pokémon");
				io.WriteLine("\t7) Cajas");
				io.WriteLine("\t8) Salir del juego");
				io.WriteLine("\t9) Exportar información");
				io.WriteLine("");

				int main_option = int.Parse(io.ReadLine());
				io.WriteLine("");
				switch (main_option)
				// Main menu.
				{
					case 1:
						// Data.
						player.PlayerData();
						break;

					case 2:
						// Lists the team.
						team.List();
						break;

					case 3:
						// Fight.
						Pokemon[] fighters = {team.GetPokemon(0), newpokemon2};
						Fight(fighters, colors, array, res, team, moves, player, io);
						break;

					case 4:
						// Bag.
						bag.ExperimentalList();
						break;

					case 5:
						// Shop.
						io.WriteLine("Tienda");
						io.WriteLine("Objetos a la venta:");
						shop.List();

						io.WriteLine("¿Quieres comprar, o vender? (c/v)");
						string choice = io.ReadLine();
						if (choice.ToLower()[0] == 'c')
						{
							io.WriteLine("¿Qué quieres comprar?");
							int choice2 = int.Parse(io.ReadLine());
							io.WriteLine("¿Cuántas unidades?");
							int choice3 = int.Parse(io.ReadLine());
							Buy(shop.GetInventory()[choice2], choice3, player, shop);
						}
						else
						{
							Sell(pokeballs[0], 1, player, shop);
						}
						io.WriteLine("");
						break;

					case 6:
						// Pokémon Center.
						if (graphical == true)
						{
							io.Clean(array);
							io.BigFill(0, 0, 50, 30, 10, 10, array);	// Background
							for (int i = 1; i < 30; i = i + 2)
							// Generates a background texture consisting of concentric circumferences.
							{
								io.Circumference(25, 15, i, array);
							}
							io.ColorLoad(1, 20, 25, array, graphics);	// Joy nurse.
							io.ColorLoad(8, 35, 13, array, graphics);	// Egg pokemon.
							io.Render(array);
						}

						io.WriteLine("Bienvenido al centro Pokémon");
						io.Dialogue("Curando...");

						for(int i = 0; i < team.GetTeamSize(); ++i)
						{
							if (team.CheckPokemon(i) == true)
							{
								team.GetPokemon(i).SetHealth(team.GetPokemon(i).GetSpecies().GetBHP()); // Heals both pokémon.
								team.GetPokemon(i).SetPP(team.GetPokemon(i).GetSpecies().GetBPP());     // Recovers PP.
							}
						}

						newpokemon2.SetHealth(newpokemon2.GetSpecies().GetBHP());
						newpokemon2.SetPP(newpokemon2.GetSpecies().GetBPP());
						io.WriteLine("");
						io.WriteLine("Pokémon curado.");
						break;

					case 7:
						// Boxes (to do).
						io.WriteLine("Aquí habría cajas.");
						break;

					case 8:
						// Game exit with the option to save.
						io.WriteLine("¿Quieres guardar la partida? (s/n/c)");
						char check = io.ReadLine()[0];

						switch (check)
						{
							case 's':
								io.Save(player, savePath);
								return;
							case 'n':
								return; // Exits the game.
							default:
								break;
						}
						break;

					case 9:
						// Game exportation.
						io.Export(player, exportPath);
						break;

					default:
						break;
				}
			}
		}

		public Point[,,] Data(Pokemon npoke1, Point[,,] array)
		// Shows the player's pokemon's data.
		{
			char sex_symbol = (char)9794;
			if (npoke1.GetSex() == true)
			{
				sex_symbol = (char)9792;
			}

			if (graphical == true)
			{
				io.LoadText(35, 15, array, npoke1.GetSpecies().GetSpeciesName() + " \"" + npoke1.GetName() + "\" " + sex_symbol);
				io.LoadText(35, 13, array, "Salud: " + npoke1.GetHealth() + "/" + npoke1.GetSpecies().GetBHP());
				io.LoadText(35, 11, array, "Ataque: " + npoke1.GetSpecies().GetATK());
				io.LoadText(35, 9, array, "Defensa: " + npoke1.GetSpecies().GetDEF());
				io.LoadText(35, 7, array, "Velocidad: " + npoke1.GetSpecies().GetSpeed());
				io.LoadText(35, 5, array, "Altura: " + npoke1.GetSpecies().GetHeight());
				io.LoadText(35, 3, array, "Peso: " + npoke1.GetSpecies().GetWeight());
				io.LoadText(35, 1, array, "Fecha de captura: " + npoke1.GetCapTime());
			}
			else
			{
				io.WriteLine(npoke1.GetSpecies().GetSpeciesName() + "\"" + npoke1.GetName() + "\" " + sex_symbol);
				io.WriteLine("\tSalud: " + npoke1.GetHealth() + "/" + npoke1.GetSpecies().GetBHP());
				io.WriteLine("\tAtaque: " + npoke1.GetSpecies().GetATK());
				io.WriteLine("\tDefensa: " + npoke1.GetSpecies().GetDEF());
				io.WriteLine("\tVelocidad: " + npoke1.GetSpecies().GetSpeed());
				io.WriteLine("\tAltura: " + npoke1.GetSpecies().GetHeight());
				io.WriteLine("\tPeso: " + npoke1.GetSpecies().GetWeight());
				if (npoke1.GetCapTime().Year != 0001)
				{
					io.WriteLine("\tFecha de captura: " + npoke1.GetCapTime());
				}
				io.WriteLine("");
			}
			
			return array;
		}

		public void FightData(Pokemon npoke1, Pokemon npoke2)
		// Shows data during the combat.
		{
			io.WriteLine(npoke1.GetSpecies().GetSpeciesName() + " \"" + npoke1.GetName() + "\" \t\t" + npoke2.GetSpecies().GetSpeciesName() + "");
			io.WriteLine("Salud: " + npoke1.GetHealth() + "/" + npoke1.GetSpecies().GetBHP() + "\t\t\tSalud: " + npoke2.GetHealth() + "/" + npoke2.GetSpecies().GetBHP());
			io.WriteLine("PP: " + npoke1.GetPP() + "/" + npoke1.GetSpecies().GetBPP() + "\t\t\t\tPP: " + npoke2.GetPP() + "/" + npoke2.GetSpecies().GetBPP());
			return;
		}

		public Pokemon[] Fight(Pokemon[] fighters, int[] colors, Point[,,] array, int res, Team team2, Move[] moves, Player player, IO io)
		// Fight.
		{
			int option;

			while (fighters[0].GetHealth() > 0 && fighters[1].GetHealth() > 0)
			{
				if (fighters[0].GetSpecies().GetSpeed() < fighters[1].GetSpecies().GetSpeed())
				// Determines which pokemon is faster.
				{
					io.WriteLine(fighters[0].GetName());
					io.MirrorMatrix(fighters);
					io.WriteLine(fighters[0].GetName());
					Move.Act(fighters, moves[0]);
					io.MirrorMatrix(fighters);
				}

				if (graphical == true)
				{
					io.Clean(array);
					io.BigFill(0, 15, 50, 30, 10, 11, array);
					io.BigFill(0, 0, 50, 15, 12, 0, array);
					io.ColorLoad(9, 35, 15, array, graphics);
					io.ColorLoad(2, 35, 25, array, graphics);
					io.LoadBig(9, 9, 7, array, graphics); // Simulates perspective by making the player's pokemon bigger.
					io.LoadBig(res * 2 + 1, 5, 25, array, graphics);
					io.Render(array);
				}

				FightData(fighters[0], fighters[1]);

				io.WriteLine("1) Atacar");
				io.WriteLine("2) Cambiar de Pokémon(no funcional)");
				io.WriteLine("3) Capturar");
				io.WriteLine("4) Escapar");

				io.Write("¿Opción? ");
				option = int.Parse(io.ReadLine());

				// To do: "Damage" function to extract code from here?
				// Possibly make a "Generic attack" function.

				int attempts = 0;
				switch (option)
				{
					case 1:
						io.WriteLine("¿Qué movimiento quieres usar?");
						fighters[0].ListMoves();
						int move = int.Parse(io.ReadLine());

						fighters=Move.Act(fighters, fighters[0].GetMove(move));
						break;
					case 2:
						io.WriteLine("Opción no disponible."); // ...
						break;
					case 3:
						// Turn into "Bag" menu.
						for (int i = 0; i < 4; i++)
						// In the "Modified capture ratio" formula, 1024 seems to give better results than 4096.
						{
							if (graphical == true)
							{
								io.Clean(array);
								io.BigFill(0, 15, 50, 30, 10, 11, array);
								io.BigFill(0, 0, 50, 15, 12, 0, array);
								io.ColorLoad(9, 35, 15, array, graphics);
								io.ColorLoad(10, 35, 20, array, graphics); // Pokéball.
								io.Render(array);
							}

							float rand2 = RandomExternal.GenerateRandom(0, 65535);
							float rcm = (((3 * fighters[1].GetSpecies().GetBHP()) - (2 * fighters[1].GetHealth())) * 1024 * fighters[1].GetSpecies().GetCapRatio()) / (3 * fighters[1].GetSpecies().GetBHP());
							double ag = (65536) / (Math.Pow((255 / rcm), 0.1875));
							if (rand2 >= ag)
							{
								io.WriteLine("El pokémon salvaje ha escapado.");
								return fighters;
							}
							Thread.Sleep(500);
						}

						if (graphical == true)
						{
							io.Clean(array);
							io.BigFill(0, 15, 50, 30, 10, 11, array);
							io.BigFill(0, 0, 50, 15, 12, 0, array);
							io.ColorLoad(9, 35, 15, array, graphics);
							io.ColorLoad(10, 35, 20, array, graphics);
						}

						io.WriteLine("El pokémon salvaje ha sido capturado.");

						fighters[1].SetCapTime(DateTime.Now);
						fighters[1].SetEO(player);
						team2.AddPokemon(fighters[1]);
						return fighters;
					case 4:
						attempts++; // Escape.
						float rand3 = RandomExternal.GenerateRandom(0, 255);
						float escape_odds = (((fighters[0].GetSpecies().GetSpeed() * 128) / (fighters[0].GetSpecies().GetSpeed())) + 30 * attempts) % 256;
						if (rand3 < escape_odds)
						{
							io.WriteLine("Escapas");
							return fighters;
						}
						io.WriteLine("No escapas");
						break;
					default:
						break;
				}

				if (fighters[0].GetSpecies().GetSpeed() > fighters[1].GetSpecies().GetSpeed())
				// Determines which pokemon is faster.
				// The wild pokemon's response:
				{
					io.MirrorMatrix(fighters);
					Move.Act(fighters, moves[0]);
					io.MirrorMatrix(fighters);
				}
			}
			if (fighters[0].GetHealth() == 0)
			{
				io.WriteLine("Has sido derrotado. Recupera a tu pokémon en el centro pokémon.");
			}
			else if (fighters[1].GetHealth() == 0)
			{
				io.WriteLine("Has ganado.");
			}
			option = 2;
			return fighters;
		}

		public Game(IO newio)
		// Constructor with one parameter.
		{
			io = newio;
		}

		public Game(IO newio, bool n_quickstart)
		// Constructor with two parameters.
		{
			io = newio;
			quickstart = n_quickstart;
		}

		public Player CreatePlayer(Team team, Box[] box, Bag bag)
		{
			string playerName = "Nuevo jugador";
			if (quickstart == false)
			{
				io.WriteLine("¿Cómo te llamas?");
				playerName = io.ReadLine();
			}

			bool playerSex = false;
			if (quickstart == false)
			{
				io.WriteLine("¿Eres chico o chica?");
				string answer = io.ReadLine();
				if (answer.ToLower() == "chica")
				{
					playerSex = true;
				}
			}

			string numericalID = 0 + RandomExternal.RandomNumericalString(8, 0, 9);
			string secretNumber = RandomExternal.RandomNumericalString(9, 0, 9);

			System.DateTime startTime = DateTime.Now;

			// Create boxes, assign boxes.
			Player player = new Player(playerName, playerSex, numericalID, secretNumber, startTime, team, box, bag, io);
			return player;
		}

		public void Buy(Item item, int amount, Player player, Shop shop)
		{
			io.WriteLine("Compra: " + item.GetName() + " (" + amount + ")");
			int origAmountA = player.GetAmount(item);
			int origAmountB = shop.GetAmount(item);

			if (shop.GetAmount(item) > 0)
			{
				player.AddItem(item, amount, origAmountA);
				shop.RemoveItem(item, amount, origAmountB);
			}
			else
			{
				io.WriteLine("Ya no quedan.");
			}
		}

		public void Sell(Item item, int amount, Player player, Shop shop)
		{
			if (player.GetAmount(item) > 0)
			{
				player.RemoveItem(item, amount);
				shop.AddItem(item, amount, shop.GetAmount(item));
			}
			else
			{
				io.WriteLine("Ya no te quedan.");
			}
		}

		Array[] graphics = new Array[11]
		// Image-containing-matrix matrix.
		// To do: Possibly separate the images by type.
		// To do: Integrate the ".bmp" interpreter.
		{
			new string[24, 12]
			// String matrix (Professor Oak).
			{
				{"  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  "},
				{"  ", "  ", "2?", "2?", "2?", "2?", "2?", "2?", "  ", "  ", "  ", "  "},
				{"  ", "  ", "2?", "?5", "12", "?5", "12", "?5", "  ", "  ", "  ", "  "},
				{"  ", "  ", "  ", "?5", "22", "?5", "22", "?5", "  ", "  ", "  ", "  "},
				{"  ", "  ", "  ", "?5", "?5", "?5", "?5", "?5", "  ", "  ", "  ", "  "},
				{"  ", "  ", "  ", "  ", "?5", "?5", "?5", "  ", "  ", "  ", "  ", "  "},
				{"  ", "  ", "33", "33", "55", ">5", "55", "33", "33", "  ", "  ", "  "},
				{"  ", "  ", "33", "33", "55", "55", "55", "33", "33", "  ", "  ", "  "},
				{"  ", "33", "33", "33", "55", "55", "55", "33", "33", "33", "  ", "  "},
				{"  ", "33", "33", "33", "55", "55", "55", "33", "33", "33", "  ", "  "},
				{"  ", "33", "33", "33", "55", "55", "55", "33", "33", "33", "  ", "  "},
				{"  ", "33", "33", "33", "00", "00", "00", "33", "33", "33", "  ", "  "},
				{"  ", "23", "33", "33", ">>", ">>", ">>", "33", "33", "23", "  ", "  "},
				{"  ", "  ", "33", "33", ">>", ">>", ">>", "33", "33", "  ", "  ", "  "},
				{"  ", "  ", "33", "33", ">>", ">>", ">>", "33", "33", "  ", "  ", "  "},
				{"  ", "  ", "33", "33", ">>", "22", ">>", "33", "33", "  ", "  ", "  "},
				{"  ", "  ", "33", "33", ">>", "22", ">>", "33", "33", "  ", "  ", "  "},
				{"  ", "  ", "33", "33", ">>", "22", ">>", "33", "33", "  ", "  ", "  "},
				{"  ", "  ", "  ", ">>", ">>", "  ", ">>", ">>", "  ", "  ", "  ", "  "},
				{"  ", "  ", "  ", ">>", ">>", "  ", ">>", ">>", "  ", "  ", "  ", "  "},
				{"  ", "  ", "  ", ">>", ">>", "  ", ">>", ">>", "  ", "  ", "  ", "  "},
				{"  ", "  ", "  ", ">>", ">>", "  ", ">>", ">>", "  ", "  ", "  ", "  "},
				{"  ", "  ", "  ", "0>", "0>", "  ", "0>", "0>", "  ", "  ", "  ", "  "},
				{"  ", "  ", "  ", "0>", "0>", "  ", "0>", "0>", "  ", "  ", "  ", "  "},
			},

			new string[24, 12]
			// Joy nurse.
			{
				{"  ", "  ", "  ", "22", "33", "44", "33", "22", "  ", "  ", "  ", "  "},
				{"  ", "  ", "  ", "22", "44", "44", "44", "22", "  ", "  ", "  ", "  "},
				{"  ", "  ", "  ", "22", "33", "44", "33", "22", "  ", "  ", "  ", "  "},
				{"  ", "  ", "  ", "53", "53", "53", "53", "53", "  ", "  ", "  ", "  "},
				{"  ", "  ", "  ", "53", "?5", "?5", "?5", "53", "  ", "  ", "  ", "  "},
				{"  ", "  ", "53", "?5", "88", "?5", "88", "?5", "53", "  ", "  ", "  "},
				{"  ", "52", "  ", "?5", "?5", "?5", "?5", "?5", "  ", "52", "  ", "  "},
				{"  ", "  ", "51", "50", "?5", "?5", "?5", "50", "51", "  ", "  ", "  "},
				{"  ", "  ", "53", "33", "53", "53", "53", "33", "53", "  ", "  ", "  "},
				{"  ", "  ", "?5", "33", "33", "33", "33", "33", "?5", "  ", "  ", "  "},
				{"  ", "  ", "?5", "33", "32", "32", "32", "33", "?5", "  ", "  ", "  "},
				{"  ", "  ", "  ", "?5", "32", "32", "32", "?5", "  ", "  ", "  ", "  "},
				{"  ", "  ", "33", "?5", "33", "33", "33", "?5", "33", "  ", "  ", "  "},
				{"  ", "  ", "33", "33", "?5", "33", "?5", "33", "33", "  ", "  ", "  "},
				{"  ", "  ", "33", "33", "?5", "33", "?5", "33", "33", "  ", "  ", "  "},
				{"  ", "33", "33", "33", "33", "?5", "33", "33", "33", "33", "  ", "  "},
				{"  ", "33", "33", "33", "33", "33", "33", "33", "33", "33", "  ", "  "},
				{"  ", "33", "33", "33", "33", "33", "33", "33", "33", "33", "  ", "  "},
				{"  ", "  ", "  ", "?5", "?5", "  ", "?5", "?5", "  ", "  ", "  ", "  "},
				{"  ", "  ", "  ", "?5", "?5", "  ", "?5", "?5", "  ", "  ", "  ", "  "},
				{"  ", "  ", "  ", "?5", "?5", "  ", "?5", "?5", "  ", "  ", "  ", "  "},
				{"  ", "  ", "  ", "?5", "?5", "  ", "?5", "?5", "  ", "  ", "  ", "  "},
				{"  ", "  ", "  ", "33", "33", "  ", "33", "33", "  ", "  ", "  ", "  "},
				{"  ", "  ", "  ", "33", "33", "  ", "33", "33", "  ", "  ", "  ", "  "},
			},

			new string[12, 12]
			// Squirtle, front view.
			{
				{"  ", "  ", "  ", ";3", ";3", ";3", "  ", "  ", "  ", "  ", "  ", "  "},
				{"  ", "  ", ";3", "3;", ";;", "3;", ";3", "  ", "  ", "  ", "  ", "  "},
				{"  ", "  ", ";;", "70", ";;", "70", ";;", "  ", "  ", "  ", "  ", "  "},
				{"  ", "  ", ";9", ";9", ";9", ";9", ";9", "  ", "  ", "  ", "  ", "  "},
				{"  ", "  ", "33", ";8", ";8", ";8", "38", "  ", "  ", "  ", "  ", "  "},
				{"  ", "33", ";3", "??", "??", "??", ";3", "38", "  ", "  ", ":9", "  "},
				{"  ", ";;", ";;", "?>", "?>", "?>", ";;", ";;", "38", ":0", ":9", ":9"},
				{";;", ";;", ">>", ">?", ">?", ">?", ">>", ";;", ";;", ":9", ":9", ":9"},
				{"  ", "39", ">>", ">>", ">>", ">>", ">>", "39", ";0", ":9", ":9", ":9"},
				{"  ", "  ", ";;", ">0", ">0", ">0", ";;", ";0", ":0", ":0", ":9", "  "},
				{"  ", ";;", ";;", "  ", "  ", "  ", ";;", ";;", "  ", "  ", "  ", "  "},
				{";3", ";;", "  ", "  ", "  ", "  ", "  ", ";;", ";3", "  ", "  ", "  "},
			},

			new string[12, 12]
			// Squirtle, rear view.
			{
				{"  ", "  ", "  ", "  ", "  ", "  ", ";9", ";9", ";;", "  ", "  ", "  "},
				{"  ", "  ", "  ", "  ", "  ", ";9", ";9", ";9", ";;", ";;", "  ", "  "},
				{"  ", "  ", "  ", "  ", "  ", ";9", ";9", ";9", ";;", ";;", "  ", "  "},
				{"  ", "  ", "  ", "  ", "  ", ";9", ";9", ";9", ";;", ";;", "  ", "  "},
				{"  ", "  ", "  ", "  ", "  ", "33", "33", "33", "33", ";;", "  ", "  "},
				{"  ", ";;", "  ", "  ", "33", "??", "??", "??", "??", "33", ";;", "  "},
				{";;", ";;", ";;", ";;", "33", "?5", "?5", "?5", "?5", "33", ";9", "  "},
				{";;", ";;", ";;", ";;", ";;", "5?", "5?", "5?", "5?", "33", ";9", ";9"},
				{";9", ";;", ";;", ";;", ";;", ";;", "5>", "5>", "5>", "33", ";;", "  "},
				{"  ", ";9", ";9", ";9", ";9", ";9", ";9", "33", "33", ";9", "  ", "  "},
				{"  ", "  ", "  ", "  ", ";;", ";9", "  ", "  ", "  ", ";;", ";9", "  "},
				{"  ", "  ", "  ", ";;", ";9", "  ", "  ", "  ", "  ", "  ", ";;", ";9"},
			},

			new string[12, 12]
			// Charmander, front view.
			{
				{"  ", "  ", "  ", "43", "43", "43", "  ", "  ", "  ", "  ", "  ", "  "},
				{"  ", "  ", "43", "34", "4?", "34", "43", "  ", "  ", "  ", "  ", "  "},
				{"  ", "  ", "4?", "80", "4?", "80", "4?", "  ", "  ", "  ", "?3", "  "},
				{"  ", "  ", "4>", "4>", "4>", "4>", "4>", "  ", "  ", "34", "43", "3?"},
				{"  ", "  ", "  ", "4>", "4>", "4>", "  ", "  ", "  ", "43", "33", "43"},
				{"  ", "  ", "4?", "4?", "4?", "4?", "4?", "  ", "  ", "44", "44", "??"},
				{"  ", "4?", "4?", "?>", "?>", "?>", "4?", "4?", "  ", "  ", "40", "  "},
				{"?4", "4?", ">>", ">?", ">?", ">?", ">>", "4?", "?4", "4>", ">0", "  "},
				{"  ", "  ", ">>", ">>", ">>", ">>", ">>", "4>", "4>", ">0", "  ", "  "},
				{"  ", "  ", "4?", ">0", ">0", ">0", "4?", ">0", ">0", "  ", "  ", "  "},
				{"  ", "4?", "4?", "  ", "  ", "  ", "4?", "4?", "  ", "  ", "  ", "  "},
				{"??", "4?", "?4", "  ", "  ", "  ", "??", "4?", "?4", "  ", "  ", "  "},
			},

			new string[12, 12]
			// Charmander, rear view.
			{
				{"  ", "  ", "  ", "  ", "  ", "  ", "43", "43", "43", "  ", "  ", "  "},
				{"  ", "  ", "  ", "  ", "  ", "43", "43", "43", "43", "43", "  ", "  "},
				{"  ", "?3", "  ", "  ", "  ", "4?", "4?", "4?", "4?", "4?", "  ", "  "},
				{"3?", "43", "34", "  ", "  ", "4>", "4?", "4?", "4?", "4>", "  ", "  "},
				{"43", "33", "43", "  ", "  ", "  ", "4>", "4>", "4>", "  ", "  ", "  "},
				{"??", "44", "44", "  ", "  ", "4?", "4?", "4?", "4?", "4?", "  ", "  "},
				{"  ", "40", "  ", "  ", "4?", "4?", "4?", "4?", "4?", "4?", "4?", "  "},
				{"  ", ">0", "4>", "?4", "4?", "4?", "4?", "4?", "4?", ">>", "4?", "?4"},
				{"  ", "  ", ">0", "4>", "4>", "4?", "4?", "4?", "4?", ">>", "  ", "  "},
				{"  ", "  ", "  ", ">0", ">0", ">0", ">0", ">0", ">0", "4?", "  ", "  "},
				{"  ", "  ", "  ", "  ", "4?", "4?", "  ", "  ", "  ", "4?", "4?", "  "},
				{"  ", "  ", "  ", "?4", "4?", "??", "  ", "  ", "  ", "?4", "4?", "??"},
			},

			new string[12, 12]
			// Bulbasaur, front view.
			{
				{"  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  "},
				{"  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  "},
				{"  ", "  ", "  ", "  ", "  ", "  ", "  ", "<<", "  ", "  ", "  ", "  "},
				{"  ", "  ", "  ", "  ", "  ", "<3", "<3", "<<", "<0", "  ", "  ", "  "},
				{"<0", "  ", "  ", "<<", "<3", "<0", "<<", "<0", "<<", "<<", "  ", "  "},
				{"=0", "=;", "=;", "=;", "=;", "=0", "<0", "<<", "<<", "<0", "<<", "  "},
				{"=;", "33", "=;", "=;", "33", "=;", "<0", "<0", "<0", "<<", "<<", "  "},
				{"=9", "44", "=;", "=;", "44", "=9", "<<", "<<", "<0", "<0", "<0", "  "},
				{"=8", "=9", "=9", "=9", "=9", "=8", "<<", "<<", "<<", "<0", "  ", "  "},
				{"  ", "=8", "=8", "=8", "=8", "<<", "<<", "<<", "<<", "  ", "  ", "  "},
				{"  ", "<<", "<0", "<0", "<<", "<<", "<0", "<0", "<<", "<<", "  ", "  "},
				{"<3", "<<", "  ", "  ", "<3", "<3", "0<", "0<", "  ", "<3", "<3", "  "},
			},

			new string[12, 12]
			// Bulbasaur, rear view.
			{
				{"  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  "},
				{"  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  "},
				{"  ", "  ", "  ", "  ", "=;", "  ", "  ", "  ", "  ", "  ", "  ", "  "},
				{"  ", "  ", "  ", "=;", "<<", "<3", "<3", "  ", "  ", "  ", "  ", "  "},
				{"  ", "  ", "=;", "<<", "<0", "<<", "<0", "<3", "<<", "  ", "  ", "<0"},
				{"  ", "=;", "<0", "<<", "<<", "<0", "=0", "<<", "<<", "=;", "=;", "=0"},
				{"  ", "=;", "<<", "<0", "<0", "<0", "<<", "<<", "<<", "=;", "=;", "=;"},
				{"  ", "<0", "<0", "<0", "<<", "<<", "=9", "<<", "<0", "=;", "=;", "=9"},
				{"  ", "  ", "<0", "<0", "<0", "<0", "=8", "<0", "=9", "=9", "=9", "=8"},
				{"  ", "  ", "  ", "<<", "<<", "<<", "<<", "=8", "=8", "=8", "=8", "  "},
				{"  ", "  ", "<<", "<<", "<0", "<0", "<<", "<<", "<0", "<0", "<<", "  "},
				{"  ", "<3", "<3", "  ", "  ", "0<", "<3", "<3", "  ", "  ", "<<", "<3"},
			},

			new string[12, 12]
			// Egg pokemon.
			{
				{"  ", "  ", "  ", "  ", "53", "53", "53", "52", "  ", "  ", "  ", "  "},
				{"  ", "  ", "  ", "53", "53", "53", "53", "53", "52", "  ", "  ", "  "},
				{"  ", "  ", "53", "53", "53", "53", "53", "53", "53", "52", "  ", "  "},
				{"  ", "55", "53", "53", "00", "53", "53", "00", "53", "52", "55", "  "},
				{"55", "53", "53", "53", "53", "53", "53", "53", "53", "53", "52", "55"},
				{"  ", "53", "53", "53", "53", "53", "53", "53", "53", "53", "52", "  "},
				{"  ", "53", "53", "53", "53", "35", "35", "53", "53", "53", "52", "  "},
				{"  ", "53", "53", "53", "35", "35", "35", "35", "53", "53", "52", "  "},
				{"  ", "53", "53", "53", "25", "25", "25", "25", "53", "53", "52", "  "},
				{"  ", "  ", "53", "53", "53", "25", "25", "53", "53", "52", "  ", "  "},
				{"  ", "  ", "  ", "53", "53", "53", "53", "53", "52", "  ", "  ", "  "},
				{"  ", "  ", "51", "51", "  ", "  ", "  ", "  ", "51", "51", "  ", "  "},
			},

			new string[5, 9]
			// Shadow.
			{
				{"  ", "  ", "  ", "12", "12", "12", "  ", "  ", "  "},
				{"  ", "12", "12", "11", "11", "11", "12", "12", "  "},
				{"12", "12", "11", "10", "10", "10", "11", "12", "12"},
				{"  ", "12", "12", "11", "11", "11", "12", "12", "  "},
				{"  ", "  ", "  ", "12", "12", "12", "  ", "  ", "  "},
			},

			new string[5, 5]
			// Pokéball.
			{
				{"  ", "44", "44", "44", "  "},
				{"44", "44", "00", "44", "44"},
				{"00", "00", "33", "00", "00"},
				{"33", "33", "00", "33", "33"},
				{"  ", "33", "33", "33", "  "},
			}
		};
	}
}
