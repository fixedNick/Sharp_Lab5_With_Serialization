//#define _SAVE_READ_SINGLE_FILES_ // - Тестирование записи apple/fruit в .txt одиночные файлы и считывания из них
using System;

namespace Sharp_Lab5_With_Serialization
{
    class Program
    {
        static void PrintMenu(out int operation)
        {
            Console.WriteLine("Plate methods:");
            Console.WriteLine("[0] Exit");
            Console.WriteLine("[1] Add new fruit");
            Console.WriteLine("[2] Print fruits list");
            Console.WriteLine("[3] Read fruits from file");
            Console.WriteLine("[4] Save fruits into file");
            Console.WriteLine("[5] Clear fruits list");
            Console.WriteLine("[6] Add new apple");

            while (true)
            {
                Console.Write("Enter your choice[0-6]: ");
                if (int.TryParse(Console.ReadLine(), out operation) == true)
                    break;
                else Console.WriteLine("Invalid Operation");
            }
        }

        static void Main(string[] args)
        {
#if _SAVE_READ_SINGLE_FILES_
            Apple apple = new Apple();
            apple.EnterAppleData();
            Fruit fruit = new Fruit();
            fruit.EnterFruitData();

            apple.SaveDataToFile("apple.txt");
            fruit.SaveDataToFile("fruit.txt");

            Apple nApple = new Apple();
            nApple.ReadDataFromFile("apple.txt");
            Fruit nFruit = new Fruit();
            nFruit.ReadDataFromFile("fruit.txt");

            nApple.PrintFruitData();
            nFruit.PrintFruitData();
#endif
            Plate plate = new Plate();
            while (true)
            {
                PrintMenu(out int operation);
                switch (operation)
                {
                    case 0: return;
                    case 1:
                        {
                            plate.AddFruit(isApple: false);
                            break;
                        }
                    case 2:
                        {
                            plate.PrintFruits();
                            break;
                        }
                    case 3:
                        {
                            plate.ReadFruitsFromFile("fruits");
                            break;
                        }
                    case 4:
                        {
                            plate.SaveFruitsToFile("fruits");
                            break;
                        }
                    case 5:
                        {
                            plate.ClearFruits();
                            break;
                        }
                    case 6:
                        {
                            plate.AddFruit(isApple: true);
                            break;
                        }
                }
            }
        }
    }
}
