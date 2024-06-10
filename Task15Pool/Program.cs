
using System.Diagnostics;

var rand = new Random();
int X = 500;
int countOfThreads = 10;
long[] times = new long[countOfThreads];
ManualResetEvent[] myThreds = new ManualResetEvent[countOfThreads];


for(int i = 0; i < countOfThreads; i++)
{
    int numThread = i;
    myThreds[i] = new ManualResetEvent(false);

    ThreadPool.QueueUserWorkItem(new WaitCallback((object x) =>
    {
        Stopwatch time = Stopwatch.StartNew();
        GenerateArray(X);
        time.Stop();
        times[numThread] = time.ElapsedMilliseconds;
        myThreds[numThread].Set();
    }),i);
}

WaitHandle.WaitAll(myThreds);

Console.WriteLine($"Минимальное время выполнения: {times.Min()} ms");
Console.WriteLine($"Максимальное время выполнения: {times.Max()} ms");
Console.WriteLine($"Среднее время выполнения: {times.Average()} ms");

void GenerateArray(int X)
{
    int size = rand.Next(10_000_000, 15_000_001);
    int[] array = new int[size];
    for(int i = 0; i < size; i++)
    {
        array[i] = rand.Next(0, 1001);
    }

    int count = array.Count(n => n == X);
    Console.WriteLine($"Кол элемент равных {X} = {count}");
}