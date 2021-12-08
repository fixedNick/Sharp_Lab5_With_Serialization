using System;
using System.IO;

namespace Sharp_Lab5_With_Serialization
{
    public class Apple : Fruit
    {
        public string Color;
        public int Trees;
        public int Seed;

        public Apple() { }
        public override void EnterFruitData()
        {
            base.EnterFruitData();
            EnterAppleData();
        }

        private void EnterAppleData()
        {
            Console.Write("Enter apple trees: ");
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int result) == true)
                {
                    Trees = result;
                    break;
                }
                Console.WriteLine("Invalid value");
            }

            while (true)
            {
                Console.Write("Enter apple seed: ");
                if (int.TryParse(Console.ReadLine(), out int seed) == true)
                {
                    Seed = seed;
                    break;
                }
                Console.WriteLine("Invalid value");
            }
        }
        public override void PrintFruitData()
        {
            base.PrintFruitData();
            Console.WriteLine($"Apple additional rows | Trees: [{Trees}] | Seed: [{Seed}]");
        }
        public override void ReadDataFromFile(string filepath)
        {
            base.ReadDataFromFile(filepath);

            var file_data = File.ReadAllText(filepath).Split('|');
            Name = file_data[0];
            Price = Convert.ToDouble(file_data[1]);
            Amount = Convert.ToInt32(file_data[2]);
            Color = file_data[3];
            Trees = Convert.ToInt32(file_data[4]);
            Seed = Convert.ToInt32(file_data[5]);
        }
        public override void SaveDataToFile(string filepath)
        {
            string filetext = Name + "|" + Price + "|" + Amount + "|" + Color + "|" + Trees + "|" + Seed;
            File.WriteAllText(filepath, filetext);
        }
    }
}
