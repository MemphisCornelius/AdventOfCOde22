namespace AdventOfCode;

public class Day05 : BaseDay
{
    private readonly Stack<char>[] _stacks;
    private readonly List<(int numberOfCrates, int from, int to)> _instructions;

    public Day05()
    {
        _stacks = new[]
        {
            new Stack<char>(),
            new Stack<char>(),
            new Stack<char>(),
            new Stack<char>(),
            new Stack<char>(),
            new Stack<char>(),
            new Stack<char>(),
            new Stack<char>(),
            new Stack<char>(),
        };
        _instructions = new();
        var input = File.ReadAllLines(InputFilePath);

        for (int i = 7; i >= 0; i--)
        {
            for (int j = 0, k = 1; j < 9; j++, k += 4)
            {
                char c = input[i][k];
                if (c != ' ')
                    _stacks[j].Push(input[i][k]);
            }
        }

        input = input[10..];

        foreach (string s in input)
        {
            string[] instruction = s.Split(" ");
            int numberOfCrates = int.Parse(instruction[1]);
            int from = int.Parse(instruction[3]) - 1;
            int to = Int32.Parse(instruction[5]) - 1;

            _instructions.Add((numberOfCrates, from, to));
        }
    }

    public override ValueTask<string> Solve_1()
    {
        var stacks = CopyStacks(_stacks);

        foreach (var instruction in _instructions)
        {
            for (int i = 0; i < instruction.numberOfCrates; i++)
            {
                stacks[instruction.to].Push(stacks[instruction.from].Pop());
            }
        }

        string output = "";
        foreach (Stack<char> stack in stacks)
        {
            output += stack.Peek();
        }
        return new(output);
    }

    public override ValueTask<string> Solve_2()
    {
        var stacks = CopyStacks(_stacks);

        foreach (var instruction in _instructions)
        {
            Stack<char> transport = new();
            for (int i = 0; i < instruction.numberOfCrates; i++)
            {
                transport.Push(stacks[instruction.from].Pop());
            }

            while (transport.Count != 0)
                stacks[instruction.to].Push(transport.Pop());
        }

        string output = "";
        foreach (Stack<char> stack in stacks)
        {
            output += stack.Peek();
        }
        return new(output);
    }

    private Stack<char>[] CopyStacks(Stack<char>[] stacks)
    {
        Stack<char>[] s = new Stack<char>[stacks.Length];

        for (int i = 0; i < stacks.Length; i++)
        {
            s[i] = new Stack<char>(stacks[i].Reverse());
        }
        return s;
    }
}