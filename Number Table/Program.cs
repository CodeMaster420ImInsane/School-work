using System;
namespace Program
{
    class Program
    {
        private int naturalNumber;
        private string symbol;
        private int[,] array { get; } //int[,] means 2D array
        public Program(int num, string symbol)
        {
            this.naturalNumber = num;
            this.array = new int[num + 1, num + 1]; 
            this.symbol = symbol;
        }
        public string OutputTable()
        {
            string table = "";
            int count = 0;
            int row = 0;
            foreach (int i in this.array)
            {

                if (count <= naturalNumber)
                {
                    table += i.ToString() + " ";

                }
                else
                {
                    row++;
                    table += "\n";
                    table += i.ToString() + " ";
                    count = 0;
                }
                count++;


            }
            return table;
        }
        public void GenerateTable()
        {
            for (int x = 0; x <= naturalNumber; x++)
            {
                for (int y = 0; y <= naturalNumber; y++)
                {
                    switch (symbol)
                    {
                        case "+":
                            this.array[x, y] = x + y;
                            break;
                        case "-":
                            this.array[x, y] = x - y;
                            break;
                        case "*":
                            this.array[x, y] = x * y;
                            break;
                        case "/":
                            if (y == 0)
                            {
                                this.array[x, y] = 0;
                            }
                            else
                            {
                                this.array[x, y] = x / y;
                            }
                            break;
                    }

                }
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Choose symbol");
            String symbol = Console.ReadLine();
            Console.WriteLine("Choose natural number");
            int num = int.Parse(Console.ReadLine());
            Program blahGen = new Program(num, symbol);
            blahGen.GenerateTable();
            Console.WriteLine(blahGen.OutputTable());
        }
    }
   
}