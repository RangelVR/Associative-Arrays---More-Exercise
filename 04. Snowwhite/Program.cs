
string dwarfInfo = Console.ReadLine();

var dwarfs = new Dictionary<string, Dictionary<string, int>>();

while (dwarfInfo != "Once upon a time")
{
    string[] cmdArr = dwarfInfo.Split(" <:> ");

    string name = cmdArr[0];
    string  hatColor = cmdArr[1];
    int phisics = int.Parse(cmdArr[2]);
    
    if (dwarfs.ContainsKey(hatColor) && !dwarfs[hatColor].ContainsKey(name))
    {
        dwarfs[hatColor][name] = phisics;
    }
    else if (!dwarfs.ContainsKey(hatColor))
    {
        dwarfs[hatColor] = new Dictionary<string, int>();
        dwarfs[hatColor].Add(name, phisics);
    }

    if (dwarfs[hatColor][name] < phisics)
    {
        dwarfs[hatColor][name] = phisics;
    }

    dwarfInfo = Console.ReadLine();
}

var sortedDwarfs = new Dictionary<string, int>();

foreach (var hatColor in dwarfs.OrderByDescending(x => x.Value.Count))
{
    foreach (var dwarf in hatColor.Value)
    {
        sortedDwarfs.Add($"({hatColor.Key}) {dwarf.Key} <->", dwarf.Value);
    }
}
foreach (var dwarf in sortedDwarfs.OrderByDescending(x => x.Value))
{
    Console.WriteLine($"{dwarf.Key} {dwarf.Value}");
}


