using GuideTheLabyrinth;
using static System.Net.Mime.MediaTypeNames;

List<Point> ExiteTheLabyrinth(Point start, Point end)
{
    List<Point> path = new List<Point>();
    Move currentStep = new Move(start, DirectionType.down);
    
    path.Add(start);

    while(!(currentStep.Position == end))
    {
        currentStep = NextMove(currentStep);
        
        path.Add(currentStep.Position);
    }

    Console.WriteLine("Ready");
    return path;
}

Move NextMove(Move currentStep)
{    
    Move tryToGo = new Move(currentStep.Position, currentStep.Direction);

    tryToGo.Direction = tryToGo.Direction == DirectionType.left ? DirectionType.up : (DirectionType)(tryToGo.Direction-1);

    tryToGo.Position = DirectionCheck(tryToGo);

    while (tryToGo.Position == currentStep.Position)
    {        
        tryToGo.Direction = tryToGo.Direction == DirectionType.up ? DirectionType.left : (DirectionType)(tryToGo.Direction + 1);

        tryToGo.Position = DirectionCheck(tryToGo);
    }

    return tryToGo;
}

Point DirectionCheck(Move currentStep)
{
    Point newCoords = new Point();

    newCoords.Y = currentStep.Position.Y;
    newCoords.X = currentStep.Position.X;
        
    switch (currentStep.Direction)
    {
        case DirectionType.left:
            newCoords.X = newCoords.X + 1; 
            break;

        case DirectionType.down:
        default:
            newCoords.Y = newCoords.Y + 1;
            break;

        case DirectionType.right:
            newCoords.X = newCoords.X - 1;
            break;

        case DirectionType.up:
            newCoords.Y = newCoords.Y - 1;
            break;
    }

    if (Labyrinth(newCoords) == 1)
    {
        return newCoords;
    }

    return currentStep.Position;
}



int Labyrinth(Point p)
{
    int[,] labyrinth =
    {
    { 0, 1, 0, 1, 0, 0, 0, 1, 0, 0 },
    { 0, 1, 1, 1, 0, 0, 1, 1, 1, 0 },
    { 0, 1, 0, 1, 0, 1, 1, 1, 1, 0 },
    { 0, 1, 1, 1, 0, 1, 0, 1, 1, 0 },
    { 1, 1, 0, 0, 0, 1, 0, 1, 0, 0 },
    { 0, 1, 0, 1, 1, 1, 1, 1, 1, 0 },
    { 0, 1, 1, 1, 0, 0, 0, 0, 1, 0 },
    { 0, 1, 0, 1, 1, 0, 1, 1, 1, 0 },
    { 1, 1, 1, 1, 1, 0, 1, 1, 0, 0 },
    { 0, 0, 1, 0, 1, 0, 0, 1, 0, 0 }
    };

    //int[,] labyrinth =
    //{
    //    {0, 1, 0, 0},
    //    {1, 1, 1, 1},
    //    {0, 1, 1, 0},
    //    {0, 0, 1, 0}
    //};

    try
    {
        if (labyrinth[p.Y, p.X] == 1)
        {
            return 1;
        }
        else
        {
            return 0;
        }
    }
    catch 
    { 
        return 0;
    }
     
}

Point start = new Point(0, 1);
Point exite = new Point(9, 7);
//Point exite = new Point(3, 2);
List<Point> result = ExiteTheLabyrinth(start, exite);

File.WriteAllText(@"C:\Projects\C#\GuideTheLabyrinth\result.txt", string.Join("; ", result.Select(x => string.Join(",", x.Y, x.X))));