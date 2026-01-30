/*using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Text;

namespace CSharp
{
    internal class ZomatoApp
    {
        public static void Main(string[] args)
        {
            Zomato zm = new Zomato();
            int choice;
            do
            {
                Console.WriteLine("Welcome To Zomato!!");
                Console.WriteLine("1.Show Menu");
                Console.WriteLine("2.Add to Cart");
                Console.WriteLine("3. Exit");
                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        zm.ShowMenu();
                        break;
                    case 2:
                        Console.WriteLine("1. Add one item, 2. Add Multiple Items");
                        int ch = Convert.ToInt32(Console.ReadLine());
                        switch (ch)
                        {
                            case 1:
                                Console.WriteLine("Enter the item code: ");
                                int code=Convert.ToInt32(Console.ReadLine());
                                zm.AddToCart(code);
                                break;
                            case 2:
                                Console.WriteLine("Enter the item code: ");
                                int c= Convert.ToInt32(Console.ReadLine());
                                int quantity=Convert.ToInt32(Console.ReadLine());
                                zm.AddToCart(c, quantity);
                                break;
                        }
                        break;
                }
            }while(choice != 3) ;

            Console.WriteLine("Enter the final amount: " + zm.GetFinalAmount());
        }
        
    }
} 
*/