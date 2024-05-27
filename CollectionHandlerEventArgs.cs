using System;


namespace Lab13
{
    public class CollectionHandlerEventArgs : EventArgs  //Класс - конверт
    {
        public string ChangeType { get; set; }     //Тип изменения коллекции
        public object Item { get; set; }           //Ссылка на обьект изменений

        public CollectionHandlerEventArgs(string changeType, object item) //Конструктор с параметрами 
        {
            ChangeType = changeType;    //Тип изменения коллекции
            Item = item;                //Ссылка на обьект изменений
        }
    }
}
