using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    class Program
    {
        static void Main(string[] args)
        {
            MainMenuUI.ShowMenu();
        }
    }
}


/*
     public static void PrintMenu(Dictionary<int, string> menuOptions)
     {
         Console.Clear();
         Console.WriteLine("Choose an option: \n0 Exit");

         foreach (KeyValuePair<int, string> item in menuOptions)
         {
             Console.WriteLine($"{item.Key} {item.Value}");
         }
         Console.Write("\r\nSelect an option: ");
     }
*/
