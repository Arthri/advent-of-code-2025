string? line;
int dialNumber = 50;
int zeroCount = 0;

while (!string.IsNullOrWhiteSpace(line = Console.ReadLine()))
{
    int spin = int.Parse(line.AsSpan(1));
    int prevDial = dialNumber;
    dialNumber = dialNumber + spin * (line[0] == 'R' ? 1 : -1);
    zeroCount += Math.Abs(dialNumber / 100);
    if (prevDial > 0 && dialNumber <= 0)
    {
        zeroCount += 1;
    }
    dialNumber = (100 + dialNumber % 100) % 100;
}

Console.WriteLine(zeroCount);
