using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                            int count = Number(0, 100, "Введите количество элементов коллекции");
                            for (int i = 0; i < count; i++)
                            {
                                CelestialBody celbody = new CelestialBody();
                                celbody.RandomInit();
                                collection1.Add(celbody);                               
                            }
                            break;
                        }
                    case 2:     //Создать коллекцию 2
                        {
                            int count = Number(0, 100, "Введите количество элементов коллекции");
                            for (int i = 0; i < count; i++)
                            {
                                CelestialBody celbody = new CelestialBody();
                                celbody.RandomInit();
                                collection2.Add(celbody);
                            }
                            break;
                        }
                    case 3:     //Добавить элемент в коллекцию  1             
                        {
                            CelestialBody celbody = new CelestialBody();
                            Console.WriteLine("\n1. Добавление случайного элемента");
                            Console.WriteLine("2. Ввод элемента с клавиатуры");
                            answer = Number(1, 2, "Выберите нoмер задания");
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
                                collection1.Add(celbody);
                                Console.WriteLine($"\nЭлемент добавлен");
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.Message);
                                Console.WriteLine("Элемент не добавлен");
                            }
                            break;
                        }
                    case 4:     //Добавить элемент в коллекцию  2           
                        {
                            CelestialBody celbody = new CelestialBody();
                            Console.WriteLine("\n1. Добавление случайного элемента");
                            Console.WriteLine("2. Ввод элемента с клавиатуры");
                            answer = Number(1, 2, "Выберите нoмер задания");
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
                                collection2.Add(celbody);
                                Console.WriteLine($"\nЭлемент добавлен");
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.Message);
                                Console.WriteLine("Элемент не добавлен");
                            }
                            break;
                        }
                    case 5:  //Удаление элемента в коллекции 1
                        {
                            if (collection1.Count == 0)
                                Console.WriteLine("\nТаблица пустая");
                            else
                            {
                                Console.WriteLine("Введите элемент для поиска");
                                CelestialBody celbody = new CelestialBody();
                                celbody.Init();                            //Ввод элемента для поиска и удаления  
                                bool ok = collection1.Remove(celbody);
                                if (ok)
                                    Console.WriteLine($"\nЭлемент удален");
                                else
                                    Console.WriteLine($"\nЭлемент не найден");
                            }
                            break;
                        }
                    case 6:  //Удаление элемента в коллекции 2
                        {
                            if (collection2.Count == 0)
                                Console.WriteLine("\nТаблица пустая");
                            else
                            {
                                Console.WriteLine("Введите элемент для поиска");
                                CelestialBody celbody = new CelestialBody();
                                celbody.Init();                            //Ввод элемента для поиска и удаления  
                                bool ok = collection2.Remove(celbody);
                                if (ok)
                                    Console.WriteLine($"\nЭлемент удален");
                                else
                                    Console.WriteLine($"\nЭлемент не найден");
                            }
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
                }
            } while (answer != 9);
        }
    }
}
