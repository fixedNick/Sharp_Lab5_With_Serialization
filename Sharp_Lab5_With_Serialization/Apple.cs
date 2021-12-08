using System;
using System.IO;

namespace Sharp_Lab5_With_Serialization
{
    public class Apple : Fruit
    {
        public string Variety;
        public double Radius;

        public Apple() { } 
        public override void EnterFruitData()
        {
            base.EnterFruitData();
            EnterAppleData();
        }
        
        private void EnterAppleData()
        {
            Console.Write("Enter apple variety: ");
            Variety = Console.ReadLine();

            while (true)
            {
                Console.Write("Enter apple radius: ");
                if (double.TryParse(Console.ReadLine(), out double radius) == true)
                {
                    Radius = radius;
                    break;
                }
                Console.WriteLine("Invalid value");
            }
        }
        public override void PrintFruitData()
        {
            base.PrintFruitData();
            Console.WriteLine($"Apple additional rows | Variety: [{Variety}] | Radius: [{Radius}]");
        }
        public override void ReadDataFromFile(string filepath)
        {
            base.ReadDataFromFile(filepath);
            var file_data = File.ReadAllText(filepath).Split('|');
            Name = file_data[0];
            Color = file_data[1];
            Price = Convert.ToInt32(file_data[2]);
            Weight = Convert.ToInt32(file_data[3]);
            Variety = file_data[4];
            Radius = Convert.ToDouble(file_data[5]);
        }
        public override void SaveDataToFile(string filepath)
        {
            string filetext = Name + "|" + Color + "|" + Price + "|" + Weight + "|" + Variety + "|" + Radius;
            File.WriteAllText(filepath, filetext);
        }
    }
}
