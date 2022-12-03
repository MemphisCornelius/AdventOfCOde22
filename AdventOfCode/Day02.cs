namespace AdventOfCode;

public class Day02 : BaseDay
{
    private readonly string[] _input;

    private static Dictionary<string, RPS> elements = new()
    {
        { "A", RPS.Rock },
        { "B", RPS.Paper },
        { "C", RPS.Scissors },
        { "X", RPS.Rock },
        { "Y", RPS.Paper },
        { "Z", RPS.Scissors },
    };

    public Day02()
    {
        _input = File.ReadAllLines(InputFilePath);
    }

    public override ValueTask<string> Solve_1()
    {
        int score = 0;

        foreach (string line in _input)
        {
            string[] game = line.Split(" ");

            score += CalculateScore(elements[game[0]], elements[game[1]]);
        }

        return new($"{score}");
    }

    public override ValueTask<string> Solve_2()
    {
        int score = 0;

        Dictionary<(string, RPS), RPS> strategy = new()
        {
            { ("X", RPS.Rock), RPS.Scissors },
            { ("X", RPS.Paper), RPS.Rock },
            { ("X", RPS.Scissors), RPS.Paper },
            { ("Y", RPS.Rock), RPS.Rock },
            { ("Y", RPS.Paper), RPS.Paper },
            { ("Y", RPS.Scissors), RPS.Scissors },
            { ("Z", RPS.Rock), RPS.Paper },
            { ("Z", RPS.Paper), RPS.Scissors },
            { ("Z", RPS.Scissors), RPS.Rock },
        };

        foreach (string line in _input)
        {
            string[] game = line.Split(" ");

            score += CalculateScore(elements[game[0]], strategy[(game[1], elements[game[0]])]);
        }

        return new($"{score}");
    }

    static int CalculateScore(RPS enemy, RPS me)
    {
        int score = 0;

        if (enemy == me)
            score += 3;
        else
        {
            switch (enemy)
            {
                case RPS.Rock:
                    if (me == RPS.Paper)
                        score += 6;
                    break;
                case RPS.Paper:
                    if (me == RPS.Scissors)
                        score += 6;
                    break;
                case RPS.Scissors:
                    if (me == RPS.Rock)
                        score += 6;
                    break;
            }
        }

        return score + (int)me;
    }

    enum RPS
    {
        Rock = 1,
        Paper = 2,
        Scissors = 3
    }
}