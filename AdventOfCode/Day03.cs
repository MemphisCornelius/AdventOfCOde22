namespace AdventOfCode;

public class Day03 : BaseDay
{
    private readonly string[] _input;

    public Day03()
    {
        _input = File.ReadAllLines(InputFilePath);
    }

    public override ValueTask<string> Solve_1()
    {
        int sum = 0;

        foreach (string s in _input)
        {
            string comp1 = s.Substring(0, s.Length / 2);
            string comp2 = s.Substring(s.Length / 2, s.Length / 2);

            sum += GetPriority(GetSame(comp1, comp2));
        }

        return new($"{sum}");
    }

    public override ValueTask<string> Solve_2()
    {
        int sum = 0;
        
        for (int i = 0; i < _input.Length; i += 3)
        {
            sum += GetPriority(GetSame(_input[i], _input[i + 1], _input[i + 2]));
        }

        return new($"{sum}");
    }
    
    private int GetPriority(char c)
    {
        if (c < 91)
            return c - 64 + 26;
        else
            return c - 96;
    }

    private char GetSame(string comp1, string comp2)
    {
        foreach (char c1 in comp1)
        {
            foreach (char c2 in comp2)
            {
                if (c1 == c2)
                    return c1;
            }
        }
        throw new("This should not happen!");
    }
    
    private char GetSame(string elve1, string elve2, string elve3)
    {
        List<char> same = new();

        foreach (char c1 in elve1)
        {
            foreach (char c2 in elve2)
            {
                if(c1 == c2)
                    same.Add(c1);
            }
        }

        foreach (char c1 in same)
        {
            foreach (char c2 in elve3)
            {
                if (c1 == c2)
                {
                    return c1;
                }
            }
        }
        throw new("This should not happen!");
    }
}