using System;
namespace FruitMachine
{
    class Program
    {

        static void Main(string[] args)
        {
            double balance = 100;
            String[] bhk = new String[3];
            String[] options = new String[] { "Cherry", "Bell", "Lemon", "Orange", "Star", "Skull" };
            Random RNG = new Random();
            Console.WriteLine("Would you like to play? Current balance is {0:C2}", (balance/100));
            String response = Console.ReadLine();
            while (balance > 0 && response.ToLower() == "yes")
            {
                balance -= 20;
                bhk[0] = options[RNG.Next(0,5)];
                bhk[1] = (options[RNG.Next(0, 5)]);
                bhk[2] =(options[RNG.Next(0, 5)]);
                Console.WriteLine("First roll: {0}, Second roll: {1}, Third roll: {2}", bhk[0], bhk[1], bhk[2]);
                if (bhk[0] == "Bell" && bhk[1] == "Bell" && bhk[3] == "Bell")
                {
                    balance += 500;
                }
                else if (bhk[0] == "Skull" && bhk[1] == "Skull" && bhk[3] == "Skull")
                {
                    balance = 0;
                }
                else if (bhk[0] == "Skull" && bhk[1] == "Skull" || bhk[0] == "Skull" && bhk[2] == "Skull" || bhk[1] == "Skull" && bhk[2] == "Skull")
                {
                    balance = balance > 100 ? balance - 100 : 0;
                }
                else if (bhk[0].Equals(bhk[1]) && bhk[1].Equals(bhk[2]))
                {
                    balance += 100;
                }
                else if (bhk[0].Equals(bhk[1]) || bhk[1].Equals(bhk[2]) || bhk[0].Equals(bhk[2]))
                {
                    balance += 50;
                }
                Console.WriteLine("Would you like to play again? Current balance is {0:C2}", (balance / 100));
                response = Console.ReadLine();
            }
            Console.WriteLine("Final balance: {0:C2}", balance>0?balance/100:0);
        }
    }
}