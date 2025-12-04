using System.Text;

const int BUFFERED_LINES = 3;

bool[] grid;
Span<bool> line1;
Span<bool> line2;
Span<bool> line3;
int lineLength;
int rolls = 0;
bool stop = false;

{
    var line = Console.ReadLine()!;
    lineLength = line.Length;
    grid = new bool[line.Length * BUFFERED_LINES];
    line1 = grid.AsSpan(0, lineLength);
    line2 = grid.AsSpan(lineLength, lineLength);
    line3 = grid.AsSpan(lineLength * 2, lineLength);
    for (int i = 0; i < lineLength; i++)
    {
        grid[lineLength + i] = line[i] == '@';
    }
    line = Console.ReadLine()!;
    for (int i = 0; i < lineLength; i++)
    {
        grid[2 * lineLength + i] = line[i] == '@';
    }
}

do
{
    for (int i = 0; i < lineLength; i++)
    {
        if (!line2[i])
            continue;
        var adjacent = 0;
        if (i > 0 && line2[i - 1])
            adjacent += 1;
        if (i < lineLength - 1 && line2[i + 1])
            adjacent += 1;
        if (line1[i])
            adjacent += 1;
        if (line3[i])
            adjacent += 1;
        if (i > 0 && line1[i - 1])
            adjacent += 1;
        if (i < lineLength - 1 && line1[i + 1])
            adjacent += 1;
        if (i > 0 && line3[i - 1])
            adjacent += 1;
        if (i < lineLength - 1 && line3[i + 1])
            adjacent += 1;
        if (line2[i] && adjacent < 4)
            rolls++;
    }

    var line = Console.ReadLine();
    if (stop)
    {
        break;
    }
    if (string.IsNullOrWhiteSpace(line))
    {
        Array.Copy(grid, lineLength, grid, 0, lineLength * (BUFFERED_LINES - 1));
        Array.Fill(grid, false, lineLength * 2, lineLength);
        stop = true;
        continue;
    }

    Array.Copy(grid, lineLength, grid, 0, lineLength * (BUFFERED_LINES - 1));
    for (int i = 0; i < lineLength; i++)
    {
        grid[2 * lineLength + i] = line[i] == '@';
    }
}
while (true);

Console.WriteLine(rolls);

