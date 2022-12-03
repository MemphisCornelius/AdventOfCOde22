namespace AdventOfCode;

public class Day01 : BaseDay
{
    private readonly string[] _input;

    public Day01()
    {
        _input = File.ReadAllLines(InputFilePath);
    }

    public override ValueTask<string> Solve_1() => new($"{AddCallories(_input).Max()}");

    public override ValueTask<string> Solve_2() => new($"{GetTop3()}2");

    private int GetTop3()
    {
        List<int> elves = AddCallories(_input);
        elves.Sort();
        return (elves[^1] + elves[^2] + elves[^3]);
    }

    private List<int> AddCallories(string[] lines)
    {
        List<int> elves = new();
        int calories = 0;

        foreach (string line in lines)
        {
            if (line == "")
            {
                elves.Add(calories);
                calories = 0;
            } else
            {
                calories += Convert.ToInt32(line);
            }
        }

        return elves;
    }
}