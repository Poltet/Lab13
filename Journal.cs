using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab13
{
    public class Journal<T> where T : IInit, ICloneable, new()
    {
        List<JournalEntry> journal = new List<JournalEntry>();  //Список записей
        public void WriteRecord(object source, CollectionHandlerEventArgs args) //Обработчик событий
        {
            //string collectionName = source.GetType().Name; //Получаем имя коллекции
            MyObservableCollection<T> collection = source as MyObservableCollection<T>; //Приводим source к типу MyObservableCollection
            string collectionName = collection?.CollectionName;                         //Получаем имя коллекции
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
