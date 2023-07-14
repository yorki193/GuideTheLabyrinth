using static System.Net.Mime.MediaTypeNames;

List<int[]> ExiteTheLabyrinth(int[] start, int[] end)
{
    List<int[]> path = new List<int[]>();
    int[] step = new int[] { 0, 0 };
    int[] prevStep = new int[] { 0, 0 };

    path.Add(start);

    while(path.LastOrDefault()[0] != end[0] && path.LastOrDefault()[1] != end[1])
    {
        prevStep = step;
        step = path.LastOrDefault();
        
        path.Add(Step(step, prevStep));
    }

    path.Add(end);

    Console.WriteLine("Ready");
    return path;
}

int[] Step(int[] step, int[] prevStep)
{ 
    int y = step[0];
    int x = step[1];
    int[] coords = new int[] { 0, 0 };
    
    //перевірка напрямків
    //left
    if (Labyrinth(y, x-1) == 1) //left
    {
        coords = new int[] { y, x - 1 };

        if (coords[0] != prevStep[0] && coords[1] != prevStep[1])
        {
            return coords;
        }
    }    

    //down
    if (Labyrinth(y+1, x) == 1) 
    {
        coords = new int[] { y + 1, x };

        if (coords[0] != prevStep[0] && coords[1] != prevStep[1])
        {
            return coords;
        }
    }

    //right
    if (Labyrinth(y, x+1) == 1) 
    {
        coords = new int[] { y, x + 1 };

        if (coords[0] != prevStep[0] && coords[1] != prevStep[1])
        {
            return coords;
        }
    }

    //up
    if (Labyrinth(y-1, x) == 1) 
    {
        coords = new int[] { y - 1, x };

        if (coords[0] != prevStep[0] && coords[1] != prevStep[1])
        {
            return coords;
        }
    }

    return coords;
}

int Labyrinth(int y, int x)
{
    int[,] labyrinth = {
    { 0, 1, 0, 1, 0, 0, 0, 1, 0, 0 },
    { 0, 1, 1, 1, 0, 0, 1, 1, 1, 0 },
    { 0, 1, 0, 1, 0, 1, 1, 1, 1, 0 },
    { 0, 1, 1, 1, 0, 1, 0, 1, 1, 0 },
    { 1, 1, 0, 0, 0, 1, 0, 1, 0, 0 },
    { 0, 1, 0, 1, 1, 1, 1, 1, 1, 0 },
    { 0, 1, 1, 1, 0, 0, 0, 0, 1, 0 },
    { 0, 1, 0, 1, 1, 0, 1, 1, 1, 0 },
    { 1, 1, 1, 1, 1, 0, 1, 1, 0, 0 },
    { 0, 0, 1, 0, 1, 0, 0, 1, 0, 0 } };

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





//--------------------------------------------------------------------------
//програма для виходу з лабіринту
//двомірний масив, де буде лабіринт (1 - прохід, 0 - стіни // x/y)

//параметри метода - вхід в лабіринт, вихід з лабіринту

//результат - цепочка координат, що дозволяють вийти з лабіринту.

//варіанти - вибір однієї сторони
//паралельний прохід по коридорах - рекурсія