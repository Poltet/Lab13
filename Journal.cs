using ClassLibrary1;
using ClassLibrary12;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lab13
{
    public class Journal<T> where T : IInit, ICloneable, new()
    {
        List<JournalEntry> journal = new List<JournalEntry>();  //Список записей
        public int Count => journal.Count;  //Для тестирования
        public void WriteRecord(object source, CollectionHandlerEventArgs args) //Обработчик событий
        {
            MyObservableCollection<T> collection = source as MyObservableCollection<T>; //Приведение source к типу MyObservableCollection
            string collectionName = collection?.CollectionName;                         //Имя коллекции
            journal.Add(new JournalEntry(collectionName, args.ChangeType, args.Item.ToString()));
        }
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
