using System;
using System.Text.RegularExpressions;
namespace ConsoleApp
{
    class Dates
    {
        private int day;
        private string month;
        private int year;
        public Dates(int day, string month, int year)
        {
            this.day = day;
            this.month = month;
            this.year = year;
        }
        public Boolean isValid()
        {
            switch (month.ToLower())
            {
                case "january":
                    return day <= 31 ? true : false;
                    break;
                case "february":
                    if (year % 4 == 0)
                    {
                        return day <= 29 ? true : false;
                    }
                    else
                    {
                        return day <= 28 ? true : false;
                    }
                    break;
                case "march":
                    return day <= 31 ? true : false;
                    break;
                case "april":
                    return day <= 30 ? true : false;
                    break;
                case "may":
                    return day <= 31 ? true : false;
                    break;
                case "june":
                    return day <= 30 ? true : false;
                    break;
                case "july":
                    return day <= 31 ? true : false;
                    break;
                case "august":
                    return day <= 31 ? true : false;
                    break;
                case "september":
                    return day <= 30 ? true : false;
                    break;
                case "october":
                    return day <= 31 ? true : false;
                    break;
                case "november":
                    return day <= 30 ? true : false;
                    break;
                case "december":
                    return day <= 31 ? true : false;
                    break;
                default:
                    return false;
                    break;
            }
        }
        public String getDay()
        {
            Dictionary<String, int> getMonth = new Dictionary<String, int>();
            getMonth.Add("january", 1);
            getMonth.Add("february", 2);
            getMonth.Add("march", 3);
            getMonth.Add("april", 4);
            getMonth.Add("may", 5);
            getMonth.Add("june", 6);
            getMonth.Add("july", 7);
            getMonth.Add("august", 8);
            getMonth.Add("september", 9);
            getMonth.Add("october", 10);
            getMonth.Add("november", 11);
            getMonth.Add("december", 12);
            DateTime date = new DateTime(year, getMonth[month.ToLower()], day);
            return date.ToString("dddd");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Write a date in the format {20 March 1998}");
            string[] thingy = Console.ReadLine().Split(' ');
            Dates newObject = new Dates(int.Parse(thingy[0]), thingy[1], int.Parse(thingy[2]));
            if (newObject.isValid() == true)
            {
                Console.WriteLine(newObject.getDay());
            }
            else
            {
                Console.WriteLine("Please enter a valid date.");
            }
        }
    }
}
// alternatively I could've written:

// Console.WriteLine("Enter a date in the format {20/3/1998}");
// string[] array = new Console.ReadLine().Split('/');
// DateTime object = new DateTime(array[2], array[1], array[0]);
// try
//{
// Console.WriteLine(object.ToString("dddd"));
//}
//catch
//{
//Console.WriteLine("Please enter a valid date");
//}
