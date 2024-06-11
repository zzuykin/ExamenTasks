int X = Convert.ToInt32(Console.ReadLine());
var rand = new Random();
Base[] array1 = new Base[X];
BaseChild[] array2 = new BaseChild[X];
Predicate<int> isTrue = x => x == 1;

for(int i = 0; i < X; i++)
{
    array1[i] = new Base("Base", isTrue(rand.Next(0, 2)));
    array2[i] = new BaseChild("Child", isTrue(rand.Next(0, 2)));
}

if(array1.Count(x => x._bool == true) > array2.Count(x => x._bool == true))
{
    Console.WriteLine("BASE!");
}
else
{
    Console.WriteLine("CHILD!");
}

public class Base
{
    public string _string;
    public bool _bool;

    public Base(string @string, bool @bool)
    {
        _string = @string;
        _bool = @bool;
    }
}

public class BaseChild : Base
{
    public BaseChild(string @string, bool @bool) : base(@string, @bool) { }
}