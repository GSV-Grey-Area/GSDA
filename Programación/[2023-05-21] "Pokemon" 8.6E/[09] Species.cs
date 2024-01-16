using System;
using System.Collections.Generic;
using System.Text;

namespace Pokemon
{
	[Serializable]
	public class Species
	// Class for pokemon species.
	{
		private string s_name;
		// Species' name.
		public void SetSpeciesName(string ns_name) { s_name = ns_name; }
		public string GetSpeciesName() { return s_name; }

		private int cap_ratio;
		// Capture ratio.
		public void SetCapRatio(int ncap_ratio) { cap_ratio = ncap_ratio; }
		public int GetCapRatio() { return cap_ratio; }

		private float sex_ratio;
		// Sex ratio.
		public void SetSexRatio(float nsex_ratio) { sex_ratio = nsex_ratio; }
		public float GetSexRatio() { return sex_ratio; }

		private int bhp;
		// Base health.
		public void SetBHP(int nbhp) { bhp = nbhp; }
		public int GetBHP() { return bhp; }

		private float height;
		// Pokemon's height.
		public void SetHeight(float n_height) { height = n_height; }
		public float GetHeight() { return height; }

		private float weight;
		// Pokemon's weight.
		public void SetWeight(float n_weight) { weight = n_weight; }
		public float GetWeight() { return weight; }

		private string color;
		// Color.
		public void SetColor(string ncolor) { color = ncolor; }
		public string GetColor() { return color; }

		private int atk;
		// Attack.
		public void SetATK(int natk) { atk = natk; }
		public int GetATK() { return atk; }

		private int atk_sp;
		// Special attack.
		public void SetATKS(int natks) { atk_sp = natks; }
		public int GetATKS() { return atk_sp; }

		private int def;
		// Defense.
		public void SetDEF(int ndef) { def = ndef; }
		public int GetDEF() { return def; }

		private int def_sp;
		// Special defense.
		public void SetDEFS(int ndefs) { def_sp = ndefs; }
		public int GetDEFS() { return def_sp; }

		private int speed;
		// Speed.
		public void SetSpeed(int nspeed) { speed = nspeed; }
		public int GetSpeed() { return speed; }

		private int bPP = 100;
			public int GetBPP()
			{
				return bPP;
			}

		public Species()
		// ¿Constructor?
		{
			s_name = "";
			cap_ratio = 0;
			sex_ratio = 0;
			bhp = 0;
			color = "xx";
			atk = 0;
			def = 0;
			speed = 0;
		}

		public Species
		(
			string ns_name,
			int ncap_ratio,
			float nsex_ratio,
			int nbhp,
			string ncolor,
			int natk,
			int ndef,
			int natks,
			int ndefs,
			int nspeed,
			float nweight,
			float nheight
		)
		// ¿Constructor?
		{
			s_name = ns_name;
			cap_ratio = ncap_ratio;
			sex_ratio = nsex_ratio;
			bhp = nbhp;
			color = ncolor;
			atk = natk;
			def = ndef;
			speed = nspeed;
			weight = nweight;
			height = nweight;
		}
	}

}
