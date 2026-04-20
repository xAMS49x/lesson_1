using System;
using characters;
using static Library.Library;

namespace Homework4
{
    internal class Program
    {
        static void Main()
        {
            byte task = GetBytes("Welcome back. Choose the task you want to see (1-3): ");
            if (!ValidateRange(task, 1, 3)) throw new Exception("No such task number.");

            switch (task)
            {
                case 1:
                    // Task 1
                    Log("Let's play some dice!");
                    var player1 = new DicePlayer(Ask("Enter the name of first player"));
                    if (ValidateStringLength(player1.ToString() ?? throw new InvalidOperationException(), 0, 50)) throw new Exception("Invalid name.");

                    var player2 = new DicePlayer(Ask("Enter the name of second player"));
                    if (ValidateStringLength(player2.ToString() ?? throw new InvalidOperationException(), 0, 50)) throw new Exception("Invalid name.");

                    // Game
                    for (var round = 1; round <= 10; round++)
                    {
                        var gamePoints1 = player1.RollDice();
                        var gamePoints2 = player2.RollDice();

                        if (gamePoints1 > gamePoints2)
                        {
                            Log(player1.Name + " has won " + round + " round!");
                            Log("__________________________");
                        }

                        else if (gamePoints1 < gamePoints2)
                        {
                            Log(player2.Name + " has won " + round + " round!");
                            Log("__________________________");
                        }

                        else
                        {
                            Log("Round tie!");
                            Log("__________________________");
                        }
                    }

                    if (player1.DiceRollScore > player2.DiceRollScore)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Log($"{player1.Name} has won the game with {player1.DiceRollScore} score!");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Log($"{player2.Name} has lost the game with {player2.DiceRollScore} score!");
                        Console.ResetColor();
                    }
                    else if (player1.DiceRollScore < player2.DiceRollScore)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Log($"{player2.Name} has won the game with {player2.DiceRollScore} score!");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Log($"{player1.Name} has lost the game with {player1.DiceRollScore} score!");
                        Console.ResetColor();
                    }
                    else
                    {
                        Log("Both players drew!");
                    }

                    SaveLog(0);

                    break;

                case 2:

                    static void ShowHealth(Character player1, Character player2)
                    {
                        Log($"Health of {player1.Name}: {player1.Health}");
                        Log($"Health of {player2.Name}: {player2.Health}");
                    }

                    Random random = new Random();

                    Character hero1 = new Character(Ask("Enter the name for first character"), 2000, 120, 40, 5, 10);

                    Character hero2 = new Character(Ask("Enter the name for second character"), 1500, 90, 25, 30, 30);

                    int roundSecondGame = 1;

                    while (hero1.IsAlive && hero2.IsAlive)
                    {
                        Log($"\nRound {roundSecondGame}!\n");

                        hero1.AttackDefender(hero2, random);

                        if (!hero2.IsAlive)
                        {
                            ShowHealth(hero1, hero2);
                            break;
                        }

                        hero2.AttackDefender(hero1, random);

                        ShowHealth(hero1, hero2);

                        roundSecondGame++;
                    }

                    Log("\nFight's over!");

                    if (hero1.IsAlive)
                        Log($"Winner: {hero1.Name}");
                    else
                        Log($"Winner: {hero2.Name}");

                    break;
            }
        }
    }
}