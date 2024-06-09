var item = new MyClass<string>();
item.WhatType();

public class MyClass<T>
{
    public static T? type;

    public void WhatType()
    {
        Console.WriteLine(typeof(T));
    }
}