using ClassLibrary1;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;


namespace Lab13
{
    public class Journal   //Класс подписчик
    {
        List<JournalEntry> journal = new List<JournalEntry>();  //Список записей
        public int Count => journal.Count;  //Для тестирования

        public void WriteRecord( object source, CollectionHandlerEventArgs args) //Обработчик событий
        {
            var collection = source as ICollectionName; 
            string collectionName = collection?.CollectionName ?? "Коллекция"; //Имя коллекции
            if (args.Item2 != null)
                journal.Add(new JournalEntry(collectionName, args.ChangeType, args.Item1.ToString(), args.Item2.ToString()));
            else
                journal.Add(new JournalEntry(collectionName, args.ChangeType, args.Item1.ToString()));
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
