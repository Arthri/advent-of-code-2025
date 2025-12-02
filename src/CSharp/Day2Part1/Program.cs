var sum = 0ul;
var line = Console.ReadLine();
Span<Range> rangeBuffer = stackalloc Range[2];

foreach (var range in line.AsSpan().Split(','))
{
    var rangeSpan = line.AsSpan(range);
    _ = rangeSpan.Split(rangeBuffer, '-');
    var start = ulong.Parse(rangeSpan[rangeBuffer[0]]);
    var end = ulong.Parse(rangeSpan[rangeBuffer[1]]);

    for (ulong i = start; i <= end; i++)
    {
        if (ulong.DivRem((ulong)Math.Ceiling(Math.Log10(i)), 2) is (var unit, 0)
         && ulong.DivRem(i, (ulong)Math.Pow(10, unit)) is var (left, right)
         && left == right)
        {
            sum += i;
        }
    }
}

Console.WriteLine(sum);
