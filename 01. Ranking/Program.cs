var contests = new Dictionary<string, string>();

string input = Console.ReadLine();

while (input != "end of contests")
{
    string nameContest = input.Split(":").First();
    string password = input.Split(":").Last();

    if (!contests.ContainsKey(nameContest))
    {
        contests.Add(nameContest, password);
    }

    input = Console.ReadLine();
}

string submissions = Console.ReadLine();

var result = new Dictionary<string, Dictionary<string, int>>();

while (submissions != "end of submissions")
{
    string[] cmdSubm = submissions.Split("=>");

    string nameContest = cmdSubm[0];
    string currPassword = cmdSubm[1];
    string user = cmdSubm[2];
    int points = int.Parse(cmdSubm[3]);

    if (contests.ContainsKey(nameContest) && contests[nameContest] == currPassword)
    {
        if (!result.ContainsKey(user))
        {
            result[user] = new Dictionary<string, int>();
        }

        if (result.ContainsKey(user) && !result[user].ContainsKey(nameContest))
        {
            result[user][nameContest] = 0;
        }

        if (result[user][nameContest] < points)
        {
            result[user][nameContest] = points;
        }
    }
    
    submissions = Console.ReadLine();
}

string winner = result.OrderBy(x => x.Value.Values.Sum()).Last().Key;
int bestPoints = result.OrderBy(x => x.Value.Values.Sum()).Last().Value.Values.Sum();

Console.WriteLine($"Best candidate is {winner} with total {bestPoints} points.");

Console.WriteLine("Ranking:");

foreach (var user in result.OrderBy(x => x.Key))
{
    Console.WriteLine(user.Key);
    foreach (var contest in user.Value.OrderByDescending(x => x.Value))
    {
        Console.WriteLine($"#  {contest.Key} -> {contest.Value}");
    }
}