using System;
namespace LogicGates
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Choose a logic gate (OR, AND, NAND, XOR, NOT)");
            String gate = Console.ReadLine();
            if (gate.ToUpper() == "NOT")
            {
                Console.WriteLine("Choose a number (0/1)");
                int answer = int.Parse(Console.ReadLine());
                if (answer != 0 && answer != 1)
                {
                    Console.WriteLine("Please choose 0 or 1");
                }
                else
                {
                    Console.WriteLine(answer == 1?"0":"1");
                }
            }
            else
            {
                Console.WriteLine("Choose a number, 0 or 1");
                int firstNum = int.Parse(Console.ReadLine());
                Console.WriteLine("Choose another number, 0 or 1");
                int secondNum = int.Parse(Console.ReadLine());
                if (secondNum!= 0 && secondNum != 1 && firstNum !=0 && firstNum != 0)
                {
                    Console.WriteLine("Please make sure both numbers are either a 0 or 1");
                }
                else
                {
                    switch (gate)
                    {
                        case "AND":
                            Console.WriteLine(!(firstNum == secondNum)?"0":firstNum == 1?"1":"0");
                            break;
                        case "OR":
                            Console.WriteLine(secondNum == 1 || firstNum == 1?"1":"0");
                            break;
                        case "NAND":
                            Console.WriteLine(!(firstNum == secondNum)?"1":firstNum == 1?"0":"1");
                            break;
                        case "XOR":
                            Console.WriteLine(!(firstNum == secondNum)?"1":"0");
                            break;
                        default:
                            Console.WriteLine("Please choose one of the options available");
                            break;
                    }
                }
                
            }
        }
    }
}