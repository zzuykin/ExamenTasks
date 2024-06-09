MyDelegate1 del = MyFunc1;
MyDelegate2 del2 = MyFunc2;

int[] arrray = { 2, 5, 7, 8, 4 };

del.Invoke(25,"aboba", true);
int num = del2.Invoke(arrray, false);
Console.WriteLine(num);

void MyFunc1(int age, string mes, bool isBoy)
{
    if (isBoy)
    {
        Console.WriteLine($"Привет парень тебе уже {age} лет, твоё поздравление" + mes);
    }
    else
    {
        Console.WriteLine($"Привет девчёнка тебе уже {age} лет, твоё поздравление" + mes);
    }
}

int MyFunc2(int[] array, bool fl)
{
    int sum = 0;
    if (fl)
    {
        foreach(int i in array)
        {
            if (i % 2 == 0)
            {
                sum += i;
            }
        }
    }
    else
    {
        foreach(int i in array)
        {
            sum += i;
        }
    }
    return sum;
}

delegate void MyDelegate1(int x, string mes, bool fl);
delegate int MyDelegate2(int[] array, bool fl);