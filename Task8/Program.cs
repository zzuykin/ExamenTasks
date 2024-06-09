var item = new MyCLass<MyBaseClass>(new MyBaseClass());
var item2 = new MyCLass<MyOtherClass>(new MyOtherClass());

//var item3 = new MyCLass<int>(); WRONG


public class MyCLass<T> where T: MyBaseClass
{
    public MyCLass(T value)
    {
        Value = value;
    }

    public T Value { get; set; }

}

public class MyBaseClass
{
    private string name { get; set; }

    private int age { get; set; }

    public MyBaseClass(string Name, int Age)
    {
        name = Name;
        age = Age;
    }
    public MyBaseClass() { }
}

public class MyOtherClass : MyBaseClass
{

}
