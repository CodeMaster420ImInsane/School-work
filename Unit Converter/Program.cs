using System;
namespace Conversion
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Choose a unit to convert (metres, litres, degrees celsius, metres squared)");
            String response = Console.ReadLine().ToLower();
            switch (response)
            {
                case "metres":
                    List<String> list = new List<String>();
                    Dictionary<String, double> metreVals = new Dictionary<String, double>();
                    metreVals.Add("feet", 3.28);
                    metreVals.Add("kilometres", 0.001);
                    metreVals.Add("centimetres", 100);
                    metreVals.Add("millimetres", 1000);
                    metreVals.Add("micrometres", 1000000);
                    metreVals.Add("nanometres", 1000000000);
                    metreVals.Add("miles", 0.0062);
                    metreVals.Add("yards", 1.094);
                    metreVals.Add("inchs", 39.37);
                    metreVals.Add("light years", 0.0000000000000001057);
                    Console.WriteLine("Which unit would you like to convert to? Options are: ");
                    foreach (String item in metreVals.Keys)
                    {
                        Console.WriteLine("-" + item.Substring(0,1).ToUpper() + item.Substring(1, item.Length-1));
                        list.Add(item);
                    }
                    String convertedItem = Console.ReadLine().ToLower();
                    if (!list.Contains(convertedItem))
                    {
                        Console.WriteLine("Please choose one of the options provided.");
                    }
                    else
                    {
                        Console.WriteLine("How many metres would you like to convert?");
                        long num = long.Parse(Console.ReadLine());
                        Console.WriteLine("{0} metres is {1} {2}", num, (num * metreVals[convertedItem]), convertedItem);
                    }

                    break;
                case "litres":
                    List<String> litreList = new List<String>();
                    Dictionary<String, double> litreValues = new Dictionary<String, double>();
                    litreValues.Add("gallons", 0.264);
                    litreValues.Add("ounces", 33.81);
                    litreValues.Add("centilitres", 100);
                    litreValues.Add("millilitres", 1000);
                    litreValues.Add("microlitres", 1000000);
                    litreValues.Add("nanolitres", 1000000000);
                    litreValues.Add("kilolitres", 0.001);
                    litreValues.Add("pints", 1.75);
                    litreValues.Add("tablespoons", 66.67);
                    Console.WriteLine("Which unit would you like to convert to? Options are: ");
                    foreach (String item in litreValues.Keys)
                    {
                        Console.WriteLine("-" + item.Substring(0, 1).ToUpper() + item.Substring(1, item.Length - 1));
                        litreList.Add(item);
                    }
                    convertedItem = Console.ReadLine().ToLower();
                    if (!litreList.Contains(convertedItem))
                    {
                        Console.WriteLine("Please choose one of the options provided.");
                    }
                    else
                    {
                        Console.WriteLine("How many litres would you like to convert?");
                        int num = int.Parse(Console.ReadLine());
                        Console.WriteLine("{0} litres is {1} {2}", num, (num * litreValues[convertedItem]), convertedItem);
                    }
                    break;
                case "degrees celsius":
                    List<String> celsiusList = new List<String>();
                    Dictionary<String, double> celsiusValues = new Dictionary<String, double>();
                    celsiusValues.Add("kelvin", 0.264);
                    celsiusValues.Add("fahrenheit", 33.81);
                    Console.WriteLine("Which unit would you like to convert to? Options are: ");
                    foreach (String item in celsiusValues.Keys)
                    {
                        Console.WriteLine("-" + item.Substring(0, 1).ToUpper() + item.Substring(1, item.Length - 1));
                        celsiusList.Add(item);
                    }
                    convertedItem = Console.ReadLine().ToLower();
                    if (!celsiusList.Contains(convertedItem))
                    {
                        Console.WriteLine("Please choose one of the options provided.");
                    }
                    else
                    {
                        Console.WriteLine("How many degrees celsius would you like to convert?");
                        double num = double.Parse(Console.ReadLine());
                        switch (convertedItem)
                        {
                            case "fahrenheit":
                                Console.WriteLine("{0} degrees celsius is {1} fahrenheit", num, (num * 9 / 5) + 32);
                                break;
                            case "kelvin":
                                Console.WriteLine("{0} degrees celsius is {1} kelvin", num, num+273.15);
                                break;
                            default:
                                Console.WriteLine("Please choose one of the options provided.");
                                break;
                        }

                    }
                    break;
                case "metres squared":
                    List<String> msquaredList = new List<String>();
                    Dictionary<String, double> msquaredValues = new Dictionary<String, double>();
                    msquaredValues.Add("square feet", 10.76);
                    msquaredValues.Add("square kilometres", 0.000001);
                    msquaredValues.Add("square centimetres", 10000);
                    msquaredValues.Add("square millimetres", 1000000);
                    msquaredValues.Add("square micrometres", 1000000000000);
                    msquaredValues.Add("square nanometres", 1000000000000000000);
                    msquaredValues.Add("square miles", 0.000000386);
                    msquaredValues.Add("square yards", 1.196);
                    msquaredValues.Add("square inchs", 1550);
                    msquaredValues.Add("square light years", 0.0000000000000000000000000000000112);
                    Console.WriteLine("Which unit would you like to convert to? Options are: ");
                    foreach (String item in msquaredValues.Keys)
                    {
                        Console.WriteLine("-" + item.Substring(0, 1).ToUpper() + item.Substring(1, item.Length - 1));
                        msquaredList.Add(item);
                    }
                    convertedItem = Console.ReadLine().ToLower();
                    if (!msquaredList.Contains(convertedItem))
                    {
                        Console.WriteLine("Please choose one of the options provided.");
                    }
                    else
                    {
                        Console.WriteLine("How many metres would you like to convert?");
                        long num = long.Parse(Console.ReadLine());
                        Console.WriteLine("{0} metres is {1} {2}", num, (num * msquaredValues[convertedItem]), convertedItem);
                    }
                    break;
                default:
                    Console.WriteLine("Please choose one of the options provided.");
                    break;
            }
            
        }
    }
}