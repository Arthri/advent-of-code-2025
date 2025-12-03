var sum = 0;
Span<char> digits = stackalloc char[3];

while (Console.ReadLine() is var line && !string.IsNullOrWhiteSpace(line))
{
    digits.Fill('\0');

    int maxIndex = -1;
    for (int i = 0; i < line.Length; i++)
    {
        if (line[i] > digits[1])
        {
            digits[0] = digits[1];
            digits[1] = line[i];
            maxIndex = i;
        }
    }

    for (int i = maxIndex + 1; i < line.Length; i++)
    {
        if (line[i] > digits[2])
        {
            digits[2] = line[i];
            maxIndex = i;
        }
    }

    if (digits[2] == '\0')
    {
        digits[2] = digits[1];
        digits[1] = digits[0];
    }

    sum += (digits[1] - '0') * 10 + digits[2] - '0';
}

Console.WriteLine(sum);
