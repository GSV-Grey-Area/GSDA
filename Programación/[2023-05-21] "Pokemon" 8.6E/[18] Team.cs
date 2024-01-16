using System;
using System.Collections.Generic;
using System.Text;
using Pokemon;

namespace Pokemon
{
	[Serializable]
	public class Team
	{
		Pokemon[] team2;
		Game g;
		IO io;

		public Team(Game g, IO io)
		{
			team2 = new Pokemon[6];
			this.g = g;
			this.io = io;
		}

		public void GeneratePokemon(int resm, string pokemon_name)
		{
			team2[0] = new Pokemon(g.GetSpecies(resm), pokemon_name, RandomExternal.GenerateRandom(0, 1), io); // Player's pokemon generation.
		}

		public void AddPokemon(Pokemon newpokemon)
		{
			if (RoomFind() != -1)
			{
				team2[RoomFind()] = newpokemon;
			}
			else
			{
				ReplacePokemon(newpokemon);
			}
		}

		public bool RoomCheck()
		{
			for (int i = 0; i < team2.GetLength(0); i++)
			{
				if (team2[i] == null)
				{
					return true;
				}
			}
			return false;
		}

		public int RoomFind()
		{
			for (int i = 0; i < team2.GetLength(0); i++)
			{
				if (team2[i] == null)
				{
					return i;
				}
			}
			return -1;
		}

		public void ReplacePokemon(Pokemon newpokemon)
		{
			io.WriteLine("Equipo lleno.");
			io.WriteLine("¿Quieres quedarte con este Pokémon? S/N");
			char answer = io.ReadLine()[0];
			if (Char.ToLower(answer) == 'n')
			{
				return;
			}
			io.WriteLine("¿Por qué pokémon quieres cambiar el que acabas de capturar?");
			answer = io.ReadLine()[0];
			team2[(int)answer - 48] = newpokemon;
			return;
		}

		public void RearrangeTeam()
		{
			char answer;
			do
			{
				io.WriteLine("¿Quieres cambiar de sitio un Pokémon?");
				answer = io.ReadLine()[0];
				if (Char.ToLower(answer) != 's')
				{
					return;
				}
				io.WriteLine("¿Qué pokémon quieres mover?");
				int pokA = int.Parse(io.ReadLine());
				io.WriteLine("¿Dónde lo quieres mover?");
				int pokB = int.Parse(io.ReadLine());
				Pokemon temp = team2[pokB];
				team2[pokB] = team2[pokA];
				team2[pokA] = temp;
			}
			while (Char.ToLower(answer) == 's');
			return;
		}

		public void List()
		{
			io.WriteLine("Equipo:");
			for (int i = 0; i < team2.GetLength(0); i++)
			{
				io.Write("\t" + (i + 1) + ": ");
				if (team2[i] == null)
				{
					io.WriteLine("Vacío.");
				}
				else
				{
					io.WriteLine(team2[i].GetSpecies().GetSpeciesName() + " \"" + team2[i].GetName() + "\": " + team2[i].GetHealth() + "/" + team2[i].GetSpecies().GetBHP());
				}
			}
			io.WriteLine("");
			return;
		}

		public Pokemon GetPokemon(int n)
		{
			return team2[n];
		}

		public Pokemon[] GetPokemons()
		{
			return team2;
		}

		public bool CheckPokemon(int n)
		{
			if (team2[n] != null)
			{
				return true;
			}
			return false;
		}

		public int GetTeamSize()
		{
			return team2.Length;
		}
	}
}
