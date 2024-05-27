using ClassLibrary1;
using System;
using System.Collections.Generic;


namespace Lab13
{
    public class Journal<T> where T : IInit, ICloneable, new()    //Класс подписчик
    {
        List<JournalEntry> journal = new List<JournalEntry>();  //Список записей
        public int Count => journal.Count;  //Для тестирования

        public void WriteRecord(object source, CollectionHandlerEventArgs args) //Обработчик событий
        {
            MyObservableCollection<T> collection = source as MyObservableCollection<T>; //Приведение source к типу MyObservableCollection
            string collectionName = collection?.CollectionName;                         //Имя коллекции
            journal.Add(new JournalEntry(collectionName, args.ChangeType, args.Item.ToString()));
        }
        /// <summary>
        /// Печать журнала
        /// </summary>
        public void PrintJournal()
        {
            if (journal.Count == 0)
            {
                Console.WriteLine("Журнал пустой");
                return;
            }
            foreach (JournalEntry item in journal) 
            {
                Console.WriteLine(item);
            }
        }
    }
}
