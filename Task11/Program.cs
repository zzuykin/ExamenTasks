
var pub = new Publisher();
pub.MyEvent += MyFunc;
pub.RaseEvent(25);

void MyFunc(int x)
{
    Console.WriteLine($"My num is {x}");
}
public class Publisher
{
    public delegate void PubDelegate(int x);

    public event PubDelegate MyEvent;

    public void RaseEvent(int x)
    {
        if (MyEvent != null)
        {
            MyEvent(x);
        }
    }
}


