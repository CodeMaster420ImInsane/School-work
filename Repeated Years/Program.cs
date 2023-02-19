using System;
class Program
{
    static void Main(string[] args)
    {
        var h = new HashSet<int>();
        Console.WriteLine("Choose a year");
        String answer = Console.ReadLine();
        List<int> list = new List<int>();
        for (int i = 0; i <= int.Parse(answer); i++)
        {
            Char[] jb = i.ToString().ToCharArray();
            for (int p = 0; p<i.ToString().Length; p++)
            {
                for (int j =p+1; j<i.ToString().Length; j++)
                {
                    if (jb[p] == jb[j])
                    {
                        h.Add(i);
                    }
                }
            }
        }
        int[] removeDuplicates = h.ToArray();
        Console.WriteLine("Out of {0} years, {1} have repeated digits.", answer,removeDuplicates.Count().ToString());
    }
}