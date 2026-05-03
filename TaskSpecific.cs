using System;
using static Libraries.GetValidateLog;

namespace Libraries;

public class TaskSpecific
{
    // public static int CoinFlip()
    // {
    //     var coinToss = new Random();
    //     int roll = coinToss.Next(1, 1001);
    //
    //     switch (roll)
    //     {
    //         case <= 498:
    //             return 3;
    //
    //         case <= 996:
    //             return 1;
    //
    //         default:
    //             return 10;
    //     }
    // }
    //
    // public static short DiceRoll(string name, byte die1, byte die2, byte result)
    // {
    //     LogLine($"{name} throws the dice!");
    //
    //     for (int i = 1; i <= 4; i++)
    //     {
    //         Log($"{name} rolled: {die1} and {die2}\n");
    //         result = (byte)(die1 + die2);
    //     }
    //
    //     return result;
    // }

    //dont question this one
    public static void ColoredValue(string msg, int value, ConsoleColor color = ConsoleColor.Magenta)
    {
        Log(msg);
        Console.ForegroundColor = color;
        Log(value + "\n");
        Console.ResetColor();
    }

    public static bool IsInRange(int value, int min, int max)
    {
        if (value > min && value < max)
        {
            return true;
        }

        return false;
    }

    public static void RepeatFunctionBlock(string msg)
    {
        Log(msg);
        if (Console.ReadKey().Key != ConsoleKey.Y) return;
        LogLine("\n");
    }
    
    
}