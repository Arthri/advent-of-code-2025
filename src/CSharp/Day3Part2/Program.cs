const int NUM_BATTERIES = 12;
var sum = 0ul;
Span<char> digits = stackalloc char[NUM_BATTERIES];

while (Console.ReadLine() is var line && !string.IsNullOrWhiteSpace(line))
{
    digits.Fill('\0');

    var lastIndex = -1;
    for (int i = 0; i < NUM_BATTERIES; i++)
    {
        var startIndex = lastIndex + 1;
        var (digit, index) = FindDigit(line.AsSpan(startIndex..^(NUM_BATTERIES - (1 + i))));
        digits[i] = digit;
        lastIndex = startIndex + index;
    }

    var mult = 1ul;
    for (int i = digits.Length - 1; i >= 0; i--, mult *= 10)
    {
        sum += (ulong)(digits[i] - '0') * mult;
    }
}

Console.WriteLine(sum);

(char Digit, int Index) FindDigit(ReadOnlySpan<char> line)
{
    (char Digit, int Index) result = ('\0', -1);
    for (int i = 0; i < line.Length; i++)
    {
        if (line[i] > result.Digit)
        {
            result = (line[i], i);
        }
    }

    return result;
}
