using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab13
{
    public class JournalEntry
    {
        public string CollectionName { get; set; }  //Название коллекции
        public string ChangeType { get; set; }      //Тип изменения
        public string Data { get; set; }            //Данные объекта
        public string Data2 { get; set; }            //Данные объекта
        public JournalEntry(string collectionName, string changeType, string data)  //Конструктор с параметрами
        {
            CollectionName = collectionName;  //Название коллекции
            ChangeType = changeType;          //Тип изменения
            Data = data;                      //Данные объекта
            Data2 = null;
        }
        public JournalEntry(string collectionName, string changeType, string data, string data2)  //Конструктор с параметрами
        {
            CollectionName = collectionName;  //Название коллекции
            ChangeType = changeType;          //Тип изменения
            Data = data;                      //Данные объекта
            Data2 = data2;
        }
        public override string ToString()
        {
            if (Data2 == null)
                return $"В коллекции {CollectionName} {ChangeType}. Обьект: {Data}";
            return $"В коллекции {CollectionName} {ChangeType}. Обьект {Data} изменен на обьект {Data2}";
        }
    }
}
