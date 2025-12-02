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
        var places = (ulong)Math.Ceiling(Math.Log10(i));
        for (ulong j = 2; j <= places; j++)
        {
            if (ulong.DivRem(places, j) is not (var unit, 0))
            {
                continue;
            }

            var mask = (ulong)Math.Pow(10, unit);
            var hasPattern = true;
            (var num, var pattern) = ulong.DivRem(i, mask);
            while (num > 0)
            {
                (num, var part) = ulong.DivRem(num, mask);
                if (part != pattern)
                {
                    hasPattern = false;
                    break;
                }
            }

            if (hasPattern)
            {
                sum += i;
                break;
            }
        }
    }
}

Console.WriteLine(sum);
