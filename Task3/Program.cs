int[] array;
int size = Convert.ToInt32(Console.ReadLine());
array = new int[size];

var rand = new Random();

for (int i = 0; i < size; i++)
{
    array[i] = rand.Next(100);
}

Console.WriteLine(Mediadn.SearchMedian(array));

public static class Mediadn
{
    public static int SearchMedian(int[] array)
    {
        Array.Sort(array);
        return array[array.Length / 2];
    }
}