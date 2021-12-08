using System;
using System.IO;

namespace Sharp_Lab5_With_Serialization
{
    [Serializable]
    public class Fruit
    {
        public string Name;
        public double Price;
        public int Amount;

        public Fruit()
        {
            //EnterFruitData();
        }
        public Fruit(string name, double price, int amount)
        {
            Name = name;
            Price = price;
            Amount = amount;
        }

        public virtual void PrintFruitData()
        {
            Console.WriteLine($"Name: [{Name}] |  Price: [{Price}] | Amount: [{Amount}]");
        }
        public virtual void EnterFruitData()
        {
            Console.WriteLine("[Fill rows below to your new fruit]");
            Console.Write("Enter name: ");
            Name = Console.ReadLine();

            while (true)
            {
                Console.Write("Enter price: ");
                if (double.TryParse(Console.ReadLine(), out double price) == true)
                {
                    Price = price;
                    break;
                }
                Console.WriteLine("Invalid value");
            }
            while (true)
            {
                Console.Write("Enter amount: ");
                if (int.TryParse(Console.ReadLine(), out int amount) == true)
                {
                    Amount = amount;
                    break;
                }
                Console.WriteLine("Invalid value");
            }

            Console.WriteLine($"Fruit {Name} successfully added");
        }

        public virtual void ReadDataFromFile(string filepath)
        {
            var file_data = File.ReadAllText(filepath).Split('|');
            Name = file_data[0];
            Price= Convert.ToDouble(file_data[2]);
            Amount = Convert.ToInt32(file_data[3]);
        }

        public virtual void SaveDataToFile(string filepath)
        {
            string filetext = Name + "|" + Price + "|" + Amount;
            File.WriteAllText(filepath, filetext);
        }
    }
}
