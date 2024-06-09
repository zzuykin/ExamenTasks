
var cat = new Cat() { hand = 4 };

cat.SayHi();
cat.SayHand();
public abstract class Animal
{
    public int hand { get; set; }
    public abstract void SayHi();

    public virtual void SayHand()
    {
        Console.WriteLine($"I have {hand} hands");
    }
}


public class Cat : Animal
{
    public override void SayHi()
    {
        Console.WriteLine("Myau!");
    }

    public override void SayHand()
    {
        Console.WriteLine($"I have {hand} hands Mayu!!!");
    }
}