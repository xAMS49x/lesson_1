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

        for (int i = 1; i <= 4; i++)
        {
            Log($"{name} rolled: {die1} and {die2}\n");
            result = (byte)(die1 + die2);
        }

        return result;
    }

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

public static class ArrayActions
{
    public static void Sum(int[] arr)
    {
        int sum = 0;
        foreach (var i in arr)
        {
            sum += i;
        }

        TaskSpecific.ColoredValue("Sum of array values: ", sum);
    }

    public static int Average(int[] arr)
    {
        int sum = 0;
        foreach (var i in arr)
        {
            sum += i;
        }

        var avg = sum / arr.Length;
        TaskSpecific.ColoredValue("Array average value: ", avg);
        return avg;
    }

    public static void GreatestSmallestNumbers(int[] arr)
    {
        int min = arr[0];
        int max = arr[0];

        foreach (int num in arr)
        {
            if (num < min)
                min = num;

            if (num > max)
                max = num;
        }

        TaskSpecific.ColoredValue("Smallest array value: ", min);
        TaskSpecific.ColoredValue("Greatest array value: ", max);
    }

    public static void ShowArray(int[] arr)
    {
        LogLine("Array contents are: ");
        Console.ForegroundColor = ConsoleColor.DarkRed;
        for (int i = 0; i < arr.Length; i++)
        {
            Log(arr[i] + " ");
        }

        Log(null);
        Console.ResetColor();
    }

    public static void GreaterThan500(int[] arr)
    {
        LogLine("Numbers greater than 500: ");
        foreach (var t in arr)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            if (t > 500)
            {
                Log(t + " ");
            }

            Console.ResetColor();
        }
    }

    public static int LessThanAverage(int[] arr)
    {
        var avg = Average(arr);
        LogLine("\n \nArray values less than average (" + avg + "):");
        Console.ForegroundColor = ConsoleColor.Cyan;
        foreach (var i in arr)
        {
            if (i < avg)
            {
                Log(i + " ");
            }
        }

        Console.ResetColor();
        return 0;
    }

    public static void MultipliesOf5(int[] arr)
    {
        LogLine("\n \nMultiplies of 5 in array:");
        foreach (var i in arr)
        {
            if (i % 5 == 0)
            {
                Log(i + " ");
            }
        }
    }

    public static void EvenNumbers(int[] arr)
    {
        LogLine("\n \nEven numbers in array:");
        foreach (var i in arr)
        {
            if (i % 2 == 0)
            {
                Log(i + " ");
            }
        }
    }

    public static void Within500To600RangeCount(int[] arr)
    {
        LogLine("\n \n500-600 range values:");
        foreach (var i in arr)
        {
            if (TaskSpecific.IsInRange(i, 500, 600))
            {
                Log(i + " ");
            }
        }
    }

    public static void Number899IsInArray(int[] arr)
    {
        foreach (var i in arr)
        {
            if (i == 899)
            {
                LogLine("Array has number 899");
                break;
            }

            LogLine("Array does not have 899 number");
            break;
        }
    }

    public static void SumOf100To200RangeValues(int[] arr)
    {
        int rangeSum = 0;

        foreach (var i in arr)
        {
            if (TaskSpecific.IsInRange(i, 100, 200))
            {
                rangeSum += i;
            }
        }

        TaskSpecific.ColoredValue("Sum of values in 200-200 range: ", rangeSum);
    }

    public static void NumbersContaining7(int[] arr)
    {
        LogLine("All numbers containing 7:");
        foreach (int i in arr)
            if (i.ToString().Contains('7'))
                Log(i + " ");
    }

    public static void SecondLargest(int[] arr)
    {
        int max = arr[0];
        int secondMax = arr[0];

        foreach (int i in arr)
        {
            if (i > max)
            {
                secondMax = max;
                max = i;
            }
            else if (i > secondMax && i != max)
            {
                secondMax = i;
            }
        }

        TaskSpecific.ColoredValue("Second largest value in array: ", secondMax);
    }
}