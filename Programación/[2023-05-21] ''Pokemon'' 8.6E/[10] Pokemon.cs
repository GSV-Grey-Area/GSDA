using System;
using System.Collections.Generic;
using System.Text;
using Pokemon;

namespace Pokemon
{
	[Serializable]
	public class Pokemon
	// "Pokemon" class as a "heir" class to "Species".
	{
		IO io;
		Move[] moves = new Move[4];
		Species myspecies;
			public Species GetSpecies()
			{
				return myspecies;
			}

		string name;
		// Pokemon's name.
			public void SetName(string n_name)
			{
				name = n_name;
			}
			public string GetName()
			{
				return name;
			}

		bool sex;
		// Pokemon's sex.
			public void SetSex(float random)
			{
				if (random < this.GetSpecies().GetSexRatio())
				{
					sex = true;
				}
			}
			public bool GetSex()
			{
				return sex;
			}

			public char GetSexChar()
			{
				char sex_symbol = (char)9794;
				if (this.GetSex() == true)
				{
					sex_symbol = (char)9792;
				}
				return sex_symbol;
			}

		int health;
		// Pokemon's health.
			public void SetHealth(int n_health)
			{
				health = n_health;
			}
			public int GetHealth()
			{
				return health;
			}

		// Capture date:
		System.DateTime cap_time;
			public void SetCapTime(System.DateTime n_cap_time)
			{
				cap_time = n_cap_time;
			}
			public System.DateTime GetCapTime()
			{
				return cap_time;
			}

		int level;
		string[] eo;

		public void SetEO(Player player)
		{
			if(eo == null)
			{
				eo = new string[4];
				eo[0] = player.GetName();
				eo[1] = player.GetSex();
				eo[2] = player.GetID();
				eo[3] = player.GetSecretNumber();
			}
			return;
		}

		public string GetEO()
		{
			return eo[0];
		}

		int pp;
			public void SetPP(int nPP)
			{
				this.pp = nPP;
			}
			public int GetPP()
			{
				return pp;
			}

		public Pokemon
		// Constructor? The weight and the height should be random.
		(
			Species nspecies,
			string n_name,
			float random,
			IO n_io
		)
		{
			SetName(n_name);
			this.myspecies = nspecies;
			SetSex(random);
			this.io = n_io;
			pp = GetSpecies().GetBPP();
			SetHealth(GetSpecies().GetBHP());
		}

		public Point[,,] Data(Point[,,] array, bool graphical)
		// Shows the player's pokemon's data.
		{
			char sex_symbol = (char)9794;
			if (GetSex() == true)
			{
				sex_symbol = (char)9792;
			}

			if (graphical == true)
			{
				io.LoadText(35, 15, array, GetSpecies().GetSpeciesName() + " \"" + GetName() + "\" " + sex_symbol);
				io.LoadText(35, 13, array, "Salud: " + GetHealth() + "/" + GetSpecies().GetBHP());
				io.LoadText(35, 11, array, "Ataque: " + GetSpecies().GetATK());
				io.LoadText(35, 9, array, "Defensa: " + GetSpecies().GetDEF());
				io.LoadText(35, 7, array, "Velocidad: " + GetSpecies().GetSpeed());
				io.LoadText(35, 5, array, "Altura: " + GetSpecies().GetHeight());
				io.LoadText(35, 3, array, "Peso: " + GetSpecies().GetWeight());
				io.LoadText(35, 1, array, "Fecha de captura: " + GetCapTime());
			}
			else
			{
				io.WriteLine(GetSpecies().GetSpeciesName() + "\"" + GetName() + "\" " + sex_symbol);
				io.WriteLine("\tSalud: " + GetHealth() + "/" + GetSpecies().GetBHP());
				io.WriteLine("\tAtaque: " + GetSpecies().GetATK());
				io.WriteLine("\tDefensa: " + GetSpecies().GetDEF());
				io.WriteLine("\tVelocidad: " + GetSpecies().GetSpeed());
				io.WriteLine("\tAltura: " + GetSpecies().GetHeight());
				io.WriteLine("\tPeso: " + GetSpecies().GetWeight());
				if (GetCapTime().Year != 0001)
				{
					io.WriteLine("\tFecha de captura: " + GetCapTime());
				}
				io.WriteLine("");
			}

			return array;
		}

		public void AddMove(Move newmove)
		{
			if (RoomFind() != -1)
			{
				moves[RoomFind()] = newmove;
			}
			else
			{
				ReplaceMove(newmove);
			}
		}

		public void ListMoves()
		{
			for(int i = 0; i<moves.Length; i++)
			{
				if (moves[i] != null)
				{
					io.WriteLine(i + ") " + moves[i].GetName());
				}
			}
			return;
		}

		public Move GetMove(int move)
		{
			return moves[move];
		}

		public bool RoomCheck()
		{
			for (int i = 0; i < moves.GetLength(0); i++)
			{
				if (moves[i] == null)
				{
					return true;
				}
			}
			return false;
		}

		public int RoomFind()
		{
			for (int i = 0; i < moves.GetLength(0); i++)
			{
				if (moves[i] == null)
				{
					return i;
				}
			}
			return -1;
		}

		public void ReplaceMove(Move newMove)
		{
			io.WriteLine("Tu pokémon conoce el número máximo de movimientos.");
			io.WriteLine("¿Quieres aprender este movimiento? S/N");
			char answer = io.ReadLine()[0];
			if (Char.ToLower(answer) == 'n')
			{
				return;
			}
			io.WriteLine("¿Por qué movimiento eliges olvidar?");
			answer = io.ReadLine()[0];
			moves[(int)answer - 48] = newMove;
			return;
		}
	}
}
