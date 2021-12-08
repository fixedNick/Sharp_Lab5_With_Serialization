using System;
using System.IO;

namespace Sharp_Lab5_With_Serialization
{
    [Serializable]
    public class Fruit
    {
        public string Name;
        public string Color;
        public int Price;
        public double Weight;

        public Fruit()
        {
            //EnterFruitData();
        }
        public Fruit(string name, string color, int price, double weight)
        {
            Name = name;
            Color = color;
            Price = price;
            Weight = weight;
        }

        public virtual void PrintFruitData()
        {
            Console.WriteLine($"Name: [{Name}] | Color: [{Color}] | Price: [{Price}] | Weigth: [{Weight}]");
        }
        public virtual void EnterFruitData()
        {
            Console.WriteLine("[Fill rows below to your new fruit]");
            Console.Write("Enter name: ");
            Name = Console.ReadLine();
            Console.Write("Enter color: ");
            Color = Console.ReadLine();

            while (true)
            {
                Console.Write("Enter price: ");
                if (int.TryParse(Console.ReadLine(), out int price) == true)
                {
                    Price = price;
                    break;
                }
                Console.WriteLine("Invalid value");
            }
            while (true)
            {
                Console.Write("Enter weight: ");
                if (double.TryParse(Console.ReadLine(), out double weight) == true)
                {
                    Weight = weight;
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
            Color = file_data[1];
            Price = Convert.ToInt32(file_data[2]);
            Weight = Convert.ToDouble(file_data[3]);
        }

        public virtual void SaveDataToFile(string filepath)
        {
            string filetext = Name + "|" + Color + "|" + Price + "|" + Weight;
            File.WriteAllText(filepath, filetext);
        }
    }
}
