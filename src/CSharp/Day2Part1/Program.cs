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
        if (IsInvalid(i))
        {
            sum += i;
        }
    }
}

Console.WriteLine(sum);

bool IsInvalid(ulong num)
{
    var places = (ulong)Math.Ceiling(Math.Log10(num));

    if (ulong.DivRem(places, 2) is not (var unit, 0))
    {
        return false;
    }

    var mask = (ulong)Math.Pow(10, unit);
    return num / mask == num % mask;
}
