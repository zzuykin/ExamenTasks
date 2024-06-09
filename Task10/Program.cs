
IMyClass item = new MyClass();
item.SayHi();
item.SaySomeShit();
item.SayBye();

public interface IMyClass
{
    public void SayHi();

    public void SayBye();

    public void SaySomeShit();
}



public class MyClass : IMyClass
{
    public void SayHi()
    {
        Console.WriteLine("Hi");
    }

    public void SayBye()
    {
        Console.WriteLine("Bye!");
    }

    public void SaySomeShit()
    {
        Console.WriteLine("You are shit");
    }
}