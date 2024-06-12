
var pub = new Publisher();
pub.MyEvent += MyFunc;
pub.RaseEvent(25);
pub.MyEvent -= MyFunc;

void MyFunc(int x)
{
    Console.WriteLine($"My num is {x}");
}
public class Publisher
{
    public delegate void PubDelegate(int x);

    private PubDelegate myEvent;

    public event PubDelegate MyEvent
    {
        add
        {
            myEvent += value;
            Console.WriteLine("Успешно подписался");
        }
        remove
        {
            myEvent -= value;
            Console.WriteLine("Отписка");
        }
    }
    public void RaseEvent(int x)
    {
        if (myEvent != null)
        {
            myEvent(x);
        }
    }
}


