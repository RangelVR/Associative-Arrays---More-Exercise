
var mobaPlayers = new Dictionary<string, Dictionary<string, int>>();

while (true)
{
    string input = Console.ReadLine();

	if (input == "Season end")
	{
		break;
	}

	if (input.Contains("vs"))
	{
		string player1 = input.Split().First();
		string player2 = input.Split().Last();

		if (mobaPlayers.ContainsKey(player1) && mobaPlayers.ContainsKey(player2))
		{
			foreach (var firstPlayer in mobaPlayers.Where(x => x.Key == player1))
			{
				foreach (var positionFirstPlayer in firstPlayer.Value)
				{
					foreach (var secondPlayer in mobaPlayers.Where(x => x.Key == player2))
					{
						foreach (var positionSecondPlayer in secondPlayer.Value)
						{
							if (positionFirstPlayer.Key == positionSecondPlayer.Key)
							{
								if (positionFirstPlayer.Value > positionSecondPlayer.Value)
								{
									mobaPlayers.Remove(player2);
									break;
								}
								else if (positionFirstPlayer.Value < positionSecondPlayer.Value)
								{
									mobaPlayers.Remove(player1);
									break;
								}
							}
						}
					}
				}
			}
		}
	}
	else
	{
		string[] argInput = input.Split(" -> ");

		string player = argInput[0];
		string position = argInput[1];
		int skillPoints = int.Parse(argInput[2]);

		if (!mobaPlayers.ContainsKey(player))
		{
			mobaPlayers[player] = new Dictionary<string, int>();
		}

		if (!mobaPlayers[player].ContainsKey(position))
		{
			mobaPlayers[player][position] = skillPoints;
		}
		else
		{
			if (mobaPlayers[player][position] < skillPoints)
		        {
                            mobaPlayers[player][position] = skillPoints;
            		}
		}
	}
}

var winerList = new Dictionary<string, int>();

foreach (var player in mobaPlayers)
{
	int totalSkillpoints = 0;

	foreach (var item in player.Value)
	{
		totalSkillpoints += item.Value;
	}

	winerList[player.Key] = totalSkillpoints;
}

foreach (var name in winerList.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
{
	Console.WriteLine($"{name.Key}: {name.Value} skill");

	foreach (var player in mobaPlayers.Where(x => x.Key == name.Key))
	{
		foreach (var position in player.Value.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
		{
			Console.WriteLine($"- {position.Key} <::> {position.Value}");
		}
	}
}
