ManualResetEvent thread = new ManualResetEvent(false);

while (true)
{
    ThreadPool.QueueUserWorkItem(new WaitCallback((object x) =>
    {
        Enter();
    }));
    Console.ReadLine();
    thread.Set();
}


void Enter()
{
    thread.WaitOne();
    thread.Reset();

    Console.WriteLine("Enter");
}