var item = new MyClass();
item.InvokePrint("Hello!");

//хз
public class MyClass
{
    private void Print(string message)
    {
        Console.WriteLine(message);
    }

    public void InvokePrint(string mes)
    {
        Print(mes);
    }
}

