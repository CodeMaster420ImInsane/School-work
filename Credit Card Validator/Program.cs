using System;
namespace DKN
{
    class DKN
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Write a credit card number");
            String check = Console.ReadLine();
            int checkSum = 0;
            if (check.Length <= 10 && check.Length >= 7)
            {
                for (int i = check.Length-1; i > 0; i -= 2)
                {
                    checkSum += (check[i] - '0');
                }
                for (int j= check.Length-2; j>=0; j -= 2)
                {
                    int val = ((check[j] - '0') * 2);
                    while (val > 0)
                    {
                        checkSum += (val % 10);
                        val /= 10;
                    }
                }
                Console.WriteLine(checkSum % 10 ==0);

            }
            
        }
    }
}