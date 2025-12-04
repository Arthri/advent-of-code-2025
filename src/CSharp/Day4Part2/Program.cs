List<bool[]> grid = [];
int lineLength;
int rolls = 0;

{
    var line = Console.ReadLine()!;
    lineLength = line.Length;
    grid.Add(new bool[lineLength]);
    do
    {
        var lineBool = new bool[lineLength];
        for (int i = 0; i < lineLength; i++)
        {
            lineBool[i] = line[i] == '@';
        }
        grid.Add(lineBool);
    }
    while (!string.IsNullOrWhiteSpace(line = Console.ReadLine()));
    grid.Add(new bool[lineLength]);
}

var endIndex = grid.Count - 1;
while (true)
{
    bool hasRemoved = false;
    for (int i = 1; i < endIndex; i++)
    {
        for (int j = 0; j < lineLength; j++)
        {
            if (TryRemove(i, j))
            {
                hasRemoved = true;
            }
        }
    }

    if (!hasRemoved)
    {
        break;
    }
}

Console.WriteLine(rolls);

bool TryRemove(int y, int x)
{
    if (!grid[y][x])
        return false;

    var adjacent = 0;

    int yU = y - 1;
    int yD = y + 1;
    int xL = x - 1;
    int xR = x + 1;
    if (grid[yU][x])
        adjacent++;
    if (grid[yD][x])
        adjacent++;
    if (xL >= 0)
    {
        if (grid[yU][xL])
            adjacent++;
        if (grid[y][xL])
            adjacent++;
        if (grid[yD][xL])
            adjacent++;
    }
    if (xR < lineLength)
    {
        if (grid[yU][xR])
            adjacent++;
        if (grid[y][xR])
            adjacent++;
        if (grid[yD][xR])
            adjacent++;
    }

    if (adjacent < 4)
    {
        rolls++;
        grid[y][x] = false;
        return true;
    }

    return false;
}
