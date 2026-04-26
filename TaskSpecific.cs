using System;
using static Libraries.GetValidateLog;

namespace Libraries;

public class TaskSpecific
{
    public static int CoinFlip()
    {
        var coinToss = new Random();
        int roll = coinToss.Next(1, 1001);

        switch (roll)
        {
            case <= 498:
                return 3;

            case <= 996:
                return 1;

            default:
                return 10;
        }
    }

    public static short DiceRoll(string name, byte die1, byte die2, byte result)
    {
        LogLine($"{name} throws the dice!");
            
        for(int i = 1; i <= 4; i++)
        {
            Log($"{name} rolled: {die1} and {die2}\n");
            result = (byte)(die1 + die2);
        }
        return result;
    }

    public static void ShowArray(int[] array)
    {
        LogLine("Array contents are: ");
        Console.ForegroundColor = ConsoleColor.DarkRed;
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write(array[i] + " ");
        } 
        Console.ResetColor();
    }
}