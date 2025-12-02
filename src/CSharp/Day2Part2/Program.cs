using System;
using System.Numerics;

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
    var (div, rem) = ulong.DivRem(places, fold);

    if (rem != 0)
    {
        return false;
    }

    var mask = (ulong)Math.Pow(10, div);
    for ((num, var pattern) = ulong.DivRem(num, mask); num > 0; num /= mask)
    {
        if (num % mask != pattern)
        {
            return false;
        }
    }

    return true;
}
