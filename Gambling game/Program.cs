namespace Gamble
{
    class PrimeShiz
    {
        int num;
        public PrimeShiz(int numIn)
        {
            this.num = numIn;
        }
        public bool isPrime()
        {
            bool yeMan = false;
            if (num == 0 || num == 1)
            {
                Console.WriteLine(num1 + " is not prime number");
                Console.ReadLine();
            }
            else
            {
                for (int a = 2; a <= num / 2; a++)
                {
                    if (num1 % a == 0)
                    {
                        yeMan = false;
                        
                    }
                    else
                    {
                        yeMan = true;
                    }

                }
                return yeMan == true? true:false;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            global::System.Console.WriteLine("Would you like to play a game?");
            string response = Console.ReadLine();
            while (response.ToLower() == "yes")
            {
                global::System.Console.WriteLine("Choose num between 0 and 30");
                int res = Console.ReadLine();
                if (res < 0 || res > 30)
                {
                    global::System.Console.WriteLine("It's not a hard task are you dumb?");
                }
                else
                {
                    Random rng = new Random();
                    nextRes = rng.Next(0, 30);
                    int multiplier = 1;
                    if (nextRes == res)
                    {
                        multiplier *= nextRes % 2 == 0 ? 2 : 1;
                        multiplier *= nextRes % 10 == 0 ? 3 : 1;
                        multiplier *= nextRes.IsPrime() ? 5 : 1;
                        multiplier *= nextRes < 5 ? 2 : 1;
                        global::System.Console.WriteLine("Your initial investment is now {0}x. Would you like to play again?", multiplier);
                        response = Console.ReadLine();
                    }
                    else
                    {
                        global::System.Console.WriteLine("You lost everything lol");
                        response = "no";
                    }
                    
                }
            }
        }
    }
}