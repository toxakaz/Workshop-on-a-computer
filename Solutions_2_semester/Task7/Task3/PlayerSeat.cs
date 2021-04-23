﻿
namespace Task3
{
	public class PlayerSeat
	{
		public PlayerSeat(int startBank, GameManager creator, string playerName)
		{
			if (startBank > 0)
				Bank = startBank;
			else
				Bank = StandardStartBank;
			currentGameSession = creator;
			if (playerName == null)
				PlayerName = "?";
			else
				PlayerName = playerName;
			Active = true;
			Player = new Player(this);
		}

		const int StandardStartBank = 10000;
		internal int Bank { get; private set; }
		internal int Bet { get; private set; } = 0;
		internal Field BetField { get; private set; }
		internal bool BetDone { get; private set; } = false;
		internal double[] GameСoefficients
		{
			get
			{
				if (currentGameSession != null)
					return currentGameSession.GameСoefficients;
				return default;
			}
		}
		internal Field LastWinField
		{
			get
			{
				if (currentGameSession != null)
					return currentGameSession.LastWinField;
				return default;
			}
		}
		internal Player Player { get; private set; }
		internal string PlayerName { get; private set; }
		internal bool AutoKick { get; set; } = true;
		internal bool Active { get; private set; }

		GameManager currentGameSession;
		internal bool MakeBet(int count, Field field)
		{
			if (!Active || BetDone)
				return false;
			if ((int)field < -1 || (int)field > 2 || (count <= 0 && field != Field.None))
				return false;

			if (field == Field.None || Bank == 0)
			{
				Bet = 0;
				BetField = Field.None;
				BetDone = true;
				return true;
			}

			if (count <= Bank)
			{
				Bet = count;
				Bank -= count;
			}
			else if (count > Bank)
			{
				Bet = Bank;
				Bank = 0;
			}

			BetField = field;
			BetDone = true;
			return true;
		}
		internal bool QuitGame()
		{
			if (currentGameSession == null)
				return true;
			if (currentGameSession.SessionStarted || !Active)
				return false;
			if (BetDone)
			{
				int betWas = Bet;
				Bet = 0;
				Bank += betWas;
				BetField = Field.None;
				BetDone = false;
			}
			currentGameSession = null;
			Active = false;
			return true;
		}
		internal void PerformResult(double coefficient)
		{
			Bank += (int)(Bet * coefficient);
			Bet = 0;
			BetField = Field.None;
			BetDone = false;
		}
	}
}