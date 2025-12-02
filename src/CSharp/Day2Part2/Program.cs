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
    for (ulong i = 2; i <= places; i++)
    {
        if (HasPattern(num, places, i))
        {
            return true;
        }
    }
    return false;
}

bool HasPattern(ulong num, ulong places, ulong fold)
{
    if (ulong.DivRem(places, fold) is not (var unit, 0))
    {
        return false;
    }

    var mask = (ulong)Math.Pow(10, unit);
    for ((num, var pattern) = ulong.DivRem(num, mask); num > 0; num /= mask)
    {
        if (num % mask != pattern)
        {
            return false;
        }
    }

    return true;
}
