ManualResetEvent thread = new ManualResetEvent(false);
ThreadPool.QueueUserWorkItem(new WaitCallback((object x) =>
{
    Enter();
}));

while (true)
{
    Console.ReadLine();
    thread.Set();
}


void Enter()
{
    while (true)
    {
        thread.WaitOne();
        thread.Reset();
        Console.WriteLine("Enter");
    }
}