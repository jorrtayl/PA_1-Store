/*
 * Name: Jordan Taylor
 * Date: 01 / 19 / 2021
 * Description: This program allows the user to do things that a customer would be able to do in a store 
 * such as: check the items, purchase items, check the price, and they receive information about their purchases (receipts)
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PA_1_Getting_Started
{
    abstract class Item
    {
        // Base Constructor :)
        // I can put this above the variables because this is C#, not C++
        public Item()
        {
            Type = "";
            Name = "";
            Quantity = 0;
            Price = 0.0;
        }

        public Item(string Type, string Name, int Quantity, double Price)
        {
            this.Type = Type;
            this.Name = Name;
            this.Quantity = Quantity;
            this.Price = Price;
        }

        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public int Quantity
        {
            get { return _quantity; }
            set { _quantity = value; }
        }
        public double Price
        {
            get { return _price; }
            set { _price = value; }
        }

        public static void menu()
        {
            Console.WriteLine("");
            Console.WriteLine("1. Check the price of the item.");
            Console.WriteLine("2. Display the information on the item.");
            Console.WriteLine("3. Purchase the item.");
            Console.WriteLine("4. Quit");
        }

        protected string _type, _name;
        protected int _quantity;
        protected double _price;

        public abstract void checkPrice();
        public abstract void printInfo();
        public abstract void purchase();
    }

    class Vegetable : Item
    {
        public override void checkPrice()
        {
            Console.WriteLine("Price of Vegetable: " + Price);
        }

        public override void printInfo()
        {
            Console.WriteLine("Item Type: " + Type);
            Console.WriteLine("Item Name: " + Name);
            Console.WriteLine("Item Quantity: " + Quantity);
            Console.WriteLine("Item Price: " + Price);

        }

        public override void purchase()
        {
            if (Quantity > 0)
            {
                Quantity--;
                Console.WriteLine(Quantity + " Remaining");
            }
            else
                Console.WriteLine("Not enough in inventory.");
        }
    }

    class Textbook : Item
    {
        public override void checkPrice()
        {
            Console.WriteLine("Price of Textbook: " + Price);
        }

        public override void printInfo()
        {
            Console.WriteLine("Item Type: " + Type);
            Console.WriteLine("Item Name: " + Name);
            Console.WriteLine("Item Quantity: " + Quantity);
            Console.WriteLine("Item Price: " + Price);

        }

        public override void purchase()
        {
            if (Quantity > 0)
            {
                Quantity--;
                Console.WriteLine(Quantity + " Remaining");
            }
            else
                Console.WriteLine("Not enough in inventory.");
        }
    }

    class Game : Item
    {
        public override void checkPrice()
        {
            Console.WriteLine("Price of Game: " + Price);
        }

        public override void printInfo()
        {
            Console.WriteLine("Item Type: " + Type);
            Console.WriteLine("Item Name: " + Name);
            Console.WriteLine("Item Quantity: " + Quantity);
            Console.WriteLine("Item Price: " + Price);

        }

        public override void purchase()
        {
            if (Quantity > 0)
            {
                Quantity--;
                Console.WriteLine(Quantity + " Remaining");
            }
            else
                Console.WriteLine("Not enough in inventory.");
        }

        class Program
        {
            static void Main(string[] args)
            {

                int switchItem = 0, switchFunction = 0;
                string item = "";

                Item purchase = new Vegetable();

                bool firstWhile = true;

                while (firstWhile)
                {
                    Console.WriteLine("Welcome to Bob's store! Please select an option below by typing in the corresponding number.");
                    Console.WriteLine("To begin, please select what item you are buying.");
                    Console.WriteLine("1. Vegetable");
                    Console.WriteLine("2. Textbook");
                    Console.WriteLine("3. Game");

                    switchItem = Convert.ToInt32(Console.ReadLine());


                    // This work but I wasn't for sure if Dr. Ericson would accept it.
                    /*if (switchItem > 3 || switchItem < 0)
                        continue;

                    purchase = (switchItem == 1) ? new Vegetable() : (switchItem == 2) ? new Textbook() : (Item)new Game();
                    Console.WriteLine("What type of " + purchase.GetType().Name + " are you buying?");

                    purchase.Type = Console.ReadLine();

                    string message = (switchItem == 1) ? "What brand name of " : (switchItem == 2) ? "What genre of " : "What is the name of the ";
                    Console.WriteLine(message + purchase.Type + '?');
                    purchase.Name = Console.ReadLine();*/

                    switch (switchItem)
                    {
                        case 1:
                            item = "Vegetable";
                            Console.WriteLine("What type of " + item + " are you buying?");
                            purchase = new Vegetable();
                            purchase.Type = Console.ReadLine();

                            Console.WriteLine("What brand name of " + purchase.Type + '?');
                            purchase.Name = Console.ReadLine();

                            firstWhile = false;
                            break;

                        case 2:
                            item = "Textbook";
                            Console.WriteLine("What type of " + item + " are you buying?");
                            purchase = new Textbook();
                            purchase.Type = Console.ReadLine();

                            Console.WriteLine("What is the name of the " + purchase.Type + '?');
                            purchase.Name = Console.ReadLine();

                            firstWhile = false;
                            break;
                        case 3:
                            item = "Game";
                            Console.WriteLine("What type of " + item + " are you buying?");
                            purchase = new Game();
                            purchase.Type = Console.ReadLine();

                            Console.WriteLine("What is the name of the " + purchase.Type + '?');
                            purchase.Name = Console.ReadLine();

                            firstWhile = false;
                            break;
                        default:
                            Console.WriteLine("Item choice does not exist!");
                            Console.WriteLine("Select a number 1 - 3.");
                            break;
                    }
                    Random r = new Random(DateTime.Now.Second);
                    purchase.Price = r.Next(20, 100) + Math.Round(r.NextDouble(), 2, MidpointRounding.AwayFromZero);
                    purchase.Quantity = r.Next(1, 10);
                }

                while (true)
                {
                    Item.menu();
                    switchFunction = Convert.ToInt32(Console.ReadLine());

                    switch (switchFunction)
                    {
                        case 1:
                            purchase.checkPrice();
                            break;

                        case 2:
                            purchase.printInfo();
                            break;
                        case 3:
                            purchase.purchase();
                            break;
                        case 4:
                            Console.WriteLine("Closing\n");
                            return;
                        default:
                            Console.WriteLine("Invalid option, please select another.");
                            break;
                    }
                }
            }
        }
    }
}