string input = Console.ReadLine();

var judge = new Dictionary<string, Dictionary<string, int>>();

while (input != "no more time")
{
    string[] argInput = input.Split(" -> ");

    string nameUser = argInput[0];
    string contest = argInput[1];
    int points = int.Parse(argInput[2]);

    if (!judge.ContainsKey(contest))
    {
        judge[contest] = new Dictionary<string, int>();
    }

    if (judge.ContainsKey(contest) && !judge[contest].ContainsKey(nameUser))
    {
        judge[contest][nameUser] = 0;
    }

    if (judge[contest][nameUser] < points)
    {
        judge[contest][nameUser] = points;
    }

    input = Console.ReadLine();
}


foreach (var constestName in judge)
{
    int position = 1;

    Console.WriteLine($"{constestName.Key}: {constestName.Value.Count} participants");

    foreach (var user in constestName.Value.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
    {
        Console.WriteLine($"{position}. {user.Key} <::> {user.Value}");
        position++;
    }
}

Console.WriteLine("Individual standings:");

var individualStandings = new Dictionary<string, int>();

foreach (var contest in judge)
{
    foreach (var name in contest.Value)
    {
        if (!individualStandings.ContainsKey(name.Key))
        {
            individualStandings[name.Key] = name.Value;
        }
        else
        {
            individualStandings[name.Key] += name.Value;
        }
    }
}

int poss = 1;

foreach (var userName in individualStandings.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
{
    Console.WriteLine($"{poss}. {userName.Key} -> {userName.Value}");
    poss++;
}

