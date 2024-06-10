var stop = new Object();
bool isEnter = false;
Thread myThread = new Thread(EnterRun);
myThread.Start();

while (true)
{
    Console.ReadLine();
    lock (stop)
    {
        isEnter = true;
        Monitor.Pulse(stop);
    }
}

void EnterRun()
{
    while (true)
    {
        lock (stop)
        {
            while (!isEnter)
            {
                Monitor.Wait(stop);
            }
            isEnter = false;
            Console.WriteLine("Key Enter");
        }
    }
}