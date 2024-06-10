using System.Diagnostics;

var rand = new Random();
var stopObject = new Object();

int x = 500;
int countThread = 10;

long[] times = new long[countThread];
Thread[] myThreads = new Thread[countThread];

for (int i = 0; i < countThread; i++)
{
    int threadIndex = i; 
    myThreads[i] = new Thread(() =>
    {
        Stopwatch time = Stopwatch.StartNew();
        GenerateArray(x);
        time.Stop();
        lock (stopObject)
        {
            times[threadIndex] = time.ElapsedMilliseconds;
        }
    });
}

for (int i = 0; i < countThread; i++)
{
    myThreads[i].Start();
}

for (int i = 0; i < countThread; i++)
{
    myThreads[i].Join();
}

Console.WriteLine($"Минимальное время выполнения: {times.Min()} ms");
Console.WriteLine($"Максимальное время выполнения: {times.Max()} ms");
Console.WriteLine($"Среднее время выполнения: {times.Average()} ms");

void GenerateArray(int X)
{
    int size = rand.Next(10_000_000, 15_000_001); 
    int[] array = new int[size];

    for (int i = 0; i < size; i++) 
    {
        array[i] = rand.Next(0, 1001);
    }
    Array.Sort(array);

    int count = array.Count(n => n == X); 

    Console.WriteLine($"Количество элементов, равных {X}: {count}");
}



