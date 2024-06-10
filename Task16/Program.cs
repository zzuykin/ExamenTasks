using System.Diagnostics;

var rand = new Random();
int X = 500;
int countOfThreads = 10;
var stop = new Object();

long[] times = new long[countOfThreads];
Thread[] myThreads = new Thread[countOfThreads];

for(int i = 0; i < countOfThreads; i++)
{
    int numThread = i;
    myThreads[i] = new Thread(() =>
    {
        GenerateArray(X, times, numThread);
    });
}

foreach(var thread in myThreads)
{
    thread.Start();
}

foreach (var thread in myThreads)
{
    thread.Join();
}

long[] filterTimes = times.Where(t => t > 0).ToArray();

Console.WriteLine($"Минимальное время ожидания {filterTimes.Min()} ms");
Console.WriteLine($"Среднее время ожидания {filterTimes.Average()} ms");
Console.WriteLine($"Максимальное время ожидания {filterTimes.Max()}  ms");

void GenerateArray(int x, long[] times, int threadIndex)
{
    int size = rand.Next(10_000_000, 15_000_001);
    int[] array = new int[size];

    for(int i = 0; i < size; i++)
    {
        array[i] = rand.Next(0, 1001);
    }

    Array.Sort(array);

    Stopwatch time = Stopwatch.StartNew();

    lock (stop)
    {
        times[threadIndex] = time.ElapsedMilliseconds;
        int count = array.Count(n => n == X);

        Console.WriteLine($"Поток {threadIndex} найдено значений {count}");
    }
}