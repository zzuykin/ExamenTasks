
var item1 = new MyClass(2, 5);
var item2 = new MyClass(1, 3);

Console.WriteLine(item1 + item2);

public class MyClass
{
    public MyClass(int x, int y)
    {
        this.x = x; this.y = y;
    }

    public int x { get; set; }
    public int y { get; set; }

    public static int operator + (MyClass item1, MyClass item2)
    {
        return item1.x + item2.x + item2.y + item1.y;
    } 

}