using System.Collections.Generic;

namespace AdventOfCode.Inputs;

public class Day06 : BaseDay {
    private readonly string _input;

    public Day06() {
        _input = File.ReadAllText(InputFilePath);
    }

    public override ValueTask<string> Solve_1() {
        int pos = 0;
        for (; pos < _input.Length - 4; pos++) {
            if (allDiffrent(_input[pos], _input[pos + 1], _input[pos + 2], _input[pos + 3]))
                break;
        }
        return new($"{pos + 4}");
    }

    private bool allDiffrent(char c0, char c1, char c2, char c3) {
        return c0 != c1 && c0 != c2 && c0 != c3 && c1 != c2 && c1 != c3 && c2 != c3;
    }

    public override ValueTask<string> Solve_2() {
        List<char> list = new();

        for (int pos = 0; pos < _input.Length; pos++) {
            if (list.Contains(_input[pos])) {
                while (list[0] != _input[pos]) {
                    list.Remove(list[0]);
                }
                list.Remove(list[0]);
            }
            list.Add(_input[pos]);
            
            if(list.Count == 14)
                return new($"{pos + 1}");
        }
        return new($"end of text");
    }
}