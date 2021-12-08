using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Sharp_Lab5_With_Serialization
{
    class Plate
    {
        private List<Fruit> Fruits = new List<Fruit>();

        public void AddFruit(Fruit fruit) => Fruits.Add(fruit);
        public void AddFruit(string name, double price, int amount)
        {
            Fruit fruit = new Fruit(name, price, amount);
            AddFruit(fruit);
        }
        public void AddFruit(bool isApple)
        {
            Fruit fruit;
            if (isApple) fruit = new Apple();
            else fruit = new Fruit();

            fruit.EnterFruitData();
            AddFruit(fruit);
        }
        public void PrintFruits()
        {
            foreach (var fruit in Fruits)
                fruit.PrintFruitData();
        }
        public void ClearFruits()
        {
            Fruits.Clear();
            Console.WriteLine("Fruits list cleared successfully");
        }
        public void SaveFruitsToFile(string directory = "")
        {
            if (directory.Length > 0 && Directory.Exists(directory) == false)
                Directory.CreateDirectory(directory);

            XmlSerializer formatter;
            int appleCounter = 0, fruitCounter = 0;
            foreach (var fruit in Fruits)
            {
                string filename = directory + "/";
                if (fruit is Apple)
                {
                    formatter = new XmlSerializer(typeof(Apple));
                    filename += $"apple_{appleCounter++}.xml";
                }
                else
                {
                    formatter = new XmlSerializer(typeof(Fruit));
                    filename += $"fruit_{fruitCounter++}.xml";
                }

                using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
                {
                    formatter.Serialize(fs, fruit);
                }
            }
        }
        public void ReadFruitsFromFile(string directory = "")
        {
            if (directory.Length > 0 && Directory.Exists(directory) == false)
                Directory.CreateDirectory(directory);

            var files = Directory.GetFiles(directory.Length == 0 ? Directory.GetCurrentDirectory() : directory);
            foreach (var file in files)
            {
                XmlSerializer formatter;
                bool isApple;

                if (file.Split('_')[0].ToLower().Contains("apple".ToLower())) isApple = true;
                else isApple = false;

                using (FileStream fs = new FileStream(file, FileMode.OpenOrCreate))
                {
                    if (isApple)
                    {
                        formatter = new XmlSerializer(typeof(Apple));
                        Apple apple = (Apple)formatter.Deserialize(fs);
                        Fruits.Add(apple);
                    }
                    else
                    {
                        formatter = new XmlSerializer(typeof(Fruit));
                        Fruit fruit = (Fruit)formatter.Deserialize(fs);
                        Fruits.Add(fruit);
                    }
                }
            }
        }
    }
}
