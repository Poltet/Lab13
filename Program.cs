using System;
using System.Collections.Generic;
using ClassLibrary1;
using ClassLibrary12;

namespace Lab13
{
    public class Program
    {
        static int Number(int minValue, int maxValue, string msg = "") // Ввод числа от minValue доmaxValue
        {
            Console.Write(msg + $" (целое число от {minValue} до {maxValue}): ");
            int number;
            bool isConvert;
            do
            {
                string buf = Console.ReadLine();
                isConvert = int.TryParse(buf, out number);
                if (!isConvert || number < minValue || number > maxValue)
                    Console.WriteLine("Неправильно введено число. \nПопробуйте еще раз.");
            } while (!isConvert || number < minValue || number > maxValue);
            return number;
        }
        /// <summary>
        /// Создание коллекции
        /// </summary>
        static public void CreateCollection(MyObservableCollection<CelestialBody> collection)
        {
            int count = Number(0, 100, "Введите количество элементов коллекции");
            for (int i = 0; i < count; i++)
            {
                CelestialBody celbody = new CelestialBody();
                celbody.RandomInit();
                collection.Add(celbody);
            }
        }
        /// <summary>
        /// Добавление в коллекию
        /// </summary>
        static public void Add(MyObservableCollection<CelestialBody> collection)
        {
            CelestialBody celbody = new CelestialBody();
            Console.WriteLine("\n1. Добавление случайного элемента");
            Console.WriteLine("2. Ввод элемента с клавиатуры");
            int answer = Number(1, 2, "Выберите нoмер задания");
            switch (answer)
            {
                case 1:
                {
                    celbody.RandomInit();
                    break;
                }
                case 2:
                {
                    Console.WriteLine("Введите элемент");
                    celbody.Init();
                    break;
                }
            }
            try
            {
                collection.Add(celbody);
                Console.WriteLine($"\nЭлемент добавлен");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Элемент не добавлен");
            }
        }
        /// <summary>
        /// Удаление элемента из коллекции
        /// </summary>
        static public void Remove(MyObservableCollection<CelestialBody> collection)
        {
            if (collection.Count == 0)
                Console.WriteLine("\nТаблица пустая");
            else
            {
                Console.WriteLine("Введите элемент для поиска");
                CelestialBody celbody = new CelestialBody();
                celbody.Init();                            //Ввод элемента для поиска и удаления  
                bool ok = collection.Remove(celbody);
                if (ok)
                    Console.WriteLine($"\nЭлемент удален");
                else
                    Console.WriteLine($"\nЭлемент не найден");
            }
        }
        static void Main(string[] args)
        {
            MyObservableCollection<CelestialBody> collection1 = new MyObservableCollection<CelestialBody>("Коллекция1");
            MyObservableCollection<CelestialBody> collection2 = new MyObservableCollection<CelestialBody>("Коллекция2");

            Journal<CelestialBody> journal1 = new Journal<CelestialBody>();
            Journal<CelestialBody> journal2 = new Journal<CelestialBody>();

            collection1.CollectionCountChange += journal1.WriteRecord;      //Подписка
            collection1.CollectionReferenceChange += journal1.WriteRecord;  //Подписка

            collection2.CollectionCountChange += journal2.WriteRecord;      //Подписка
            collection2.CollectionReferenceChange += journal2.WriteRecord;  //Подписка

            int answer;
            do
            {
                Console.WriteLine("\n1. Создать коллекцию 1");
                Console.WriteLine("2. Создать коллекцию 2");
                Console.WriteLine("3. Добавить элемент в коллекцию 1");
                Console.WriteLine("4. Добавить элемент в коллекцию 2");
                Console.WriteLine("5. Удаление элемента из коллекции 1");
                Console.WriteLine("6. Удаление элемента из коллекции 2");
                Console.WriteLine("7. Печать журнала коллекции 1");
                Console.WriteLine("8. Печать журнала коллекции 2");
                Console.WriteLine("9. Выход");
                answer = Number(1, 9, "Выберите нoмер задания");
                switch (answer)
                {
                    case 1:     //Создать коллекцию 1
                        {
                            CreateCollection(collection1);
                            break;
                        }
                    case 2:     //Создать коллекцию 2
                        {
                            CreateCollection(collection2);
                            break;
                        }
                    case 3:     //Добавить элемент в коллекцию  1             
                        {
                            Add(collection1);
                            break;
                        }
                    case 4:     //Добавить элемент в коллекцию  2           
                        {
                            Add(collection2);
                            break;
                        }
                    case 5:  //Удаление элемента в коллекции 1
                        {
                            Remove(collection1);
                            break;
                        }
                    case 6:  //Удаление элемента в коллекции 2
                        {
                            Remove(collection2);
                            break;
                        }
                    case 7:
                        {
                            journal1.PrintJournal();
                            break;
                        }
                    case 8:
                        {
                            journal2.PrintJournal();
                            break;
                        }
                    case 9:
                    {
                        break;
                    }
                }
            } while (answer != 9);
        }
    }
}
