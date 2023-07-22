﻿using GuideTheLabyrinth;
using static System.Net.Mime.MediaTypeNames;

List<int[]> ExiteTheLabyrinth(int[] start, int[] end)
{
    List<int[]> path = new List<int[]>();
    Move currentStep = new Move(start, "down");
    
    path.Add(start);

    while(!(currentStep.Position[0] == end[0] && currentStep.Position[1] == end[1]))
    {
        currentStep = NextMove(currentStep);
        
        path.Add(currentStep.Position);
    }

    Console.WriteLine("Ready");
    return path;
}

Move NextMove(Move currentStep)
{
    string[] directions = new string[] { "left", "down", "right", "up"};
    
    Move tryToGo = new Move(currentStep.Position, currentStep.Direction);

    tryToGo.Direction = Array.IndexOf(directions, tryToGo.Direction) == 0 ? directions[3] : directions[Array.IndexOf(directions, tryToGo.Direction) - 1];

    tryToGo.Position = DirectionCheck(tryToGo);

    while (tryToGo.Position[0] == currentStep.Position[0] && tryToGo.Position[1] == currentStep.Position[1])
    {
        tryToGo.Direction = Array.IndexOf(directions, tryToGo.Direction) == 3 ? directions[0] : directions[Array.IndexOf(directions, tryToGo.Direction) + 1];

        tryToGo.Position = DirectionCheck(tryToGo);
    }

    return tryToGo;
}

int[] DirectionCheck(Move currentStep)
{
    int[] newCoords = new int[] { 0, 0 };
        
    newCoords[0] = currentStep.Position[0];
    newCoords[1] = currentStep.Position[1];

    switch (currentStep.Direction)
    {
        case "left":
            newCoords[1] = newCoords[1] + 1; 
            break;

        case "down":
        default:
            newCoords[0] = newCoords[0] + 1;
            break;

        case "right":
            newCoords[1] = newCoords[1] - 1;
            break;

        case "up":
            newCoords[0] = newCoords[0] - 1;
            break;
    }

    if (Labyrinth(newCoords[0], newCoords[1]) == 1)
    {
        return newCoords;
    }

    return currentStep.Position;
}



int Labyrinth(int y, int x)
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
        if (labyrinth[y, x] == 1)
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

int[] start = new int[] { 0, 1 };
int[] exite = new int[] { 9, 7 };
//int[] exite = new int[] { 3, 2 };
List<int[]> result = ExiteTheLabyrinth(start, exite);

File.WriteAllText(@"C:\Projects\C#\GuideTheLabyrinth\result.txt", string.Join(";", result.Select(x => string.Join(",", x))));