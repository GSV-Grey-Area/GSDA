using System;
using System.Collections.Generic;
using System.Text;

namespace Pokemon
{
	[Serializable]
	public class Move
	{
		string name;
		int id;
		int pp;
		int power;
		int precision;
		int priority;

		public Move(int n_id, string n_name, int n_pp, int n_power, int n_precision, int n_priority)
		{
			this.id = n_id;
			this.name = n_name;
			this.pp = n_pp;
			this.power = n_power;
			this.precision = n_precision;
			this.priority = n_priority;
			return;
		}

		public string GetName()
		{
			return name;
		}

		public int GetPower()
		{
			return power;
		}

		public int GetPP()
		{
			return pp;
		}

		public static Pokemon[] Act(Pokemon[] fighters2, Move move)
		{
			float rand0 = RandomExternal.GenerateRandom(0.85f, 1); // Random numbers to calculate damage.
			int power = move.GetPower();
			fighters2[1].SetHealth
			(
				(int)((float)fighters2[1].GetHealth() -
				(((
							(2 * (float)power * ((float)fighters2[0].GetSpecies().GetATK() / (float)fighters2[1].GetSpecies().GetDEF())
						)
						/
						(50)
					)
					+ 2
				)
				* (float)rand0
				* (float)CriticalCheck()))
			);
			fighters2[0].SetPP(fighters2[0].GetPP() - move.GetPP());
			return fighters2;
		}

		public static float CriticalCheck()
		// Checks whether a hit is critical or not.
		{
			float pre_crit1 = RandomExternal.GenerateRandom(0, 100);
			float crit1 = 1;
			if (pre_crit1 < 4.167)
			{
				crit1 = 1.5f;
			}
			return crit1;
		}
	}
}
