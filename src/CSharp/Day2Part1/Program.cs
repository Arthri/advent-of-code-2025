var sum = 0ul;
var line = Console.ReadLine();

foreach (var range in line.AsSpan().Split(','))
{
    var rangeSpan = line.AsSpan(range);
    var enumerator = rangeSpan.Split('-');
    enumerator.MoveNext();
    var left = ulong.Parse(rangeSpan[enumerator.Current]);
    enumerator.MoveNext();
    var right = ulong.Parse(rangeSpan[enumerator.Current]);

    for (ulong i = left; i <= right; i++)
    {
        if (IsInvalid(i))
        {
            sum += i;
        }
    }
}

Console.WriteLine(sum);

ulong GetPlaces(ulong num)
{
    return (ulong)Math.Ceiling(Math.Log10(num));
}

bool IsInvalid(ulong num)
{
    var places = GetPlaces(num);
    var (div, rem) = ulong.DivRem(places, 2);
    
    if (rem != 0)
    {
        return false;
    }

    var mask = (ulong)Math.Pow(10, div);
    return num / mask == num % mask;
}
