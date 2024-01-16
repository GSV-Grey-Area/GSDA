using System;
using System.Collections.Generic;
using System.Text;
using Pokemon;

namespace Pokemon
{
	[Serializable]
	public class Player : EconomicEntity
	{
		IO io;
		string playerName;
		bool playerSex;
		string numericalID;
		protected string secretNumber;
		int battlePoints;
		int pokeSeeds;
		System.DateTime startTime;
		Team team;
		Box[] box;
		Bag bag;

		public Player
		(
			string n_playerName,
			bool n_playerSex,
			string n_numericalID,
			string n_secretNumber,
			System.DateTime n_startTime,
			Team n_team,
			Box[] n_box,
			Bag n_bag,
			IO n_io
		)
		{
			this.playerName = n_playerName;
			this.playerSex = n_playerSex;
			this.numericalID = n_numericalID;
			this.secretNumber = n_secretNumber;
			this.money = 0;
			this.battlePoints = 0;
			this.pokeSeeds = 0;
			this.startTime = n_startTime;
			this.team = n_team;
			this.box = n_box;
			this.bag = n_bag;
			this.io = n_io;
		}

		public void PlayerData()
		{
			io.WriteLine("Información del jugador \"" + playerName + "\":");
			io.WriteLine("\tID: " + numericalID);
			string temp = "Chico";
			if (playerSex == true)
			{
				temp = "Chica";
			}
			io.WriteLine("\tSexo: " + temp);
			io.WriteLine("\tPokedólares: " + money);
			io.WriteLine("\tPuntos de batalla: " + battlePoints);
			io.WriteLine("\tPokesemillas: " + pokeSeeds);
			io.WriteLine("");
			return;
		}

		public string GetName()
		{
			return playerName;
		}

		public string GetID()
		{
			return numericalID;
		}

		public string GetSecretNumber()
		{
			return secretNumber;
		}

		public string GetSex()
		{
			string temp = "Chico";
			if (playerSex == true)
			{
				temp = "Chica";
			}
			return temp;
		}

		public char GetSexChar()
		{
			char sex_symbol = (char)9794;
			if (this.playerSex == true)
			{
				sex_symbol = (char)9792;
			}
			return sex_symbol;
		}

		public int GetMoney()
		{
			return money;
		}

		public int GetPokeSeeds()
		{
			return pokeSeeds;
		}

		public int GetBattlePoints()
		{
			return battlePoints;
		}

		public int GetAmount(Item n_item)
		{
			int amount = bag.GetAmount(n_item);
			return amount;
		}

		public void AddItem(Item n_item, int amount, int origAmount)
		{
			io.WriteLine("Player add item amount: " + amount + "(" + origAmount + ")");
			bag.AddItem(n_item, amount, origAmount);
			money = money - n_item.GetPrice();
		}

		public void RemoveItem(Item n_item, int amount)
		{
			bag.RemoveItem(n_item, amount);
			money = money + n_item.GetPrice();
		}

		public void UseItem()
		{
		}

		public Team GetTeam()
		{
			return team;
		}

		public Bag GetBag()
		{
			return bag;
		}
	}
}
