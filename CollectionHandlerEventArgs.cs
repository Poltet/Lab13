using System;
using System.Collections.Generic;


namespace Lab13
{
    public class CollectionHandlerEventArgs : EventArgs  //Класс - конверт
    {
        public string ChangeType { get; set; }     //Тип изменения коллекции
        public object Item1 { get; set; }           //Ссылка на обьект изменений
        public object Item2 { get; set; }           //Ссылка на обьект изменений

        public CollectionHandlerEventArgs(string changeType,  object items) //Конструктор с параметрами 
        {
            ChangeType = changeType;               //Тип изменения коллекции
            Item1 = items;               //Ссылка на обьект изменений
            Item2 = null;
        }
        public CollectionHandlerEventArgs(string changeType, object item1, object item2) //Конструктор с параметрами 
        {
            ChangeType = changeType;     //Тип изменения коллекции
            Item1 = item1;               //Ссылка на обьект изменений
            Item2 = item2;               //Ссылка на обьект изменений
        }
    }
}
