class DicePlayer(string name, ConsoleColor color)
{
    public string Name { get; set; } = name;
    public int Score { get; set; } = 0;

    public ConsoleColor Color { get; set; } = color;

    private static readonly Random _random = new();

    public static int RollDice()
    {
        return _random.Next(1, 7);
    }
}

class GameSettings
{
    public int Rounds { get; set; } = 3;
    public int DicePerRoll { get; set; } = 1;
}

class Program
{
    static readonly List<DicePlayer> players = [];
    static readonly ConsoleColor[] availableColors =
    {
        ConsoleColor.Red,
        ConsoleColor.Blue,
        ConsoleColor.Green,
        ConsoleColor.Yellow,
        ConsoleColor.Cyan,
        ConsoleColor.Magenta,
        ConsoleColor.White
    };
    static readonly GameSettings settings = new();

    static int GetNumberInput(string message, int min, int max)
    {
        while (true)
        {
            Console.Clear();
            Console.Write(message);
            string? input = Console.ReadLine();

            if (int.TryParse(input, out int value) && value >= min && value <= max)
                return value;

            Console.WriteLine($"Please enter a number between {min} and {max}.");
            Thread.Sleep(1200);
        }
    }

    static void Main()
    {
        bool running = true;

        while (running)
        {
            DrawMainMenu();
            string? input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    AddPlayer();
                    break;
                case "2":
                    RemovePlayer();
                    break;
                case "3":
                    StartMatch();
                    break;
                case "4":
                    OpenSettings();
                    break;
                case "5":
                    running = false;
                    break;
                default:
                    ShowMessage("Invalid option.");
                    break;
            }
        }
    }

    static void DrawMainMenu()
    {
        Console.Clear();
        Console.WriteLine("=== DICE GAME MENU ===");
        Console.WriteLine("1. Add player");
        Console.WriteLine("2. Remove player");
        Console.WriteLine("3. Start match");
        Console.WriteLine("4. Settings");
        Console.WriteLine("5. Exit");
        Console.WriteLine();
        Console.WriteLine($"Rounds: {settings.Rounds}");
        Console.WriteLine($"Dice per roll: {settings.DicePerRoll}");
        Console.WriteLine();
        Console.WriteLine("Current players:");

        if (players.Count == 0)
        {
            Console.WriteLine("  No players yet.");
        }
        else
        {
            for (int i = 0; i < players.Count; i++)
            {
                Console.ForegroundColor = players[i].Color;
                Console.WriteLine($"  {i + 1}. {players[i].Name}");
                Console.ResetColor();
            }
        }

        Console.WriteLine();
        Console.Write("Choose option: ");
    }

    static void OpenSettings()
    {
        bool inSettings = true;

        while (inSettings)
        {
            Console.Clear();
            Console.WriteLine("=== SETTINGS ===");
            Console.WriteLine($"1. Change rounds        (current: {settings.Rounds})");
            Console.WriteLine($"2. Change dice per roll (current: {settings.DicePerRoll})");
            Console.WriteLine("3. Back");
            Console.WriteLine();
            Console.Write("Choose option: ");

            string? input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    settings.Rounds = GetNumberInput("Enter number of rounds (1-20): ", 1, 20);
                    break;

                case "2":
                    settings.DicePerRoll = GetNumberInput("Enter dice per roll (1-4): ", 1, 4);
                    break;

                case "3":
                    inSettings = false;
                    break;

                default:
                    ShowMessage("Invalid option.");
                    break;
            }
        }
    }

    static void AddPlayer()
    {
        Console.Clear();
        Console.Write("Enter player name: ");
        string? name = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(name))
        {
            ShowMessage("Player name cannot be empty.");
            return;
        }

        ConsoleColor color = availableColors[players.Count % availableColors.Length];
        players.Add(new DicePlayer(name, color));

        ShowMessage($"Added player: {name}");
    }

    static void RemovePlayer()
    {
        Console.Clear();

        if (players.Count == 0)
        {
            ShowMessage("There are no players to remove.");
            return;
        }

        Console.WriteLine("Choose player to remove:");

        for (int i = 0; i < players.Count; i++)
        {
            Console.ForegroundColor = players[i].Color;
            Console.WriteLine($"{i + 1}. {players[i].Name}");
            Console.ResetColor();
        }

        Console.Write("Number: ");
        string? input = Console.ReadLine();

        if (int.TryParse(input, out int index) && index >= 1 && index <= players.Count)
        {
            string removedName = players[index - 1].Name;
            players.RemoveAt(index - 1);
            ShowMessage($"Removed player: {removedName}");
        }
        else
        {
            ShowMessage("Invalid player number.");
        }
    }

    static void StartMatch()
    {
        if (players.Count < 2)
        {
            ShowMessage("You need at least 2 players to start.");
            return;
        }

        foreach (var player in players)
        {
            player.Score = 0;
        }

        for (int round = 1; round <= settings.Rounds; round++)
        {
            foreach (var player in players)
            {
                AnimateRoll(player, round);
            }
        }

        DrawScoreboard(-1, "Match finished!");
        ShowWinner();

        Console.WriteLine();
        Console.WriteLine("Press any key to return to menu...");
        Console.ReadKey(true);
    }

    static void AnimateRoll(DicePlayer player, int round)
    {
        string[] frames = { "|", "/", "-", "\\" };

        for (int i = 0; i < 10; i++)
        {
            DrawScoreboard(round, $"{player.Name} rolling... [{frames[i % frames.Length]}]");
            Thread.Sleep(80);
        }

        List<int> rolls = new();

        for (int i = 0; i < settings.DicePerRoll; i++)
        {
            rolls.Add(DicePlayer.RollDice());
        }

        int totalRoll = rolls.Sum();
        player.Score += totalRoll;

        string rollText = string.Join(", ", rolls);
        DrawScoreboard(round, $"{player.Name} rolled: [{rollText}]  Total: +{totalRoll}");
        Thread.Sleep(1200);
    }

    static void DrawScoreboard(int round, string status)
    {
        Console.Clear();

        Console.WriteLine("=== MATCH ===");
        if (round > 0)
        {
            Console.WriteLine($"Round: {round}");
        }
        Console.WriteLine();

        Console.WriteLine("Scores:");
        Console.WriteLine("-------------------------");

        foreach (var player in players)
        {
            Console.ForegroundColor = player.Color;
            Console.WriteLine($"{player.Name,-12} : {player.Score}");
            Console.ResetColor();
        }

        Console.WriteLine("-------------------------");
        Console.WriteLine();
        Console.WriteLine(status);
    }

    static void ShowWinner()
    {
        int bestScore = int.MinValue;
        List<DicePlayer> winners = new();

        foreach (var player in players)
        {
            if (player.Score > bestScore)
            {
                bestScore = player.Score;
                winners.Clear();
                winners.Add(player);
            }
            else if (player.Score == bestScore)
            {
                winners.Add(player);
            }
        }

        Console.WriteLine();

        if (winners.Count == 1)
        {
            Console.ForegroundColor = winners[0].Color;
            Console.WriteLine($"Winner: {winners[0].Name} with {winners[0].Score} points!");
            Console.ResetColor();
        }
        else
        {
            Console.WriteLine("It's a draw between:");
            foreach (var player in winners)
            {
                Console.ForegroundColor = player.Color;
                Console.WriteLine($"- {player.Name} ({player.Score})");
                Console.ResetColor();
            }
        }
    }

    static void ShowMessage(string message)
    {
        Console.WriteLine();
        Console.WriteLine(message);
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey(true);
    }
}