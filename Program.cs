using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Assignment21
{
    internal class Program
    {

        public class KidsLearningSystem
        {
            private static List<string> fruits = new List<string> { "Apple", "Banana", "Orange", "Grapes", "Strawberry", "Watermelon", "Pineapple", "Mango", "Kiwi", "Peach" };
            private static List<string> days = new List<string> { "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday" };
            private static List<string> months = new List<string> { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
            private static Dictionary<string, string> words = new Dictionary<string, string>
               {
                    { "Annoy", "Making someone angry" },
                    { "Calm",  "Free of any disturbance"},
                    { "Leader" ,"An individual who commands a group" },
                    { "Protect"," Keep someone safe from harm or injury" },
                    { "Respect", "Admire someone because of their abilities or achievements" }
                };

            private static readonly object lockObject = new object();

            public static void Main(string[] args)
            {
                Console.WriteLine("----------------Welcome to Kids Learning-------------------------");

                Thread daysThread = new Thread(DisplayDays);
                Thread monthsThread = new Thread(DisplayMonths);
                Thread fruitsThread = new Thread(DisplayFruits);
                Thread wordsThread = new Thread(DisplayWords);

                daysThread.Start();
                Thread.Sleep(2000);
                monthsThread.Start();
                Thread.Sleep(5000);
                fruitsThread.Start();
                wordsThread.Start();

                daysThread.Join();
                monthsThread.Join();
                fruitsThread.Join();
                wordsThread.Join();
                Console.ReadKey();
            }

            private static void DisplayDays()
            {
                lock (lockObject)
                {
                    foreach (string day in days)
                    {
                        Console.WriteLine(day);
                        Thread.Sleep(2000);
                    }
                }
            }

            private static void DisplayMonths()
            {
                lock (lockObject)
                {
                    foreach (string month in months)
                    {
                        Console.WriteLine(month);
                        Thread.Sleep(2000);
                    }
                }
            }

            private static void DisplayFruits()
            {
                lock (lockObject)
                {
                    foreach (string fruit in fruits)
                    {
                        Console.WriteLine(fruit);
                        Thread.Sleep(1000);
                    }
                }
            }

            private static void DisplayWords()
            {
                lock (lockObject)
                {
                    foreach (KeyValuePair<string, string> word in words)
                    {
                        Console.WriteLine("{0}: {1}", word.Key, word.Value);
                        Thread.Sleep(1000);
                    }
                }
            }
         
        }
    }
}
