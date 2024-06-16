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

        /// <summary>
        /// Индексатор
        /// </summary>
        static public void Index(MyObservableCollection<CelestialBody> collection)
        {
            Console.WriteLine("\nВведите старый элемент");
            CelestialBody oldValue = new CelestialBody();
            oldValue.Init();
            if (collection.Contains(oldValue))
            {
                Console.WriteLine("\nВведите новое значение");
                CelestialBody newValue = new CelestialBody();
                newValue.Init();
                collection[oldValue] = newValue;
                Console.WriteLine("\nЗначение изменено");
            }
            else
                Console.WriteLine("\nЗначения нет в коллеции");
        }
        static void Main(string[] args)
        {
            MyObservableCollection<CelestialBody> collection1 = new MyObservableCollection<CelestialBody>("Коллекция1");
            MyObservableCollection<CelestialBody> collection2 = new MyObservableCollection<CelestialBody>("Коллекция2");

            Journal journal1 = new Journal();
            Journal journal2 = new Journal();
            
            collection1.CollectionCountChange += journal1.WriteRecord;      //Подписка
            collection1.CollectionReferenceChange += journal1.WriteRecord;  //Подписка

            collection1.CollectionReferenceChange += journal2.WriteRecord;  //Подписка
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
                Console.WriteLine("7. Индексатор коллекции 1");
                Console.WriteLine("8. Индексатор коллекции 2");
                Console.WriteLine("9. Печать журнала коллекции 1");
                Console.WriteLine("10. Печать журнала коллекции 2");
                Console.WriteLine("11. Печать коллекции 1");
                Console.WriteLine("12. Печать коллекции 2");
                Console.WriteLine("13. Выход");
                answer = Number(1, 13, "Выберите нoмер задания");
                switch (answer)
                {
                    case 1:     //Создать коллекцию 1
                    {
                        CreateCollection(collection1);
                        journal1 = new Journal();
                        collection1.CollectionCountChange += journal1.WriteRecord;      //Подписка
                        collection1.CollectionReferenceChange += journal1.WriteRecord;  //Подписка
                        collection1.CollectionReferenceChange += journal2.WriteRecord;  //Подписка
                        break;
                    }
                    case 2:     //Создать коллекцию 2
                    {
                        CreateCollection(collection2);
                        journal2 = new Journal();
                        collection2.CollectionReferenceChange += journal2.WriteRecord;  //Подписка
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
                    case 7:  //Индексатор 
                    {
                        try
                        {
                            Index(collection1);
                        }
                        catch
                        {
                            Console.WriteLine("Ссылка не изменена");
                        }
                        break;
                    }
                    case 8:  //Индексатор 
                    {
                        try
                        {
                            Index(collection2);
                        }
                        catch
                        {
                            Console.WriteLine("Ссылка не изменена");
                        }
                        break;
                    }
                    case 9:  // Печать журнала коллекции 1
                        {
                        journal1.PrintJournal();
                        break;
                    }
                    case 10:  // Печать журнала коллекции 2
                        {
                        journal2.PrintJournal();
                        break;
                    }
                    case 11: //Печать коллекции 1
                    {
                        if (collection1 == null || collection1.Count == 0)
                            Console.WriteLine("Коллекция пустая");
                        else
                        {
                            Console.WriteLine();
                            foreach (var item in collection1)
                            {
                                Console.WriteLine(item);
                            }
                        }
                        break;
                    }
                    case 12: //Печать коллекции 2
                    {
                        if (collection2 == null || collection2.Count == 0)
                            Console.WriteLine("Коллекция пустая");
                        else
                        {
                            Console.WriteLine();
                            foreach (var item in collection2)
                            {
                                Console.WriteLine(item);
                            }
                        }
                        break;
                    }
                }
            } while (answer != 13);
        }
    }
}
