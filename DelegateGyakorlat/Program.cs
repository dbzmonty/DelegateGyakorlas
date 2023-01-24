using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateGyakorlat
{
    public delegate double ShippingCalc(int price);

    internal class Program
    {
        static double Zone1(int price)
        {
            return price * 0.25;
        }

        static double Zone2(int price)
        {
            return (price * 0.12) + 25;
        }

        static double Zone3(int price)
        {
            return price * 0.08;
        }

        static double Zone4(int price)
        {
            return (price * 0.04) + 25;
        }

        static void Main(string[] args)
        {
            string zone = String.Empty;
            string price = String.Empty;
            bool exitProgram = false;
            ShippingCalc sc = null;

            do
            {
                Console.WriteLine("What is the destination zone?");
                zone = Console.ReadLine();
                if (!zone.Equals("exit"))
                {
                    switch (zone.ToLower())
                    {
                        case "zone1":
                            {
                                sc = Zone1;
                            }
                            break;
                        case "zone2":
                            {
                                sc = Zone2;
                            }
                            break;
                        case "zone3":
                            {
                                sc = Zone3;
                            }
                            break;
                        case "zone4":
                            {
                                sc = Zone4;
                            }
                            break;
                        default:
                            {
                                Console.WriteLine("There's no such zone!");
                                continue;
                            }
                    }
                
                    Console.WriteLine("What is the item price?");
                    price = Console.ReadLine();
                    if (!price.Equals("exit"))
                    {
                        int iprice;
                        bool validPrice = int.TryParse(price, out iprice);
                        if (validPrice)
                        {
                            Console.WriteLine("Shipping fee is: " + sc(iprice).ToString("0.##"));
                        }
                        else
                        {
                            Console.WriteLine("Invalid item price!");
                        }
                    }
                    else
                        exitProgram = true;
                }
                else
                    exitProgram = true;
            }
            while (!exitProgram);

            Console.WriteLine("Program exited");
            Console.ReadLine();
        }
    }
}
