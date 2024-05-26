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
        public JournalEntry(string collectionName, string changeType, string data)  //Конструктор с параметрами
        {
            CollectionName = collectionName;  //Название коллекции
            ChangeType = changeType;          //Тип изменения
            Data = data;                      //Данные объекта
        }
        public override string ToString()
        {
            return $"В коллекции {CollectionName} {ChangeType}. Обьект: {Data}";
        }
    }
}
