string? line;
int dialNumber = 50;
int zeroCount = 0;

while (!string.IsNullOrWhiteSpace(line = Console.ReadLine()))
{
    int spin = int.Parse(line.AsSpan(1));
    dialNumber = (100 + (dialNumber + spin * (line[0] == 'R' ? 1 : -1)) % 100) % 100;
    if (dialNumber == 0)
    {
        zeroCount++;
    }
}

Console.WriteLine(zeroCount);
