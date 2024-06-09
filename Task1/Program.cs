Myclass[] array;
int size;
size = Convert.ToInt32(Console.ReadLine());
array = new Myclass[size];

var rand = new Random();

for (int i = 0; i < size; i++)
{
    array[i] = new Myclass(rand.Next(100), $"Num is {i} ");
}

foreach (var i in array)
{
    Console.WriteLine(i.MyString + Convert.ToString(i.MyInt));
}

public class Myclass
{
    public int MyInt { get; set; }

    public string MyString { get; set; }

    public Myclass(int num, string str)
    {
        MyInt = num;
        MyString = str;
    }
}