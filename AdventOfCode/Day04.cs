namespace AdventOfCode;

public class Day04 : BaseDay
{
    private readonly string[] _input;

    public Day04()
    {
        _input = File.ReadAllLines(InputFilePath);
    }
    
    public override ValueTask<string> Solve_1()
    {
        int sum = 0;

        foreach (string s in _input)
        {
            string[] ranges = s.Split(",");
            string[] elve1 = ranges[0].Split("-");
            string[] elve2 = ranges[1].Split("-");

            if (ContainsRange(int.Parse(elve1[0]), int.Parse(elve1[1]), int.Parse(elve2[0]), int.Parse(elve2[1])))
                sum++;
        }
        return new($"{sum}");
    }

    public override ValueTask<string> Solve_2()
    {
        int sum = 0;

        foreach (string s in _input)
        {
            string[] ranges = s.Split(",");
            string[] elve1 = ranges[0].Split("-");
            string[] elve2 = ranges[1].Split("-");

            if (DoOverlap(int.Parse(elve1[0]), int.Parse(elve1[1]), int.Parse(elve2[0]), int.Parse(elve2[1])))
                sum++;
        }
        return new($"{sum}");
    }

    private bool ContainsRange(int lower1, int upper1, int lower2, int upper2)
    {
        return ((lower1 <= lower2 && upper1 >= upper2) || (lower2 <= lower1 && upper2 >= upper1));
    }
    
    private bool DoOverlap(int lower1, int upper1, int lower2, int upper2)
    {
        return ((upper1 >= lower2 && upper1 <= upper2) || upper2 >= lower1 && upper2 <= upper1);
    }
}