using static Libraries.GetValidateLog;


namespace Libraries;

public static class ArrayActions
{
    // Sum
    public static void Sum(int[] arr)
    {
        int sum = 0;
        foreach (var i in arr)
        {
            sum += i;
        }

        TaskSpecific.ColoredValue("Sum of array values: ", sum);
    }

    // Average
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

    // Greatest and smallest array values
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

    // Array contents
    public static void ShowArray(int[] arr)
    {
        LogLine("Array contents are: ");
        Console.ForegroundColor = ConsoleColor.DarkRed;
        foreach (var t in arr)
        {
            Log(t + " ");
        }

        Log(null);
        Console.ResetColor();
    }

    // Numbers greater than 500
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

    // Numbers less than average
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

    // Numbers multiplies of 5
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

    // Even numbers of array
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

    // All values within 500-600 range
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

    // Is number 899 in array?
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

    // Sum of all values in 100-200 range
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

    // All numbers containing 7
    public static void NumbersContaining7(int[] arr)
    {
        LogLine("All numbers containing 7:");
        foreach (int i in arr)
            if (i.ToString().Contains('7'))
                Log(i + " ");
    }

    // Second largest number in array
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